using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class DelayMapper
    {
        public static TypeAdapterConfig AddDelayMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, Delay>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<Entity, Delay_DelayCause>()
                .TwoWays()
                .Map(e => e.DelayCauseId, e => e.id)
                .IgnoreNullValues(true);
            
            config.NewConfig<Delay, CreateDelayDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Commentary, e => e.Commentary)
                .Map(e => e.Crane, e => e.Crane)
                .Map(e => e.Date, e => e.Date)
                .Map(e => e.Level, e => e.Level)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.User.id, e => e.UserId)
                .Map(e => e.DelayCauses, e => e.DelayCauses);

            config.NewConfig<UpdateDelayDto, Delay>()
                .IgnoreNullValues(true)
                .IgnoreNonMapped(true)
                .Map(e => e.Commentary, e => e.Commentary)
                // .Map(e => e.Crane,e => e.Crane)
                .Map(e => e.Date, e => e.Date)
                // .Map(e => e.Level,e => e.Level)
                // .Map(e => e.Project,e => e.Project)
                .Map(e => e.UserId,e => e.User.id)
                // .Map(e => e.DelayCauses, e => e.DelayCauses)
                .AfterMapping((dto, delay) =>
                {
                    if (dto.Crane is not null)
                        delay.CraneId = dto.Crane.id == -1 ? null : dto.Crane.id;

                    if (dto.Level is not null)
                        delay.LevelId = dto.Level.id == -1 ? null : dto.Level.id;
                    
                });

            return config;
        }
        
    }
}