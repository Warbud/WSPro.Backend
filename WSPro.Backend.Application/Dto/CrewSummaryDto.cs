using System;
using System.Collections.Generic;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateCrewSummaryDto(Entity Crew, DateTime StartDate, DateTime EndDate, Entity User,Entity Project, List<Entity> Workers):IDto<CrewSummary>;

    public record UpdateCrewSummaryDto(Entity? Crew, DateTime? StartDate, DateTime? EndDate, Entity? User,Entity? Project, List<Entity>? Workers):IDto<CrewSummary>;
}