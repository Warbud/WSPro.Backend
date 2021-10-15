using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Infrastructure;

namespace WSPro.Backend.GraphQL.Element
{
    [ExtendObjectType(nameof(Query))]
    public class ElementQuery
    {
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public Task<Model.Element?> GetElement(GetElementInput input, [ScopedService] WSProContext context)
        {
            return context.Elements.FirstOrDefaultAsync(e => input.Id == e.Id);
        }
        
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Element> GetElements([ScopedService] WSProContext context)
        {
            return context.Elements;
        }
    }
    

    
}