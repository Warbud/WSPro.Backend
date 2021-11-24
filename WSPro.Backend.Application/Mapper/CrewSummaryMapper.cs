using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class CrewSummaryMapper
    {
        public static TypeAdapterConfig AddCrewSummaryMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, CrewSummary>()
                .TwoWays()
                .Map(e => e.Id, e => e.id)
                .IgnoreNullValues(true);

            config.NewConfig<CrewSummary, CreateCrewSummaryDto>()
                .TwoWays()
                .Map(e => e.Crew, e => e.Crew)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.User, e => e.CrewOwner)
                .Map(e => e.Workers, e => e.Workers)
                .Map(e => e.StartDate, e => e.StartDate)
                .Map(e => e.EndDate, e => e.EndDate)
                .IgnoreNullValues(true);
            
            config.NewConfig<CrewSummary, UpdateCrewSummaryDto>()
                .TwoWays()
                .Map(e => e.Crew, e => e.Crew)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.User, e => e.CrewOwner)
                .Map(e => e.Workers, e => e.Workers)
                .Map(e => e.StartDate, e => e.StartDate)
                .Map(e => e.EndDate, e => e.EndDate)
                .IgnoreNullValues(true);
            
            return config;
        }
    }
}