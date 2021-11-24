using System;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Application.Dto
{
    public record CreateElementStatusDto(
        DateTime Date,
        StatusEnum Status,
        Entity Element,
        Entity User,
        Entity Project
    ):IDto<ElementStatus>;

    public record UpdateElementStatusDto(
        DateTime? Date,
        StatusEnum? Status,
        Entity? Element,
        Entity? User,
        Entity? Project
    ):IDto<ElementStatus>;
}