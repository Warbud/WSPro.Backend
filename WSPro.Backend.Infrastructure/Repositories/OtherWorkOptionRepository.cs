using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class OtherWorkOptionRepository:DbContextInjection,IOtherWorkOptionRepository
    {
        public OtherWorkOptionRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.OtherWorkOptions.AnyAsync(e => e.Id == id);
            ;
        }

        public Task<IQueryable<OtherWorkOption>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<OtherWorkOption>>(Context.OtherWorkOptions);;
        }

        public async Task<IQueryable<OtherWorkOption>> GetByIdAsync(int id)
        {
            return Context.OtherWorkOptions.Where(e => e.Id == id);
            ;
        }

        public async Task<IQueryable<OtherWorkOption>> CreateAsync(OtherWorkOption item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<OtherWorkOption>> UpdateAsync(OtherWorkOption item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(OtherWorkOption item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}