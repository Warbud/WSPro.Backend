using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class CrewMapper
    {
        public static TypeAdapterConfig AddCrewMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, Crew>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<Crew, CreateCrewDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Name, e => e.Name)
                .Map(e => e.Owner, e => e.Owner)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.CrewWorkType, e => e.CrewWorkType)
                ;
            
            config.NewConfig<Crew, UpdateCrewDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Name, e => e.Name)
                .Map(e => e.Owner, e => e.Owner)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.CrewWorkType, e => e.CrewWorkType)
                ;
            
            return config;
        }
    }
}