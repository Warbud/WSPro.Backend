using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Extensions.DataImporter.Interfaces;
using WSPro.Backend.Extensions.DataImporter.Modules.WorkProgress;

namespace WSPro.Backend.Extensions
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallExtension(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGeneralDataImporter, General>();
            
            return serviceCollection;
        }
    }
}