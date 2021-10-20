using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly WSProContext _context;

        public ProjectRepository(WSProContext context)
        {
            _context = context;
        }
        
        public Task<bool> ProjectExistAsync(Project project)
        {
            return _context.Projects.AnyAsync(p => p.Id == project.Id);
        }

        public Task<IQueryable<Project>> GetAllAsync()
        {
            return Task.FromResult<IQueryable<Project>>(_context.Projects);
        }

        public Task<Project> GetByIdAsync(Project project)
        {
            return _context.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
        }

        public async Task<Project> CreateAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateAsync(Project project)
        { 
            _context.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return  project;
        }
    }
}