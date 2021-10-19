using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;

namespace WSPro.Backend.GraphQL.Crane
{
    [ExtendObjectType(nameof(Query))]
    public class QueryCrane
    {
        private ICraneService _service;
        public QueryCrane(ICraneService service)
        {
            _service = service;
        }
        [GraphQLDescription("Get particural crane by ID")]
        [UseProjection]
        public Task<Domain.Model.V1.Crane> GetCrane(GetCraneDto input )
        {
            return _service.GetCraneByID(input);
        }
        
        [GraphQLDescription("Get collection of cranes")]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.V1.Crane>> GetCranes()
        {
            return _service.GetAllCranes();
        }

    }
}