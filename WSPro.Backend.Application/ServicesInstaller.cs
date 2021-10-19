using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;
using WSPro.Backend.Application.Services;
using WSPro.Backend.Application.Validators.Crane;
using WSPro.Backend.Application.Validators.Level;

namespace WSPro.Backend.Application
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IValidator<CreateCraneDto>, CreateCraneDtoValidator>()
                .AddScoped<IValidator<CreateLevelDto>, CreateLevelDtoValidator>()
                .AddScoped<ICraneService, CraneService>()
                .AddScoped<ILevelService, LevelService>();
           
            return serviceCollection;
        } 
    }

}