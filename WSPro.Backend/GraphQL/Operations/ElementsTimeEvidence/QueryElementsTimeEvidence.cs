using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.ElementsTimeEvidence
{
    [ExtendObjectType(nameof(Query))]
    public class QueryElementsTimeEvidence : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.ElementsTimeEvidence>> GetElementsTimeEvidence(int id,
            [Service] IElementsTimeEvidenceRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.ElementsTimeEvidence>> GetElementsTimeEvidences(
            [Service] IElementsTimeEvidenceRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}