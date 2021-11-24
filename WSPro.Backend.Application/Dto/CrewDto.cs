using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Application.Dto
{

    public record CreateCrewDto(
        string Name, 
        Entity Owner,
        Entity Project, 
        CrewWorkTypeEnum CrewWorkType):IDto<Crew>;

    public record UpdateCrewDto( 
        string? Name, 
        Entity? Owner,
        Entity? Project, 
        CrewWorkTypeEnum? CrewWorkType):IDto<Crew>;
}