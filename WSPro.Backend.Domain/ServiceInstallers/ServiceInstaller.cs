using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model.V1;
using WSPro.Backend.Domain.Validators.V1;

namespace WSPro.Backend.Domain.ServiceInstallers
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallDomainServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IValidator<Crane>, CraneValidator>();
            
            return serviceCollection;
        } 
    }
}