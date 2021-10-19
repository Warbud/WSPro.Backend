using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class LevelRepository:ILevelRepository
    {
        private readonly WSProContext _context;

        public LevelRepository(WSProContext context)
        {
            _context = context;
        }
        
        public Task<bool> LevelExistAsync(Level level)
        {
            return _context.Levels.AnyAsync(l => l.Id == level.Id);
        }

        public Task<IQueryable<Level>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Level>>(_context.Levels);
        }

        public Task<Level> GetByIdAsync(Level level)
        {
            return _context.Levels.FirstOrDefaultAsync(l => l.Id == level.Id);
        }

        public async Task<Level> CreateAsync(Level level)
        {
            await _context.Levels.AddAsync(level);
            await _context.SaveChangesAsync();
            return level;
        }

        public async Task<Level[]> CreateRangeAsync(Level[] levels)
        {
            await _context.Levels.AddRangeAsync(levels);
            await _context.SaveChangesAsync();
            return levels;
        }

        public async Task<Level> UpdateAsync(Level updatedLevel)
        {
            _context.Levels.Update(updatedLevel);
            await _context.SaveChangesAsync();
            return updatedLevel;
        }

        public async Task<Level> DeleteAsync(Level level)
        {
            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();
            return level;
        }
    }
}