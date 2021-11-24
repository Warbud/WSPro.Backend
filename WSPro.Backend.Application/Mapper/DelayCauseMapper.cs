using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class DelayCauseMapper
    {
        public static TypeAdapterConfig AddDelayCauseMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, DelayCause>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<DelayCause, CreateDelayCauseDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e=>e.Name,e=>e.Name)
                .Map(e=>e.Parent,e=>e.Parent)
                .Map(e=>e.IsMain,e=>e.IsMain)
                ;
            config.NewConfig<UpdateDelayCauseDto,DelayCause>()
                .IgnoreNullValues(true)
                .Map(e=>e.Name,e=>e.Name)
                .Map(e=>e.IsMain,e=>e.IsMain)
                .IgnoreNonMapped(true)
                .AfterMapping((dto, cause) =>
                {
                    if (dto.Parent is not null)
                    { 
                        cause.DelayCauseId = dto.Parent.id == -1 ?  null : dto.Parent.id;
                    }
                })
                ;

            return config;
        }
    }
}