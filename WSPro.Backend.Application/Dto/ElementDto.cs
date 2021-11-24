using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Application.Dto
{
    public record CreateElementDto(
        decimal? Area,
        decimal? Volume,
        decimal? RunningMetre,
        int RevitId,
        VerticalEnum? Vertical,
        string? RealisationMode,
        int? RotationDay,
        Entity? Level,
        Entity? Crane,
        Entity Project,
        string? Details,
        bool IsPrefabricated,
        Entity? BimModel
    ):IDto<Element>;

    public record UpdateElementDto(
        decimal? Area,
        decimal? Volume,
        decimal? RunningMetre,
        int? RevitId,
        VerticalEnum? Vertical,
        string? RealisationMode,
        int? RotationDay,
        Entity? Level,
        Entity? Crane,
        Entity? Project,
        string? Details,
        bool? IsPrefabricated,
        Entity? BimModel
    ):IDto<Element>;
}