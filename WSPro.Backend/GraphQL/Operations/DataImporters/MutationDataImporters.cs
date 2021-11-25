﻿using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MapsterMapper;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Extensions.DataImporter.Interfaces;
using WSPro.Backend.Extensions.DataReader;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Shared.Input;
using WSPro.Backend.Shared.Payload;

namespace WSPro.Backend.GraphQL.Operations.DataImporters
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationDataImporters : MapperInjection, IGraphQlOperation
    {
        public MutationDataImporters(IMapper mapper) : base(mapper)
        {
        }

        public async Task<UploadPayload> ImportData(UploadInput input, [Service] IGeneralDataImporter dataImporter)
        {
            await dataImporter.WithProject(input.projectId);
            await dataImporter.WithData(new Csv(input.Value, new CsvParserOptions()));
            await dataImporter.Parse();

            return new UploadPayload(true);
        }
    }
}