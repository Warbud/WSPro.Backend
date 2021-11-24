using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class UserMapper
    {
        public static TypeAdapterConfig AddUserMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, User>().TwoWays().IgnoreNullValues(true).Map(e => e.Id, e => e.id);
            return config;
        }
    }
}