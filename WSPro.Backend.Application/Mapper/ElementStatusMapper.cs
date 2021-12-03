using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class ElementStatusMapper
    {
        public static TypeAdapterConfig AddElementStatusMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, ElementStatus>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<ElementStatus, CreateElementStatusDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Date, e => e.Date)
                .Map(e => e.Element, e => e.Element)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.Status, e => e.Status)
                .Map(e => e.User.id, e => e.UserId);

            config.NewConfig<ElementStatus, UpdateElementStatusDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Date, e => e.Date)
                .Map(e => e.Element, e => e.Element)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.Status, e => e.Status)
                .Map(e => e.User.id, e => e.UserId);
            
            return config;
        }
    }
}