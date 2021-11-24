using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CommentaryElementRepository : DbContextInjection, ICommentaryElementRepository
    {
        public CommentaryElementRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.CommentaryElements.AnyAsync(e => e.Id == id);
        }

        public async Task<IQueryable<CommentaryElement>> GetAllAsync()
        {
            return Context.CommentaryElements;
        }

        public async Task<IQueryable<CommentaryElement>> GetByIdAsync(int id)
        {
            return Context.CommentaryElements.Where(e => e.Id == id);
        }

        public async Task<IQueryable<CommentaryElement>> CreateAsync(CommentaryElement item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<CommentaryElement>> UpdateAsync(CommentaryElement item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(CommentaryElement item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}