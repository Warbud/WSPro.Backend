using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Infrastructure;

namespace WSPro.Backend.GraphQL.Crane
{
    [ExtendObjectType(nameof(Query))]
    public class CraneQuery
    {
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public Task<Model.Crane?> GetCrane(GetCraneInput input,[ScopedService] WSProContext context)
        {
           return context
               .Cranes
               .FirstOrDefaultAsync( crane => crane.Id == input.Id);
        }
        
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Model.Crane> GetCranes([ScopedService] WSProContext context)
        {
            return context.Cranes;
        }

    }
}