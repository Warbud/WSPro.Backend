using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Extensions.DataImporter.Exceptions;
using WSPro.Backend.Extensions.DataImporter.Interfaces;
using WSPro.Backend.Extensions.DataReader;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Extensions.DataImporter.Modules.WorkProgress
{
    public class General : IGeneralDataImporter
    {
        private readonly IElementRepository _elementRepository;

        private readonly IProjectRepository _projectRepository;
        private Project? _project;
        private Csv? _importedData;

        public General(IProjectRepository projectRepository, IElementRepository elementRepository)
        {
            _projectRepository = projectRepository;
            _elementRepository = elementRepository;
        }

        public Dictionary<string, int> Created { get; set; } = new();
        public Dictionary<string, int> Updated { get; set; } = new();

        public async Task WithProject(int projectId)
        {
            _project = (await _projectRepository.GetByIdAsync(projectId))
                .Include(e => e.CustomParams)
                .FirstOrDefault();
        }

        public Task WithData(Csv data)
        {
            _importedData = data;
            return Task.CompletedTask;
        }


        public async Task Parse()
        {
            var headersMap = ExtractHeaders();
        }

        private Dictionary<string, int> ExtractHeaders()
        {
            Dictionary<string, int> headersMap = new();
            var importedHeaders = _importedData?.Headers;
            var projectHeaders = _project?.CustomParams.ToList();
            if (projectHeaders is null || projectHeaders.Count == 0)
                throw new NotContainException(
                    "Project do not contains any custom parameters! Data import is not possible");

            if (importedHeaders is null || importedHeaders.Count == 0)
                throw new NotContainException("Imported data don't contains any headers");

            foreach (var projectHeader in projectHeaders)
            {
                // imported data should have these properties with information about name column to import data from
                var dbKey = projectHeader.Key ?? projectHeader.Description;
                if (importedHeaders.Contains(dbKey))
                    headersMap.Add(projectHeader.Key ?? projectHeader.Description, importedHeaders.IndexOf(dbKey));
            }

            if (headersMap.Count == 0)
                throw new NotValidImportException("Check if imported params is named correctly.");

            return headersMap;
        }
        
        public IDataImporter Validate()
        {
            return this;
        }

        public IDataImporter Import()
        {
            return this;
        }
    }
}