using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CustomParamValueRepository:DbContextInjection,ICustomParamValueRepository
    {
        public CustomParamValueRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int customParamsId, int elementId)
        {
            return Context.CustomParamValues.AnyAsync(e =>
                e.CustomParamsId == customParamsId && e.ElementId == elementId);
        }

        public async Task<IQueryable<CustomParamValue>> GetAllAsync()
        {
            return Context.CustomParamValues;
        }

        public async Task<IQueryable<CustomParamValue>> GetByIdAsync(int customParamsId, int elementId)
        {
            return Context.CustomParamValues.Where(e =>
                e.CustomParamsId == customParamsId && e.ElementId == elementId);
        }

        public async Task<IQueryable<CustomParamValue>> CreateAsync(CustomParamValue item)
        {
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.CustomParamsId, item.ElementId);
        }

        // public async Task<IQueryable<CustomParamValue>> UpdateAsync(CustomParamValue item)
        // {
        //     Context.Update(item);
        //     await Context.SaveChangesAsync();
        //     return await GetByIdAsync(item.CustomParamsId, item.ElementId);
        // }

        public async Task UpdateAsync(CustomParamValue item)
        {
            Context.Update(item);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CustomParamValue item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}