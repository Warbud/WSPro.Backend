using System;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Application.Dto
{
    public record CreateGroupedOtherWorkTimeEvidenceDto(
        Entity Crew,
        Entity Project, 
        Entity Level, 
        DateTime Date, 
        CrewTypeEnum CrewType):IDto<GroupedOtherWorkTimeEvidence>;
    public record UpdateGroupedOtherWorkTimeEvidenceDto(
        Entity? Crew,
        Entity? Project, 
        Entity? Level, 
        DateTime? Date, 
        CrewTypeEnum? CrewType):IDto<GroupedOtherWorkTimeEvidence>;
}