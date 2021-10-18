using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class CraneRepository:ICraneRepository
    {
        private WSProContext _context;
        private IValidator<Crane> _validation;
        public CraneRepository(WSProContext context, IValidator<Crane> validation
            )
        {
            _context = context;
            _validation = validation;
        }


        public IQueryable<Crane> GetAllAsync()
        {
            return _context.Cranes;
        }

        public Task<Crane> GetByIdAsync(int id)
        {
            return _context
                .Cranes
                .FirstOrDefaultAsync( crane => crane.Id == id);
        }

        public async Task<Crane> CreateAsync(string name)
        {
            var crane = new Crane() { Name = name };
            
            await _validation.ValidateAndThrowAsync(crane);

            await _context.Cranes.AddAsync(crane);
            await _context.SaveChangesAsync();
            return crane;
        }

        public async Task<Crane> UpdateAsync(int currentCraneId, string newName)
        {
            var crane = await _context.Cranes.FirstOrDefaultAsync(c => c.Id == currentCraneId);
            crane.Name = newName;
            
            await _validation.ValidateAndThrowAsync(crane);
            
            await _context.SaveChangesAsync();
            return crane;
        }

        public Task<Crane> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}