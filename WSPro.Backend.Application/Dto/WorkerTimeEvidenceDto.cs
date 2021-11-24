using System;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateWorkerTimeEvidenceDto(
        DateTime Date,
        Entity Worker,
        Entity User,
        Entity Project,
        decimal WorkedTime,
        Entity CrewSummary
        ):IDto<WorkerTimeEvidence>;
    public record UpdateWorkerTimeEvidenceDto(
        DateTime? Date,
        Entity? Worker,
        Entity? User,
        Entity? Project,
        decimal? WorkedTime,
        Entity? CrewSummary
        ):IDto<WorkerTimeEvidence>;
}