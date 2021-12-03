using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using WSPro.Backend.GraphQL.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.GraphQL.Operations.Project
{
    [ExtendObjectType(nameof(Query))]
    public class QueryProject:IGraphQlOperation
    {
        [Authorize]
        [UseFirstOrDefault]
        [UseProjection]
        public Task<IQueryable<Domain.Model.Project>> GetProject(int id, [Service] IProjectRepository repository)
        {
            return repository.GetByIdAsync(id);
        }
       
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.Project>> GetProjects([Service] IProjectRepository repository)
        {
            return repository.GetAllAsync();
        }
        
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        public async Task<IQueryable<Domain.Model.Project>> CountProjects([Service] IProjectRepository repository,IResolverContext context)
        {
            return await repository.GetAllAsync();
        }
        
        
    }
    
    public record CountPayload<T>(int Count, IQueryable<T>? Data);
}