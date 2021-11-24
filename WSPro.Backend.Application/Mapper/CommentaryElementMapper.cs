using Mapster;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Mapper
{
    public static class CommentaryElementMapper
    {
        public static TypeAdapterConfig AddCommentaryElementMappings(this TypeAdapterConfig config)
        {
            config.NewConfig<Entity, CommentaryElement>()
                .TwoWays()
                .Map(e => e.Id, e => e.id)
                .IgnoreNullValues(true);

            config.NewConfig<CommentaryElement, CreateCommentaryElementDto>()
                .TwoWays()
                .Map(dto => dto.Content, data => data.Content)
                .Map(dto => dto.Element, data => data.Element)
                .Map(dto => dto.User, data => data.WriteBy)
                .IgnoreNullValues(true);

            config.NewConfig<CommentaryElement, UpdateCommentaryElementDto>()
                .TwoWays()
                .Map(dto => dto.Content, data => data.Content)
                .Map(dto => dto.Element, data => data.Element)
                .Map(dto => dto.User, data => data.WriteBy)
                .IgnoreNullValues(true);
            
            return config;
        }
    }
}