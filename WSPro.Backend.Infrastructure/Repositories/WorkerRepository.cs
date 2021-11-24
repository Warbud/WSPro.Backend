using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class WorkerRepository:DbContextInjection,IWorkerRepository
    {
        public WorkerRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.Workers.AnyAsync(e => e.Id == id);
            ;
        }

        public Task<IQueryable<Worker>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Worker>>(Context.Workers);
            ;
        }

        public async Task<IQueryable<Worker>> GetByIdAsync(int id)
        {
            return Context.Workers.Where(e => e.Id == id);
            ;
        }

        public async Task<IQueryable<Worker>> CreateAsync(Worker item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<Worker>> UpdateAsync(Worker item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(Worker item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();;
        }
    }
}