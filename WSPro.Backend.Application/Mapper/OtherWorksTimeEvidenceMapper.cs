using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class OtherWorksTimeEvidenceMapper
    {
        public static TypeAdapterConfig AddOtherWorksTimeEvidenceMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, OtherWorksTimeEvidence>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<OtherWorksTimeEvidence, CreateOtherWorksTimeEvidenceDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Description, e => e.Description)
                .Map(e => e.Type, e => e.Type)
                .Map(e => e.WorkedTime, e => e.WorkedTime)
                .Map(e => e.OtherWorkOption, e => e.OtherWorkOption)
                .Map(e => e.OtherWorkType, e => e.OtherWorkType)
                .Map(e => e.GroupedOtherWorkTimeEvidence, e => e.GroupedOtherWorkTimeEvidence)
                ;
            config.NewConfig<OtherWorksTimeEvidence, UpdateOtherWorksTimeEvidenceDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Description, e => e.Description)
                .Map(e => e.Type, e => e.Type)
                .Map(e => e.WorkedTime, e => e.WorkedTime)
                .Map(e => e.OtherWorkOption, e => e.OtherWorkOption)
                .Map(e => e.OtherWorkType, e => e.OtherWorkType)
                .Map(e => e.GroupedOtherWorkTimeEvidence, e => e.GroupedOtherWorkTimeEvidence)
                ;
            return config;
        }
        
    }
}