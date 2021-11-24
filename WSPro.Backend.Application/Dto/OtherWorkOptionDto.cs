using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Application.Dto
{
    public record CreateOtherWorkOptionDto(
        string Name, 
        CrewTypeEnum CrewType, 
        CrewWorkTypeEnum CrewWorkType):IDto<OtherWorkOption>;
    public record UpdateOtherWorkOptionDto(
        string? Name, 
        CrewTypeEnum? CrewType, 
        CrewWorkTypeEnum? CrewWorkType):IDto<OtherWorkOption>;
}