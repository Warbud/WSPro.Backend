using System;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Application.Dto
{
    public record CreateGroupTermDto(
        VerticalEnum Vertical,
        DateTime? PlannedStart,
        DateTime? PlannedFinish,
        DateTime? PlannedStartBP,
        DateTime? PlannedFinishBP,
        DateTime? RealStart,
        DateTime? RealFinish,
        Entity? Crane,
        Entity? Level,
        Entity Project,
        Entity[] Terms
    ):IDto<GroupTerm>;

    public record UpdateGroupTermDto(
        VerticalEnum? Vertical,
        DateTime? PlannedStart,
        DateTime? PlannedFinish,
        DateTime? PlannedStartBP,
        DateTime? PlannedFinishBP,
        DateTime? RealStart,
        DateTime? RealFinish,
        Entity? Crane,
        Entity? Level,
        Entity? Project,
        Entity[]? Terms):IDto<GroupTerm>;
}