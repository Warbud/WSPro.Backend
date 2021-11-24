using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Infrastructure.Helpers;
using WSPro.Backend.Infrastructure.Interfaces;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CrewRepository : DbContextInjection, ICrewRepository
    {
        public CrewRepository(WSProContext context) : base(context)
        {
        }

        public Task<bool> ExistAsync(int id)
        {
            return Context.Crews.AnyAsync(e => e.Id == id);
        }

        public async Task<IQueryable<Crew>> GetAllAsync()
        {
            return Context.Crews;
        }
        
        [UseProjection]
        public async Task<IQueryable<Crew>> GetByIdAsync(int id)
        {
            return Context.Crews.Where(e => e.Id == id);
        }

        public async Task<IQueryable<Crew>> CreateAsync(Crew item)
        {
            item.AttachEntities(Context);
            await Context.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task<IQueryable<Crew>> UpdateAsync(Crew item)
        {
            item.AttachEntities(Context);
            Context.Update(item);
            await Context.SaveChangesAsync();
            return await GetByIdAsync(item.Id);
        }

        public async Task DeleteAsync(Crew item)
        {
            Context.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}