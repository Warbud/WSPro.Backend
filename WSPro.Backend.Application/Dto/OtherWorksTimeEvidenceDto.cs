using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Application.Dto
{
    public record CreateOtherWorksTimeEvidenceDto(
        decimal WorkedTime,
        OtherWorkTypeEnum OtherWorkType,
        string? Description,
        CrewWorkTypeEnum Type,
        Entity OtherWorkOption,
        Entity? GroupedOtherWorkTimeEvidence
        ):IDto<OtherWorksTimeEvidence>;
    public record UpdateOtherWorksTimeEvidenceDto(
        decimal? WorkedTime,
        OtherWorkTypeEnum? OtherWorkType,
        string? Description,
        CrewWorkTypeEnum? Type,
        Entity? OtherWorkOption,
        Entity? GroupedOtherWorkTimeEvidence
    ):IDto<OtherWorksTimeEvidence>;
}