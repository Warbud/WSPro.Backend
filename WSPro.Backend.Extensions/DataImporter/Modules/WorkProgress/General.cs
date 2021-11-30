using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Extensions.DataImporter.Exceptions;
using WSPro.Backend.Extensions.DataImporter.Interfaces;
using WSPro.Backend.Extensions.DataReader;
using WSPro.Backend.Infrastructure.Interfaces;
using WSPro.Backend.Shared.Importers;

namespace WSPro.Backend.Extensions.DataImporter.Modules.WorkProgress
{
    public class General : IGeneralDataImporter
    {
        private readonly IElementRepository _elementRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ICustomParamValueRepository _customParamValueRepository;
        private Project? _project;
        private Csv? _importedData;

        public General(IProjectRepository projectRepository, IElementRepository elementRepository, ICustomParamValueRepository customParamValueRepository)
        {
            _projectRepository = projectRepository;
            _elementRepository = elementRepository;
            _customParamValueRepository = customParamValueRepository;
        }

        private List<IEntity> _toCreate = new();
        private List<IEntity> _toUpdate = new();
        public Dictionary<string, int> Created { get; set; } = new();
        public Dictionary<string, int> Updated { get; set; } = new();
        private readonly Dictionary<CustomParams, int> _headersMap = new();

        public async Task WithProject(int projectId)
        {
            var project = (await _projectRepository.GetByIdAsync(projectId))
                .Include(e => e.CustomParams)
                .FirstOrDefault();
            _project = project ?? throw new NotFindObject($"Dont find project with id = {projectId}");
        }

        public Task WithData(Csv data)
        {
            _importedData = data.ParseCsv();
            return Task.CompletedTask;
        }

        public async Task<ICollection<Dictionary<CustomParams, ParsedValue>>> Parse()
        {
            if (_importedData is null)
                throw new NotValidImportException("Don't imported any data");

            ICollection<Dictionary<CustomParams, ParsedValue>> outputParsedData =
                new List<Dictionary<CustomParams, ParsedValue>>();
            for (var i = 0; i < _importedData.Data.Count; i++) outputParsedData.Add(ParseRow(_importedData.Data[i]));
            ;

            return outputParsedData;
        }

        private Dictionary<CustomParams, ParsedValue> ParseRow(IReadOnlyList<string> rowData)
        {
            Dictionary<CustomParams, ParsedValue> outputValues = new();
            foreach (var (header, index) in _headersMap)
            {
                object? parsedData = null;
                string? errorMessage = null;
                try
                {
                    parsedData = HandleParseValue(header, rowData[index]);
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }

                outputValues.Add(header, new ParsedValue(parsedData, errorMessage));
            }

            return outputValues;
        }

        private void ExtractHeaders()
        {
            var importedHeaders = _importedData!.Headers;
            var projectHeaders = _project!.CustomParams!;

            // projectHeaders = new List<CustomParams>
            // {
            //     new()
            //     {
            //         Key = "revitId",
            //         Description = "ID w modelu",
            //         Type = CustomParamsDataTypes.Integer,
            //         IsCustom = false,
            //         CanBeNull = false
            //     },
            //     new()
            //     {
            //         Key = "DIPCode",
            //         Description = "DIP numer",
            //         Type = CustomParamsDataTypes.String,
            //         CanBeNull = true,
            //         IsCustom = true
            //     },
            //     new()
            //     {
            //         Key = "IsPrefabricated",
            //         Description = "Czy prefabrykowany",
            //         Type = CustomParamsDataTypes.Bool,
            //         IsCustom = false,
            //         CanBeNull = false
            //     }
            // };
            if (projectHeaders is null || projectHeaders.Count == 0)
                throw new NotContainException(
                    "Project do not contains any custom parameters! Data import is not possible");

            if (importedHeaders.Count == 0)
                throw new NotContainException("Imported data don't contains any headers");

            foreach (var projectHeader in projectHeaders)
            {
                // imported data should have these properties with information about name column to import data from
                var dbKey = projectHeader.Key ?? projectHeader.Description;
                if (importedHeaders.Contains(dbKey))
                    _headersMap.Add(projectHeader, importedHeaders.IndexOf(dbKey));
            }

            if (_headersMap.Count == 0)
                throw new NotValidImportException("Check if imported params is named correctly.");
        }

        private object? HandleParseValue(CustomParams header, string importedData)
        {
            var value = ParseValue(header.Type, importedData);
            if (value is null && !header.CanBeNull)
                throw new NotValidParsedData($"Cannot parse data: [{importedData}] as [{header.Type.ToString()}]");

            return value;
        }

        private object? ParseValue(CustomParamsDataTypes type, string? value)
        {
            if (value is null)
                return value;

            switch (type)
            {
                case CustomParamsDataTypes.Bool:
                    return new DataParser.Bool().Parse(value);
                case CustomParamsDataTypes.Date:
                    return new DataParser.Date().Parse(value);
                case CustomParamsDataTypes.Float:
                    return new DataParser.Decimal().Parse(value);
                case CustomParamsDataTypes.Integer:
                    return new DataParser.Integer().Parse(value);
                case CustomParamsDataTypes.String:
                    return string.IsNullOrEmpty(value) ? null : value;
                default:
                    return null;
            }
        }

        public async Task<ICollection<Dictionary<string, ParsedValue>>> Validate()
        {
            ExtractHeaders();
            var parsedData = await Parse();
            ICollection<Dictionary<string, ParsedValue>> outputData = new List<Dictionary<string, ParsedValue>>();
            foreach (var row in parsedData)
            {
                var outputRow = new Dictionary<string, ParsedValue>();
                foreach (var header in row.Keys) outputRow.Add(header.Key ?? header.Description, row[header]);
                outputData.Add(outputRow);
            }

            return outputData;
        }

        public async Task<IDataImporter> Import()
        {
            ExtractHeaders();
            var parsedData = await Parse();
            var revitIdHeader = _headersMap.Keys.FirstOrDefault(e => e.Key == nameof(Element.RevitId));

            if (parsedData.Any(e => e.Any(e => !e.Value.IsValid)) || revitIdHeader is null)
                throw new NotValidImportException("Somenthing is not valid. Check which parameter has wrong name");
            
            var existedElements = await HandleGetElements(parsedData.ToList(), revitIdHeader);
            foreach (var row in parsedData)
            {
                await HandleImportData(row, existedElements, revitIdHeader);
            }


            return this;
        }

        public async Task<List<Element>> HandleGetElements(List<Dictionary<CustomParams, ParsedValue>> items,
            CustomParams revitIdHeader)
        {
            var revitIds = new List<int>();
            
            for (var i = 0; i < items.Count; i++)
            {
                var revitId = (int)items[i][revitIdHeader].Value!;
                revitIds.Add(revitId);
            }

            var existedElements =
                (await _elementRepository.GetAllAsync()).Where(e => e.ProjectId == _project.Id).Include(e=>e.CustomParamValues).ToList();
            return existedElements;
        }

        public async Task HandleImportData(Dictionary<CustomParams, ParsedValue> values, List<Element> existedElements, CustomParams revitIdHeader)
        {
            var revitIdValue = values[revitIdHeader];

            Element element = existedElements.FirstOrDefault(e => e.RevitId == (int)revitIdValue.Value!);
            if (element is null)
            {
                element = (await _elementRepository.CreateAsync(new Element()
                    { RevitId = (int)revitIdValue.Value!, ProjectId = _project!.Id })).First();
            }

            foreach (var (customParams, parsedValue) in values)
            {
                if (customParams.IsCustom)
                {
                    var customParamValue = element.CustomParamValues.FirstOrDefault(e => e.CustomParamsId == customParams.Id);
                    if ( customParamValue is null)
                    {
                        await _customParamValueRepository.CreateAsync(new CustomParamValue()
                        {
                            ElementId = element.Id, Value = parsedValue.Value.ToString(),
                            CustomParamsId = customParams.Id
                        });
                        // element.CustomParamValues.Add(new CustomParamValue(){ElementId = element.Id, Value = parsedValue.Value.ToString(),CustomParamsId = customParams.Id});
                    }
                    else
                    {
                        if (customParamValue.Value != parsedValue.Value.ToString())
                        {
                            customParamValue.Value = parsedValue.Value.ToString();
                        }

                        await _customParamValueRepository.UpdateAsync(customParamValue);
                    }
                }
                else
                {
                    typeof(Element).GetProperty(customParams.Key).SetValue(element, parsedValue.Value);
                }
                // if (typeof(Element).GetProperties().Where(e => !typeof(IEntity).IsAssignableFrom(e.PropertyType))
                //     .Select(e => e.Name).Contains(customParams.Key))
                // {
                //     typeof(Element).GetProperty(customParams.Key).SetValue(element, parsedValue.Value);
                //     continue;
                // }

                
            }

            await _elementRepository.UpdateAsync(element);
        }
    }
}