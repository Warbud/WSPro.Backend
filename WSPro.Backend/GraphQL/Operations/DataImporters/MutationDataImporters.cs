using System.Threading.Tasks;
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

        public async Task<UploadValidatePayload> ValidateData(UploadInput input, [Service] IGeneralDataImporter dataImporter)
        {
            await dataImporter.WithProject(input.projectId);
            await dataImporter.WithData(new Csv(input.Value, new CsvParserOptions()));
            var parsedData = await dataImporter.Validate();

            return new UploadValidatePayload(parsedData);
        }
        public async Task<UploadImportedPayload> ImportData(UploadInput input, [Service] IGeneralDataImporter dataImporter)
        {
            await dataImporter.WithProject(input.projectId);
            await dataImporter.WithData(new Csv(input.Value, new CsvParserOptions()));
            await dataImporter.Import();

            return new UploadImportedPayload(true);
        }
    }
}