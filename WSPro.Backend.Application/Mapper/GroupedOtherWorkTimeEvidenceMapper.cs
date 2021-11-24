using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public  static class GroupedOtherWorkTimeEvidenceMapper
    {
        public static TypeAdapterConfig AddGroupedOtherWorkTimeEvidenceMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, GroupedOtherWorkTimeEvidence>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<GroupedOtherWorkTimeEvidence, CreateGroupedOtherWorkTimeEvidenceDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Crew, e => e.Crew)
                .Map(e => e.Date, e => e.Date)
                .Map(e => e.Level, e => e.Level)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.CrewType, e => e.CrewType)
                ;
            config.NewConfig<GroupedOtherWorkTimeEvidence, UpdateGroupedOtherWorkTimeEvidenceDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Crew, e => e.Crew)
                .Map(e => e.Date, e => e.Date)
                .Map(e => e.Level, e => e.Level)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.CrewType, e => e.CrewType)
                ;
            
            return config;
        }
        
    }
}