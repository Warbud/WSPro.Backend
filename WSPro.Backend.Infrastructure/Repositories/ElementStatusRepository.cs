using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class ElementStatusRepository:DbContextInjection,IElementStatusRepository
    {
        public ElementStatusRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.ElementStatuses.AnyAsync(e => e.Id == id);
        }

        public Task<IQueryable<ElementStatus>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<ElementStatus>>(Context.ElementStatuses);
        }

        public async Task<IQueryable<ElementStatus>> GetByIdAsync(int id)
        {
            return Context.ElementStatuses.Where(e => e.Id == id);
        }

        public async Task<IQueryable<ElementStatus>> CreateAsync(ElementStatus item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<ElementStatus>> UpdateAsync(ElementStatus item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(ElementStatus item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}