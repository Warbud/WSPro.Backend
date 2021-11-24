using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class ElementMapper
    {
        public static TypeAdapterConfig AddElementMappings(this TypeAdapterConfig config)
        {
            
            config.NewConfig<Entity, Element>().TwoWays().Map(entity => entity.Id, e => e.id).IgnoreNullValues(true);
            
            config.NewConfig<Element, CreateElementDto>()
                .TwoWays()
                .Map(dto => dto.Area, project => project.Area)
                .Map(dto => dto.Volume, project => project.Volume)
                .Map(dto => dto.RunningMetre, project => project.RunningMetre)
                .Map(dto => dto.RevitId, project => project.RevitId)
                .Map(dto => dto.Vertical, project => project.Vertical)
                .Map(dto => dto.RealisationMode, project => project.RealisationMode)
                .Map(dto => dto.RotationDay, project => project.RotationDay)
                .Map(dto => dto.Level, project => project.Level)
                .Map(dto => dto.Crane, project => project.Crane)
                .Map(dto => dto.Project, project => project.Project)
                .Map(dto => dto.Details, project => project.Details)
                .Map(dto => dto.IsPrefabricated, project => project.IsPrefabricated)
                .Map(dto => dto.BimModel, project => project.BimModel).IgnoreNullValues(true);

            config.NewConfig<UpdateElementDto,Element>()
                .Map( project => project.Area,dto => dto.Area)
                .Map( project => project.Volume,dto => dto.Volume)
                .Map( project => project.RunningMetre,dto => dto.RunningMetre)
                .Map( project => project.RevitId,dto => dto.RevitId)
                .Map( project => project.Vertical,dto => dto.Vertical)
                .Map( project => project.RealisationMode,dto => dto.RealisationMode)
                .Map( project => project.RotationDay,dto => dto.RotationDay)
                // .Map( project => project.Level,dto => dto.Level)
                // .Map( project => project.Crane,dto => dto.Crane)
                .Map( project => project.Project,dto => dto.Project)
                .Map( project => project.Details,dto => dto.Details)
                .Map( project => project.IsPrefabricated,dto => dto.IsPrefabricated)
                // .Map( project => project.BimModel,dto => dto.BimModel)
                .IgnoreNonMapped(true)
                .IgnoreNullValues(true)
                .AfterMapping((dto, element) =>
                {
                    if (dto.Level is not null)
                    {
                        element.LevelId = dto.Level.id == -1 ? null : dto.Level.id;
                    }

                    if (dto.Crane is not null)
                    {
                        element.CraneId = dto.Crane.id == -1 ? null : dto.Crane.id;
                    }

                    if (dto.BimModel is not null)
                    {
                        element.BimModelId = dto.BimModel.id == -1 ? null : dto.BimModel.id;
                    }
                });

            return config;
        }
    }
}