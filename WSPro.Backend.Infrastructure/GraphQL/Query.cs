using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using WSPro.Backend.Model;

namespace WSPro.Backend.Infrastructure.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public IQueryable<Crane> GetCrane([ScopedService] WSProContext context)
        {
            return context.Cranes;
        }

        [UseDbContext(typeof(WSProContext))]
        [UseProjection]
        public IQueryable<Element> GetElement([ScopedService] WSProContext context)
        {
            return context.Elements;
        }
    }
}