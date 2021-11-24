using Microsoft.Extensions.DependencyInjection;

namespace WSPro.Backend.Domain
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallDomainServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}