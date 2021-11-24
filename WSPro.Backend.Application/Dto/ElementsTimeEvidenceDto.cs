using System;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateElementsTimeEvidenceDto(
        Entity[] Elements,
        DateTime Date,
        Entity User,
        Entity Project,
        Entity Crew,
        decimal WorkedTime
    ):IDto<ElementsTimeEvidence>;

    public record UpdateElementsTimeEvidenceDto(
        Entity[]? Elements,
        DateTime? Date,
        Entity? User,
        Entity? Project,
        Entity? Crew,
        decimal? WorkedTime
    ):IDto<ElementsTimeEvidence>;
}