using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Model
{
    public class OtherWorksTimeEvidence
    {
        public int Id { get; set; }
        public float WorkedTime { get; set; }
        public OtherWorkTypeEnum OtherWorkType { get; set; }
        public string Description { get; set; }
        public WorkerTypeEnum CrewType { get; set; }
        public OtherWorkOption OtherWorkOption { get; set; }
        public GroupedOtherWorkTimeEvidence GroupedOtherWorkTimeEvidence { get; set; }
    }
}