using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class GroupedOtherWorkTimeEvidenceRepository:DbContextInjection,IGroupedOtherWorkTimeEvidenceRepository
    {
        public GroupedOtherWorkTimeEvidenceRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.GroupedOtherWorkTimeEvidences.AnyAsync(e => e.Id == id);;
        }

        public Task<IQueryable<GroupedOtherWorkTimeEvidence>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<GroupedOtherWorkTimeEvidence>>(Context.GroupedOtherWorkTimeEvidences);
            ;
        }

        public async Task<IQueryable<GroupedOtherWorkTimeEvidence>> GetByIdAsync(int id)
        {
            return Context.GroupedOtherWorkTimeEvidences.Where(e => e.Id == id);
            ;
        }

        public async Task<IQueryable<GroupedOtherWorkTimeEvidence>> CreateAsync(GroupedOtherWorkTimeEvidence item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);;
        }

        public async Task<IQueryable<GroupedOtherWorkTimeEvidence>> UpdateAsync(GroupedOtherWorkTimeEvidence item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);;
        }

        public async Task DeleteAsync(GroupedOtherWorkTimeEvidence item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();;
        }
    }
}