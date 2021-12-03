using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class WorkerMapper
    {
        public static TypeAdapterConfig AddWorkerMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, Worker>()
                .TwoWays()
                .Map(e => e.Id, e => e.id)
                .IgnoreNullValues(true);

            config.NewConfig<Worker, CreateWorkerDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Name, e => e.Name)
                .Map(e => e.User.id, e => e.UserId)
                .Map(e => e.WarbudId, e => e.WarbudId)
                .Map(e => e.CrewWorkType, e => e.CrewWorkType)
                ;
            
            
            config.NewConfig<Worker, UpdateWorkerDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Name, e => e.Name)
                .Map(e => e.User.id, e => e.UserId)
                .Map(e => e.WarbudId, e => e.WarbudId)
                .Map(e => e.CrewWorkType, e => e.CrewWorkType)
                ;
            
            return config;
        }
    }
}