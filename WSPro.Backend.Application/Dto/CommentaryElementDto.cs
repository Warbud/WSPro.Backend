using WSPro.Backend.Application.Helper;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Application.Dto
{
    public record CreateCommentaryElementDto(
        Entity Element,
        Entity User,
        string Content
        ):IDto<CommentaryElement>;

    public record UpdateCommentaryElementDto(
        Entity? Element,
        Entity? User,
        string? Content
    ):IDto<CommentaryElement>;
}