using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.CrewSummary
{
    [ExtendObjectType(nameof(Query))]
    public class QueryCrewSummary:IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.CrewSummary>> GetCrewSummary(int id, [Service] ICrewSummaryRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.CrewSummary>> GetCrewSummaries([Service] ICrewSummaryRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}