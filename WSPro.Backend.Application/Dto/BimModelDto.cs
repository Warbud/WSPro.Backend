using System.Collections.Generic;
using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateBimModelDto(
        string Name,
        string ModelUrn,
        string? DefaultViewName,
        Entity Project,
        List<Entity>? Levels,
        List<Entity>? Cranes) : IDto<BimModel>;

    public record UpdateBimModelDto(
        string? Name,
        string? ModelUrn,
        string? DefaultViewName,
        Entity? Project,
        List<Entity>? Levels,
        List<Entity>? Cranes
    ):IDto<BimModel>;
}