using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.WorkerTimeEvidence
{
    [ExtendObjectType(nameof(Query))]
    public class QueryWorkerTimeEvidence : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.WorkerTimeEvidence>> GetWorkerTimeEvidence(int id,
            [Service] IWorkerTimeEvidenceRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.WorkerTimeEvidence>> GetWorkerTimeEvidences(
            [Service] IWorkerTimeEvidenceRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}