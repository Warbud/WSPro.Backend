using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class DelayCauseRepository:DbContextInjection,IDelayCauseRepository
    {
        public DelayCauseRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.DelayCauses.AnyAsync(e => e.Id == id);
            
        }

        public Task<IQueryable<DelayCause>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<DelayCause>>(Context.DelayCauses);
            ;
        }

        public async Task<IQueryable<DelayCause>> GetByIdAsync(int id)
        {
            return Context.DelayCauses.Where(e => e.Id == id);
        }

        public async Task<IQueryable<DelayCause>> CreateAsync(DelayCause item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<DelayCause>> UpdateAsync(DelayCause item)
        {
            item.AttachEntities(Context);
            
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(DelayCause item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }

        public void Attach(DelayCause item)
        {
            Context.Attach(item);
        }
    }
}