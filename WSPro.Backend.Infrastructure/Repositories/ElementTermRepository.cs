using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class ElementTermRepository:DbContextInjection,IElementTermRepository
    {
        public ElementTermRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.ElementTerms.AnyAsync(e => e.ElementId == id);;
        }

        public Task<IQueryable<ElementTerm>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<ElementTerm>>(Context.ElementTerms);
        }

        public async Task<IQueryable<ElementTerm>> GetByIdAsync(int id)
        {
            return Context.ElementTerms.Where(e => e.ElementId == id);
        }

        public async Task<IQueryable<ElementTerm>> CreateAsync(ElementTerm item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.ElementId);;
        }

        public async Task<IQueryable<ElementTerm>> UpdateAsync(ElementTerm item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.ElementId);;
        }

        public async Task DeleteAsync(ElementTerm item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();;
        }
    }
}