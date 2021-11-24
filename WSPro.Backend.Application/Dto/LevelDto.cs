using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateLevelDto(
        string Name
    ):IDto<Level>;

    public record UpdateLevelDto(
        string Name
    ):IDto<Level>;
}