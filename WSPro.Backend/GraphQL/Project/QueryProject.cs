using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Infrastructure;

namespace WSPro.Backend.GraphQL.Project
{
    [ExtendObjectType(nameof(Query))]
    public class QueryProject
    {
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public Task<Domain.Model.V1.Project> GetProject(GetProjectInput input, [ScopedService] WSProContext context)
        {
            return context.Projects.FirstOrDefaultAsync(p => p.Id == input.Id);
        }

        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Domain.Model.V1.Project> GetProjects([ScopedService] WSProContext context)
        {
            return context.Projects;
        }
    }
}