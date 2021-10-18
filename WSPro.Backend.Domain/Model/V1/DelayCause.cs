using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class DelayCause : EntityModificationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public DelayCause Parent { get; set; }
        public int? ParentId { get; set; }

    }
}