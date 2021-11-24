using System;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateElementTermDto(
        Entity Element,
        DateTime? PlannedStart,
        DateTime? PlannedFinish,
        DateTime? PlannedStartBP,
        DateTime? PlannedFinishBP,
        DateTime? RealStart,
        DateTime? RealFinish
    ):IDto<ElementTerm>;

    public record UpdateElementTermDto(
        DateTime? PlannedStart,
        DateTime? PlannedFinish,
        DateTime? PlannedStartBP,
        DateTime? PlannedFinishBP,
        DateTime? RealStart,
        DateTime? RealFinish
    ):IDto<ElementTerm>;
}