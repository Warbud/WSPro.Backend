using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CustomParamProjectRepository : DbContextInjection, ICustomParamProjectRepository
    {
        public Task<bool> ExistAsync(int customParamsId, int projectId)
        {
            return Context.CustomParamProjects.AnyAsync(e =>
                e.CustomParamsId == customParamsId && e.ProjectId == projectId);
        }

        public async Task<IQueryable<CustomParamProject>> GetAllAsync()
        {
            return Context.CustomParamProjects;
        }

        public async Task<IQueryable<CustomParamProject>> GetByIdAsync(int customParamsId, int projectId)
        {
            return Context.CustomParamProjects.Where(
                e => 
                    e.CustomParamsId == customParamsId && 
                    e.ProjectId == projectId);
        }

        public async Task<IQueryable<CustomParamProject>> CreateAsync(CustomParamProject item)
        {
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.CustomParamsId, item.ProjectId);
        }

        public async Task DeleteAsync(CustomParamProject item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }

        public CustomParamProjectRepository(WSProContext context) : base(context)
        {
        }
    }
}