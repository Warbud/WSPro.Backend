using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.CommentaryElement
{
    [ExtendObjectType(nameof(Query))]
    public class QueryCommentaryElement : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.CommentaryElement>> GetCommentaryElement(int id,
            [Service] ICommentaryElementRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.CommentaryElement>> GetCommentaryElements(
            [Service] ICommentaryElementRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}