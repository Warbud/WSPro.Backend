using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class CrewSummary : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public Crew Crew { get; set; }
        public int CrewId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public ICollection<WorkerTimeEvidence> TimeEvidences { get; set; } = new List<WorkerTimeEvidence>();
        public ICollection<Worker> Workers { get; set; } = new List<Worker>();
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}