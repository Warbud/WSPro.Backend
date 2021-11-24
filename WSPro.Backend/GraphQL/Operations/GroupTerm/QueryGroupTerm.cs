using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.GroupTerm
{
    [ExtendObjectType(nameof(Query))]
    public class QueryGroupTerm : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.GroupTerm>> GetGroupTerm(int id,
            [Service] IGroupTermRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.GroupTerm>> GetGroupTerms(
            [Service] IGroupTermRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}