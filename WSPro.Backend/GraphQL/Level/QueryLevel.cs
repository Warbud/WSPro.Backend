using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;

namespace WSPro.Backend.GraphQL.Level
{
    [ExtendObjectType(nameof(Query))]
    public class QueryLevel
    {
        private readonly ILevelService _service;
        public QueryLevel(ILevelService service)
        {
            _service = service;
        }

        [GraphQLDescription("get level")]
        [UseProjection]
        public Task<Domain.Model.V1.Level> GetLevel(GetLevelDto input)
        {
            return _service.GetByIdAsync(input);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Task<IQueryable<Domain.Model.V1.Level>> GetLevels()
        {
            return _service.GetAllLevelsAsync();
        }


    }
}