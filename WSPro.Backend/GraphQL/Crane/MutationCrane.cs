using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;

namespace WSPro.Backend.GraphQL.Crane
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationCrane
    {
        private readonly ICraneService _service;
        public MutationCrane(ICraneService service)
        {
            _service = service;
        }
        
        [UseProjection]
        public Task<Domain.Model.V1.Crane> CreateCrane(CreateCraneDto input, CancellationToken cancellationToken)
        {
            return _service.CreateAsync(input,cancellationToken);
        }
        
        [UseProjection]
        public  Task<Domain.Model.V1.Crane[]> CreateManyCranes(CreateCraneDto[] input,CancellationToken cancellationToken)
        {
            return _service.CreateManyAsync(input,cancellationToken );
        }
        
        [UseProjection]
        public Task<Domain.Model.V1.Crane> UpdateCrane(GetCraneDto input,CreateCraneDto data,CancellationToken cancellationToken)
        {
            return _service.UpdateAsync(input,data,cancellationToken);
        }
        
        [UseProjection]
        public Task<Domain.Model.V1.Crane> DeleteCrane(GetCraneDto input,CancellationToken cancellationToken)
        {
            return _service.DeleteAsync(input,cancellationToken);
        }
    
        
    }
}