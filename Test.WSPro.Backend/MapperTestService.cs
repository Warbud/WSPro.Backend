using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Application;

namespace Test.WSPro.Backend
{
    public class MapperTestService
    {
        public IMapper Mapper;
        public MapperTestService()
        {
            var service = new ServiceCollection();
            service.InstallApplicationServices();
            Mapper = service.BuildServiceProvider().GetService<IMapper>()!;
        }
    }
}