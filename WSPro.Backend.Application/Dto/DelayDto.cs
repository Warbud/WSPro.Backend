using System;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateDelayDto(
        string Commentary,
        Entity User,
        Entity? Level,
        Entity? Crane,
        DateTime Date,
        Entity Project,
        Entity[] DelayCauses
            ):IDto<Delay>;
    
    public record UpdateDelayDto(
        string? Commentary,
        Entity? User,
        Entity? Level,
        Entity? Crane,
        DateTime? Date,
        Entity? Project,
        Entity[]? DelayCauses
    ):IDto<Delay>;
}