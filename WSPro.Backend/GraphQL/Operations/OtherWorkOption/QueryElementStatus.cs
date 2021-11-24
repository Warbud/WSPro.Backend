using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.OtherWorkOption
{
    [ExtendObjectType(nameof(Query))]
    public class QueryOtherWorkOption : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.OtherWorkOption>> GetOtherWorkOption(int id,
            [Service] IOtherWorkOptionRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.OtherWorkOption>> GetOtherWorkOptions(
            [Service] IOtherWorkOptionRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}