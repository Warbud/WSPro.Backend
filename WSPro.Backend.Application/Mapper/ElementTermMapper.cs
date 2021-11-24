using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class ElementTermMapper
    {
        public static TypeAdapterConfig AddElementTermMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, ElementTerm>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.ElementId, e => e.id);
            // .Map(e => e.Element.Id, e => e.id);

            config.NewConfig<ElementTerm,CreateElementTermDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e=>e.Element,e=>e.Element)
                .Map(e=>e.Element.id,e=>e.ElementId)
                .Map(e=>e.PlannedFinish,e=>e.PlannedFinish)
                .Map(e=>e.PlannedStart,e=>e.PlannedStart)
                .Map(e=>e.RealFinish,e=>e.RealFinish)
                .Map(e=>e.RealStart,e=>e.RealStart)
                .Map(e=>e.PlannedFinishBP,e=>e.PlannedFinishBP)
                .Map(e=>e.PlannedStartBP,e=>e.PlannedStartBP)
                ;
            
            config.NewConfig<ElementTerm,UpdateElementTermDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e=>e.PlannedFinish,e=>e.PlannedFinish)
                .Map(e=>e.PlannedStart,e=>e.PlannedStart)
                .Map(e=>e.RealFinish,e=>e.RealFinish)
                .Map(e=>e.RealStart,e=>e.RealStart)
                .Map(e=>e.PlannedFinishBP,e=>e.PlannedFinishBP)
                .Map(e=>e.PlannedStartBP,e=>e.PlannedStartBP)
                ;


            return config;
        }
    }
}