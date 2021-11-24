using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class CommentaryElement : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public Element Element { get; set; }
        public int ElementId { get; set; }
        public User WriteBy { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}