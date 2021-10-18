using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.GraphQL.Element
{
    public record CreateElementInput(
        decimal? Area,
        decimal? Volume,
        decimal? RunningMetre,
        int RevitId,
        VerticalEnum? Vertical,
        string? RealisationMode,
        int? RotationDay,
        int? LevelId,
        int? CraneId,
        int ProjectId
        );
}