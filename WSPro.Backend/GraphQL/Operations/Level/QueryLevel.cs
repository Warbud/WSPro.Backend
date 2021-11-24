using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.Level
{
    [ExtendObjectType(nameof(Query))]
    public class QueryLevel : IGraphQlOperation
    {
        [GraphQLDescription("get level")]
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Level>> GetLevel(int id, [Service] ILevelRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.Level>> GetLevels([Service] ILevelRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}