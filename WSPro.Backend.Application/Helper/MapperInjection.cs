using MapsterMapper;

namespace WSPro.Backend.Application.Helper
{
    public class MapperInjection
    {
        public readonly IMapper Mapper;

        public MapperInjection(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}