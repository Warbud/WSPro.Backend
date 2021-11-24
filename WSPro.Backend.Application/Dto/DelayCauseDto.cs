using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateDelayCauseDto(
        string Name,
        bool IsMain,
        Entity? Parent
    ):IDto<DelayCause>;
    public record UpdateDelayCauseDto(
        string? Name,
        bool? IsMain,
        Entity? Parent):IDto<DelayCause>;
}