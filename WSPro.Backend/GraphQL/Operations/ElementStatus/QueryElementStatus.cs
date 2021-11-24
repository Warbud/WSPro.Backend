using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.ElementStatus
{
    [ExtendObjectType(nameof(Query))]
    public class QueryElementStatus : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.ElementStatus>> GetElementStatus(int id,
            [Service] IElementStatusRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.ElementStatus>> GetElementStatues(
            [Service] IElementStatusRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}