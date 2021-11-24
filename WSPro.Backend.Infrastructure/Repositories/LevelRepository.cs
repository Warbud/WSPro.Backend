using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class LevelRepository : DbContextInjection,ILevelRepository
    {
        public LevelRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.Levels.AnyAsync(e => e.Id == id);
        }

        public Task<IQueryable<Level>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Level>>(Context.Levels);
            ;
        }

        public async Task<IQueryable<Level>> GetByIdAsync(int id)
        {
            return Context.Levels.Where(e => e.Id == id);
            ;
        }

        public async Task<IQueryable<Level>> CreateAsync(Level item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<Level>> UpdateAsync(Level item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(Level item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }

        public Task<Level[]> CreateRangeAsync(Level[] levels)
        {
            throw new System.NotImplementedException();
        }
    }
}