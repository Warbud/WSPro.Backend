using System.Linq;
using System.Threading.Tasks;

namespace WSPro.Backend.Domain.Helpers
{
    public interface IBaseOperations<T> where T : IEntity
    {
        Task<bool> ExistAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetByIdAsync(int id);
        Task<IQueryable<T>> CreateAsync(T item);
        Task<IQueryable<T>> UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}