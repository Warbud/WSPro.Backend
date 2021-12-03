using System;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class WorkerTimeEvidence : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Worker Worker { get; set; }
        public int WorkerId { get; set; }
        public string UserId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public decimal WorkedTime { get; set; }
        public CrewSummary CrewSummary { get; set; }
        public int CrewSummaryId { get; set; }
    }
}