using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.Crane
{
    [ExtendObjectType(nameof(Query))]
    public class QueryCrane : IGraphQlOperation
    {
        [GraphQLDescription("Get particural crane by ID")]
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Crane>> GetCrane(int id, [Service] ICraneRepository craneRepository)
        {
            return craneRepository.GetByIdAsync(id);
        }

        [GraphQLDescription("Get collection of cranes")]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.Crane>> GetCranes([Service] ICraneRepository craneRepository)
        {
            return craneRepository.GetAllAsync();
        }
    }
}