using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model
{
    public class GroupedOtherWorkTimeEvidence : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public Crew Crew { get; set; }
        public int CrewId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public DateTime Date { get; set; }
        public CrewTypeEnum CrewType { get; set; }

        public ICollection<OtherWorksTimeEvidence> OtherWorksTimeEvidences { get; set; } =
            new List<OtherWorksTimeEvidence>();
    }
}