using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.DelayCause
{
    [ExtendObjectType(nameof(Query))]
    public class QueryDelayCause : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.DelayCause>> GetDelayCause(int id,
            [Service] IDelayCauseRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.DelayCause>> GetDelayCauses([Service] IDelayCauseRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}