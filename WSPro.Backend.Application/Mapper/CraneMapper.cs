using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class CraneMapper
    {
        public static TypeAdapterConfig AddCraneMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, Crane>().TwoWays().Map(entity => entity.Id, e => e.id).IgnoreNullValues(true);

            config.NewConfig<Crane, CreateCraneDto>()
                .TwoWays()
                .Map(dto => dto.Name, crane => crane.Name)
                .IgnoreNullValues(true)
                ;
            config.NewConfig<Crane, UpdateCraneDto>()
                .TwoWays()
                .Map(dto => dto.Name, crane => crane.Name)
                .IgnoreNullValues(true)
                ;
            return config;
        }
    }
}