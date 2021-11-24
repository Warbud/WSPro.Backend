using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class GroupTermRepository : DbContextInjection, IGroupTermRepository
    {
        public GroupTermRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.GroupTerms.AnyAsync(e => e.Id == id);
            ;
        }

        public Task<IQueryable<GroupTerm>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<GroupTerm>>(Context.GroupTerms);
            ;
        }

        public async Task<IQueryable<GroupTerm>> GetByIdAsync(int id)
        {
            return Context.GroupTerms.Where(e => e.Id == id);
            ;
        }

        public async Task<IQueryable<GroupTerm>> CreateAsync(GroupTerm item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<GroupTerm>> UpdateAsync(GroupTerm item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
            ;
        }

        public async Task DeleteAsync(GroupTerm item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}