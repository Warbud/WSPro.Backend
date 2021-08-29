using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class DelayCause:EntityModificationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public DelayCause Parent { get; set; }
    }
}