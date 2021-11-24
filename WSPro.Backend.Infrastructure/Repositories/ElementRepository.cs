using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class ElementRepository : DbContextInjection, IElementRepository
    {
        public ElementRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.Elements.AnyAsync(e => e.Id == id);
            ;
        }

        public Task<IQueryable<Element>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Element>>(Context.Elements);
            ;
        }

        public async Task<IQueryable<Element>> GetByIdAsync(int id)
        {
            return Context.Elements.Where(e => e.Id == id);
        }

        public async Task<IQueryable<Element>> CreateAsync(Element item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<Element>> UpdateAsync(Element item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(Element item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}