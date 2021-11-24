﻿using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Mapper;

namespace WSPro.Backend.Application
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallApplicationServices(this IServiceCollection serviceCollection)
        {
            var config = new TypeAdapterConfig();

            config                
                .AddBimModelMappings()
                .AddCommentaryElementMappings()
                .AddCraneMappings()
                .AddCrewMappings()
                .AddCrewSummaryMappings()
                .AddDelayCauseMappings()
                .AddDelayMappings()
                .AddElementMappings()
                .AddElementStatusMappings()
                .AddElementsTimeEvidenceMappings()
                .AddElementTermMappings()
                .AddGroupedOtherWorkTimeEvidenceMappings()
                .AddGroupTermMappings()
                .AddLevelMappings()
                .AddOtherWorkOptionMappings()
                .AddOtherWorksTimeEvidenceMappings()
                .AddProjectMappings()
                .AddUserMappings()
                .AddWorkerMappings()
                .AddWorkerTimeEvidenceMappings()
                ;

            serviceCollection.AddSingleton(config)
                .AddScoped<IMapper, ServiceMapper>();

            return serviceCollection;
        }
    }
}