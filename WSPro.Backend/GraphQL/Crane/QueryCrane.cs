using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.Domain.Interfaces;

namespace WSPro.Backend.GraphQL.Crane
{
    [ExtendObjectType(nameof(Query))]
    public class QueryCrane
    {
        private ICraneRepository _repository;
        public QueryCrane(ICraneRepository repository)
        {
            _repository = repository;
        }
        [GraphQLDescription("Get particural crane by ID")]
        // [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        // public Task<Domain.Model.V1.Crane?> GetCrane(GetCraneInput input,[ScopedService] WSProContext context)
        public Task<Domain.Model.V1.Crane> GetCrane(GetCraneInput input )
        {
            return _repository.GetByIdAsync(input.Id);
        }
        
        [GraphQLDescription("Get collection of cranes")]
        // [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Domain.Model.V1.Crane> GetCranes()
        {
            return _repository.GetAllAsync();
        }

    }
}