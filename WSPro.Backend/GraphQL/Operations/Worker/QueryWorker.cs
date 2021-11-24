using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.Worker
{
    [ExtendObjectType(nameof(Query))]
    public class QueryWorker : IGraphQlOperation
    {
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Worker>> GetWorker(int id,
            [Service] IWorkerRepository repository)
        {
            return repository.GetByIdAsync(id);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.Worker>> GetWorkers(
            [Service] IWorkerRepository repository)
        {
            return repository.GetAllAsync();
        }
    }
}