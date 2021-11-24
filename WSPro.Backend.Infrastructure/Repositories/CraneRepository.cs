using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CraneRepository : DbContextInjection, ICraneRepository
    {
        public CraneRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.Cranes.AnyAsync(c => c.Id == id);
        }

        public Task<IQueryable<Crane>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Crane>>(Context.Cranes);
        }


        public async Task<IQueryable<Crane>> GetByIdAsync(int id)
        {
            return Context.Cranes.Where(crane => crane.Id == id);
        }

        public async Task<IQueryable<Crane>> CreateAsync(Crane item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }


        public async Task<Crane[]> CreateRangeAsync(Crane[] cranes)
        {
            await Context.Cranes.AddRangeAsync(cranes);
            await Context.SaveChangesAsync();
            return cranes;
        }

        public async Task<IQueryable<Crane>> UpdateAsync(Crane item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(Crane item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}