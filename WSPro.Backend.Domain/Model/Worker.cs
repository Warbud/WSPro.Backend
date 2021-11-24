using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model
{
    public class Worker : EntityModificationDate, IEntity
    {
        private string? _warbudId;
        public int Id { get; set; }
        public CrewWorkTypeEnum? CrewWorkType { get; set; }
        public bool IsHouseWorker { get; internal set; }
        public User? AddedBy { get; set; }
        public int? UserId { get; set; }

        public string? WarbudId
        {
            get => _warbudId;
            set
            {
                IsHouseWorker = value != null;
                _warbudId = value;
            }
        }

        public string? Name { get; set; }

        public ICollection<CrewSummary> CrewSummaries { get; set; } = new List<CrewSummary>();
        public ICollection<WorkerTimeEvidence> TimeEvidences { get; set; } = new List<WorkerTimeEvidence>();
    }
}