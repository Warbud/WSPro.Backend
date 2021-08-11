using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Model
{
    public class OtherWorkOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CrewTypeEnum CrewType { get; set; }
        public WorkerTypeEnum WorkType { get; set; }
    }
}