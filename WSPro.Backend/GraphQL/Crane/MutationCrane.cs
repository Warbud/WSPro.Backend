using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.Domain.Interfaces;

namespace WSPro.Backend.GraphQL.Crane
{
    [ExtendObjectType(nameof(Mutation))]
    public class MutationCrane
    {
        private ICraneRepository _repository;
        public MutationCrane(ICraneRepository repository)
        {
            _repository = repository;
        }
        
        [UseProjection]
        public Task<Domain.Model.V1.Crane> CreateCrane(CreateCraneInput input)
        {
            return _repository.CreateAsync(input.Name);
        }
        
        [UseProjection]
        public  Task<Domain.Model.V1.Crane[]> CreateCraneRange(CreateCraneInput[] input)
        {
            return _repository.CreateRangeAsync(input.Select(x => x.Name).ToArray());
        }
        
        [UseProjection]
        public Task<Domain.Model.V1.Crane> UpdateCrane(GetCraneInput input,UpdateCraneInput data)
        {
            return _repository.UpdateAsync(input.Id, data.Name);
        }
        
        [UseProjection]
        public Task<Domain.Model.V1.Crane> DeleteCrane(GetCraneInput input)
        {
            return _repository.DeleteAsync(input.Id);
        }
    
        
    }
}