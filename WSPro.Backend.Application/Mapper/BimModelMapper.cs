using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class BimModelMapper
    {
        public static TypeAdapterConfig AddBimModelMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, BimModel>().TwoWays().Map(entity => entity.Id, e => e.id).IgnoreNullValues(true);

            config.NewConfig<Entity, BimModel_Level>().TwoWays().Map(e => e.LevelId, e => e.id).IgnoreNullValues(true);
            config.NewConfig<Entity, BimModel_Crane>().TwoWays().Map(e => e.CraneId, e => e.id).IgnoreNullValues(true);


            config.NewConfig<BimModel, CreateBimModelDto>()
                .TwoWays()
                .Map(dto => dto.Name, bimModel => bimModel.Name)
                .Map(dto => dto.ModelUrn, bimModel => bimModel.ModelUrn)
                .Map(dto => dto.DefaultViewName, bimModel => bimModel.DefaultViewName)
                .Map(dto => dto.Project, bimModel => bimModel.Project)
                .Map(dto => dto.Levels, bimModel => bimModel.Levels)
                .Map(dto => dto.Cranes, bimModel => bimModel.Cranes)
                .IgnoreNullValues(true);

            config.NewConfig<UpdateBimModelDto, BimModel>()
                .Map(bimModel => bimModel.Name, dto => dto.Name)
                .Map(bimModel => bimModel.ModelUrn, dto => dto.ModelUrn)
                .Map(bimModel => bimModel.DefaultViewName, dto => dto.DefaultViewName)
                .Map(bimModel => bimModel.Project, dto => dto.Project)
                // .Map(bimModel => bimModel.Cranes,dto => dto.Cranes)
                // .Map(bimModel => bimModel.BimModelsLevels,dto => dto.Levels)
                .Ignore(e => e.Levels)
                .Ignore(e => e.BimModelsLevels)
                .Ignore(e => e.Cranes)
                .Ignore(e => e.BimModelsCranes)
                // .AfterMapping((dto, model) =>
                // {
                //     foreach (var modelBimModelsLevel in model.BimModelsLevels)
                //     {
                //         modelBimModelsLevel.ModelId = model.Id;
                //     }
                // } )
                .IgnoreNullValues(true)
                ;


            return config;
        }
    }
}