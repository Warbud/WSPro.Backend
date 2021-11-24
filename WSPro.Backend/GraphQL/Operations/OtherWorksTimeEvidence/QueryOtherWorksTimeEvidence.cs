using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.OtherWorksTimeEvidence
{
    [ExtendObjectType(nameof(Query))]
    public class QueryOtherWorksTimeEvidence : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.OtherWorksTimeEvidence>> GetOtherWorksTimeEvidence(int id,
            [Service] IOtherWorksTimeEvidenceRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.OtherWorksTimeEvidence>> GetOtherWorksTimeEvidences(
            [Service] IOtherWorksTimeEvidenceRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}