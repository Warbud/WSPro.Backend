using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class WorkerTimeEvidenceMapper
    {
        public static TypeAdapterConfig AddWorkerTimeEvidenceMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, WorkerTimeEvidence>()
                .TwoWays().IgnoreNullValues(true)
                .Map(e => e.Id, e => e.id);

            config.NewConfig<WorkerTimeEvidence, CreateWorkerTimeEvidenceDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Date, e => e.Date)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.User.id, e => e.UserId)
                .Map(e => e.Worker, e => e.Worker)
                .Map(e => e.CrewSummary, e => e.CrewSummary)
                .Map(e => e.WorkedTime, e => e.WorkedTime)
                ;
            config.NewConfig<WorkerTimeEvidence, UpdateWorkerTimeEvidenceDto>()
                .TwoWays()
                .IgnoreNullValues(true)
                .Map(e => e.Date, e => e.Date)
                .Map(e => e.Project, e => e.Project)
                .Map(e => e.User.id, e => e.UserId)
                .Map(e => e.Worker, e => e.Worker)
                .Map(e => e.CrewSummary, e => e.CrewSummary)
                .Map(e => e.WorkedTime, e => e.WorkedTime)
                ;
            return config;
        }
        
    }
}