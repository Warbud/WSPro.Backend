using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CustomParamsRepository:DbContextInjection,ICustomParamsRepository
    {
        
        public CustomParamsRepository(WSProContext context) : base(context)
        {
        }
        
        public Task<bool> ExistAsync(int id)
        {
            return Context.CustomParams.AnyAsync(e => e.Id == id);
        }

        public async Task<IQueryable<CustomParams>> GetAllAsync()
        {
            return Context.CustomParams;
        }

        public async Task<IQueryable<CustomParams>> GetByIdAsync(int id)
        {
            return Context.CustomParams.Where(e=>e.Id==id);
        }

        public async Task<IQueryable<CustomParams>> CreateAsync(CustomParams item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<CustomParams>> UpdateAsync(CustomParams item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(CustomParams item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }

    }
}