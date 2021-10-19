using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CraneRepository:ICraneRepository
    {
        private readonly WSProContext _context;
        public CraneRepository(WSProContext context)
        {
            _context = context;
        }

        public Task<bool> CraneExistAsync(Crane crane)
        {
            return _context.Cranes.AnyAsync(c => c.Id == crane.Id);
        }

        public Task<IQueryable<Crane>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Crane>>(_context.Cranes);
        }

        public  Task<Crane> GetByIdAsync(int id)
        {
            return  _context
                .Cranes
                .FirstOrDefaultAsync( crane => crane.Id == id);
        }

        public async Task<Crane> CreateAsync(Crane crane)
        {
            await _context.Cranes.AddAsync(crane);
            await _context.SaveChangesAsync();
            return crane;
        }


        public async Task<Crane[]> CreateRangeAsync(Crane[] cranes)
        {
            await _context.Cranes.AddRangeAsync(cranes);
            await _context.SaveChangesAsync();
            return cranes;
        }

        public async Task<Crane> UpdateAsync(Crane updatedCrane)
        {
            _context.Cranes.Update(updatedCrane);
            await _context.SaveChangesAsync();
            return updatedCrane;
        }

        public async Task<Crane> DeleteAsync(Crane crane)
        {
            _context.Cranes.Remove(crane);
            await _context.SaveChangesAsync();
            return crane;
        }

        

    }
}