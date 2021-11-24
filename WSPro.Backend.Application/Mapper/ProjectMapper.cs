using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class ProjectMapper
    {
        public static TypeAdapterConfig AddProjectMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, Project>().TwoWays().Map(entity => entity.Id, e => e.id).IgnoreNullValues(true);


            config.NewConfig<Project, CreateProjectDto>()
                .TwoWays()
                .Map(dto => dto.Name, project => project.Name)
                .Map(dto => dto.WebconCode, project => project.WebconCode)
                .Map(dto => dto.CentralScheduleSync, project => project.CentralScheduleSync)
                .Map(dto => dto.MetodologyCode, project => project.MetodologyCode)
                .Map(dto => dto.SupportedStatuses, project => project.SupportedStatuses)
                .Map(dto => dto.SupportedModules, project => project.SupportedModules)
                .IgnoreNullValues(true)
                ;

            config.NewConfig<Project, UpdateProjectDto>()
                .TwoWays()
                .Map(dto => dto.Name, project => project.Name)
                .Map(dto => dto.WebconCode, project => project.WebconCode)
                .Map(dto => dto.CentralScheduleSync, project => project.CentralScheduleSync)
                .Map(dto => dto.MetodologyCode, project => project.MetodologyCode)
                .Map(dto => dto.SupportedStatuses, project => project.SupportedStatuses)
                .Map(dto => dto.SupportedModules, project => project.SupportedModules)
                .IgnoreNullValues(true)
                ;
            return config;
        }
    }
}