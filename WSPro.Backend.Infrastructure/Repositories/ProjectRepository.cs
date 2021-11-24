using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class ProjectRepository : DbContextInjection, IProjectRepository
    {
        public ProjectRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int projectId)
        {
            return Context.Projects.AnyAsync(p => p.Id == projectId);
        }

        public async Task<IQueryable<Project>> GetByIdsAsync(int[] projectIds)
        {
            return Context.Projects.Where(e => projectIds.Contains(e.Id));
        }

        public Task<IQueryable<Project>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Project>>(Context.Projects);
        }

        public async Task<IQueryable<Project>> GetByIdAsync(int projectId)
        {
            var data = Context.Projects.Where(e => e.Id == projectId);
            // Context.AttachRange(data);
            return data;
        }

        public async Task<IQueryable<Project>> CreateAsync(Project item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<Project>> UpdateAsync(Project item)
        {
            // item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public Task AttachAsync(Project item)
        {
            item.AttachEntities(Context);
            return Task.CompletedTask;
        }
        
        public async Task DeleteAsync(Project item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}