using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.Crew
{
    [ExtendObjectType(nameof(Query))]
    public class QueryCrew : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Crew>> GetCrew(int id,
            [Service] ICrewRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.Crew>> GetCrews(
            [Service] ICrewRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}