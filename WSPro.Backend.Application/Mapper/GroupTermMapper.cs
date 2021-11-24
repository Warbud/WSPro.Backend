using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class GroupTermMapper
    {
        public static TypeAdapterConfig AddGroupTermMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, GroupTerm>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<GroupTerm, CreateGroupTermDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Crane, e => e.Crane)
                .Map(e => e.Level, e => e.Level)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.Terms, e => e.Terms)
                .Map(e => e.Vertical, e => e.Vertical)
                .Map(e => e.PlannedFinish, e => e.PlannedFinish)
                .Map(e => e.PlannedStart, e => e.PlannedStart)
                .Map(e => e.RealFinish, e => e.RealFinish)
                .Map(e => e.RealStart, e => e.RealStart)
                .Map(e => e.PlannedFinishBP, e => e.PlannedFinishBP)
                .Map(e => e.PlannedStartBP, e => e.PlannedStartBP)
                ;

            config.NewConfig<GroupTerm, UpdateGroupTermDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Crane, e => e.Crane)
                .Map(e => e.Level, e => e.Level)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.Terms, e => e.Terms)
                .Map(e => e.Vertical, e => e.Vertical)
                .Map(e => e.PlannedFinish, e => e.PlannedFinish)
                .Map(e => e.PlannedStart, e => e.PlannedStart)
                .Map(e => e.RealFinish, e => e.RealFinish)
                .Map(e => e.RealStart, e => e.RealStart)
                .Map(e => e.PlannedFinishBP, e => e.PlannedFinishBP)
                .Map(e => e.PlannedStartBP, e => e.PlannedStartBP)
                ;

            return config;
        }
    }
}