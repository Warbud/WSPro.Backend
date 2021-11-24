using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class OtherWorksTimeEvidenceRepository:DbContextInjection,IOtherWorksTimeEvidenceRepository
    {
        public OtherWorksTimeEvidenceRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.OtherWorksTimeEvidences.AnyAsync(e => e.Id == id);
            ;
        }

        public Task<IQueryable<OtherWorksTimeEvidence>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<OtherWorksTimeEvidence>>(Context.OtherWorksTimeEvidences);
            ;
        }

        public async Task<IQueryable<OtherWorksTimeEvidence>> GetByIdAsync(int id)
        {
            return Context.OtherWorksTimeEvidences.Where(e => e.Id == id);;
        }

        public async Task<IQueryable<OtherWorksTimeEvidence>> CreateAsync(OtherWorksTimeEvidence item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);;
        }

        public async Task<IQueryable<OtherWorksTimeEvidence>> UpdateAsync(OtherWorksTimeEvidence item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);;
        }

        public async Task DeleteAsync(OtherWorksTimeEvidence item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();;
        }
    }
}