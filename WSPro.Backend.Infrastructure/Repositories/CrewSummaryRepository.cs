using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CrewSummaryRepository:DbContextInjection,ICrewSummaryRepository
    {
        public CrewSummaryRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.CrewSummaries.AnyAsync(e => e.Id == id);
        }

        public Task<IQueryable<CrewSummary>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<CrewSummary>>(Context.CrewSummaries);
        }

        public async Task<IQueryable<CrewSummary>> GetByIdAsync(int id)
        {
            return Context.CrewSummaries.Where(e => e.Id == id);
        }

        public async Task<IQueryable<CrewSummary>> CreateAsync(CrewSummary item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<CrewSummary>> UpdateAsync(CrewSummary item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(CrewSummary item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}