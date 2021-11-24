using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class OtherWorkOptionMapper
    {
        public static TypeAdapterConfig AddOtherWorkOptionMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, OtherWorkOption>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<OtherWorkOption, CreateOtherWorkOptionDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Name, e => e.Name)
                .Map(e => e.CrewType, e => e.CrewType)
                .Map(e => e.CrewWorkType, e => e.CrewWorkType);
            
            config.NewConfig<OtherWorkOption, UpdateOtherWorkOptionDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Name, e => e.Name)
                .Map(e => e.CrewType, e => e.CrewType)
                .Map(e => e.CrewWorkType, e => e.CrewWorkType);
            
            
            return config;
        }
    }
}