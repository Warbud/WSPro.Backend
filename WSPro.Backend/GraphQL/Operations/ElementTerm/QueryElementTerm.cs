using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.ElementTerm
{
    [ExtendObjectType(nameof(Query))]
    public class QueryElementTerm : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.ElementTerm>> GetElementTerm(int id,
            [Service] IElementTermRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.ElementTerm>> GetElementTerms(
            [Service] IElementTermRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}