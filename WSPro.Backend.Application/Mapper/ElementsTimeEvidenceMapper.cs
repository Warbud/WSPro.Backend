using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class ElementsTimeEvidenceMapper
    {
        public static TypeAdapterConfig AddElementsTimeEvidenceMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, ElementsTimeEvidence>()
                .TwoWays().IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<Entity, Element_ElementsTimeEvidence>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.ElementId, e => e.id);
            
            config.NewConfig<ElementsTimeEvidence, CreateElementsTimeEvidenceDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Crew, e => e.Crew)
                .Map(e => e.Date, e => e.Date)
                .Map(e => e.Elements, e => e.Elements)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.User.id, e => e.UserId)
                .Map(e => e.WorkedTime, e => e.WorkedTime);

            config.NewConfig<UpdateElementsTimeEvidenceDto,ElementsTimeEvidence>()
                .IgnoreNullValues(true)
                .Map(e => e.Crew,e => e.Crew)
                .Map(e => e.Date,e => e.Date)
                // .Map(e => e.Elements,e => e.Elements)
                .Map(e => e.Project,e => e.Project)
                .Map(e => e.UserId,e => e.User.id)
                .Map(e => e.WorkedTime,e => e.WorkedTime)
                .Ignore(e=>e.Elements)
                .Ignore(e=>e.ElementElementsTimeEvidence)
                .IgnoreNonMapped(true);
            return config;
        }
    }
}