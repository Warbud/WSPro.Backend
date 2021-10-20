using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class ElementRepository:IElementRepository
    {
        private readonly WSProContext _context;
        public ElementRepository(WSProContext context)
        {
            _context = context; 
        }
        public Task<bool> ExistAsync(Element element)
        {
            return _context.Elements.AnyAsync(e => e.Id == element.Id);
        }

        public Task<IQueryable<Element>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Element>>(_context.Elements);
        }

        public Task<Element> GetByIdAsync(Element element)
        {
            return _context.Elements.FirstOrDefaultAsync(e => e.Id == element.Id);
        }

        public async Task<Element> CreateAsync(Element element)
        {
            await _context.Elements.AddAsync(element);
            await _context.SaveChangesAsync();
            return element;
        }

        public async Task<Element> UpdateAsync(Element element)
        {
            _context.Elements.Update(element);
            await _context.SaveChangesAsync();
            return element;
        }

        public async Task<Element> DeleteAsync(Element element)
        {
            _context.Elements.Remove(element);
            await _context.SaveChangesAsync();
            return element;
        }
    }
}