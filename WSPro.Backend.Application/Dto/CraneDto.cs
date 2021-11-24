using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateCraneDto(
        string Name
    ):IDto<Crane>;

    public record UpdateCraneDto(
        string Name
    ):IDto<Crane>;
}