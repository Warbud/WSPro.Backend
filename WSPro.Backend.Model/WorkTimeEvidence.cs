using System;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class WorkTimeEvidence : EntityModificationDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Worker Worker { get; set; }
        public User CreateBy { get; set; }
        public Project Project { get; set; }
        public float WorkedTime { get; set; }
        public CrewSummary CrewSummary { get; set; }
    }
}