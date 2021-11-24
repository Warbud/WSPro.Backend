using System.Collections.Generic;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateProjectDto(
        string Name,
        string? WebconCode,
        string? MetodologyCode,
        List<StatusEnum> SupportedStatuses,
        List<AppEnum> SupportedModules,
        bool CentralScheduleSync = false
    ) : IDto<Project>;

    public record UpdateProjectDto(
        string? Name,
        string? WebconCode,
        string? MetodologyCode,
        List<StatusEnum>? SupportedStatuses,
        List<AppEnum>? SupportedModules,
        bool? CentralScheduleSync
    ) : IDto<Project>;
}