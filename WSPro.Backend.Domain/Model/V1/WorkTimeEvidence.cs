using System;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
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