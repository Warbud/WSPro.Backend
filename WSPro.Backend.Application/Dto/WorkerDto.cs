using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Application.Dto
{
    public record CreateWorkerDto(
        CrewWorkTypeEnum? CrewWorkType,
        Entity User,
        string? WarbudId,
        string? Name
        ):IDto<Worker>;

    // public record CreateHouseWorkerDto(Entity User,string WarbudId);
    // public record CreateExternalWorkerDto(Entity User,string Name);
    
    public record UpdateWorkerDto(
        CrewWorkTypeEnum? CrewWorkType,
        Entity? User,
        string? WarbudId,
        string? Name
        ):IDto<Worker>;
}