using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class WorkerTimeEvidenceRepository:DbContextInjection,IWorkerTimeEvidenceRepository
    {
        public WorkerTimeEvidenceRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.WorkerTimeEvidences.AnyAsync(e => e.Id == id);
            ;
        }

        public Task<IQueryable<WorkerTimeEvidence>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<WorkerTimeEvidence>>(Context.WorkerTimeEvidences);
            ;
        }

        public async Task<IQueryable<WorkerTimeEvidence>> GetByIdAsync(int id)
        {
            return Context.WorkerTimeEvidences.Where(e => e.Id == id);
            ;
        }

        public async Task<IQueryable<WorkerTimeEvidence>> CreateAsync(WorkerTimeEvidence item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<WorkerTimeEvidence>> UpdateAsync(WorkerTimeEvidence item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(WorkerTimeEvidence item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}