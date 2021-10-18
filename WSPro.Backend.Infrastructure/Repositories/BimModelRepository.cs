using System;
using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Infrastructure.Repositories
{
    public class BimModelRepository:IBimModelsRepository
    {
        private readonly WSProContext _context;
        public BimModelRepository(WSProContext context)
        {
            _context = context;
        }

        public IQueryable<BimModel> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BimModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BimModel> AddAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BimModel> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BimModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}