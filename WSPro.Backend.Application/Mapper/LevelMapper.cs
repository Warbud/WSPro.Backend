using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class LevelMapper
    {
        public static TypeAdapterConfig AddLevelMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, Level>().TwoWays().Map(entity => entity.Id, e => e.id).IgnoreNullValues(true);

            
            config.NewConfig<Level, CreateLevelDto>()
                .TwoWays()
                .Map(dto => dto.Name, level => level.Name);

            config.NewConfig<Level, UpdateCraneDto>()
                .TwoWays()
                .Map(dto => dto.Name, level => level.Name);

            return config;
        }
    }
}