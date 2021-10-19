using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;

namespace WSPro.Backend.GraphQL.Level
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationLevel
    {
        private readonly ILevelService _service;
        public MutationLevel(ILevelService service)
        {
            _service = service;
        }

        [UseProjection]
        public Task<Domain.Model.V1.Level> CreateLevel(CreateLevelDto input, CancellationToken cancellationToken)
        {
            return _service.CreateAsync(input, cancellationToken);
        }

        [UseProjection]
        public Task<Domain.Model.V1.Level[]> CreateManyLevels(CreateLevelDto[] input,
            CancellationToken cancellationToken)
        {
            return _service.CreateManyAsync(input, cancellationToken);
        }

        [UseProjection]
        public Task<Domain.Model.V1.Level> UpdateLevel(GetLevelDto input, CreateLevelDto data,
            CancellationToken cancellationToken)
        {
            return _service.UpdateAsync(input, data, cancellationToken);
        }

        [UseProjection]
        public Task<Domain.Model.V1.Level> DeleteLevel(GetLevelDto input, CancellationToken cancellationToken)
        {
            return _service.DeleteAsync(input, cancellationToken);
        }
        
    }
}