using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Domain.Interfaces
{
    public interface IElementRepository
    {
        Task<bool> ExistAsync(Element element);
        Task<IQueryable<Element>> GetAllAsync();
        Task<Element> GetByIdAsync(Element element);
        Task<Element> CreateAsync(Element element);
        Task<Element> UpdateAsync(Element element);
        Task<Element> DeleteAsync(Element element);
    }
}