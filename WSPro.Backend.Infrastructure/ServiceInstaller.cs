using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Infrastructure.Repositories;

namespace WSPro.Backend.Infrastructure
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ICraneRepository, CraneRepository>()
                .AddScoped<IProjectRepository, ProjectRepository>()
                .AddScoped<IElementRepository, ElementRepository>()
                .AddScoped<ILevelRepository, LevelRepository>();
            
            return serviceCollection;
        } 
    }
}