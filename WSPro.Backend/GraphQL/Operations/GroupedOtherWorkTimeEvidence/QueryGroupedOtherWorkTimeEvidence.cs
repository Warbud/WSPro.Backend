using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.GroupedOtherWorkTimeEvidence
{
    [ExtendObjectType(nameof(Query))]
    public class QueryGroupedOtherWorkTimeEvidence : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.GroupedOtherWorkTimeEvidence>> GetGroupedOtherWorkTimeEvidence(int id,
            [Service] IGroupedOtherWorkTimeEvidenceRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.GroupedOtherWorkTimeEvidence>> GetGroupedOtherWorkTimeEvidences(
            [Service] IGroupedOtherWorkTimeEvidenceRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}