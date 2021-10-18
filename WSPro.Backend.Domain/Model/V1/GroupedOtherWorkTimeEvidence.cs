using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class GroupedOtherWorkTimeEvidence : EntityModificationDate
    {
        public int Id { get; set; }
        public Crew Crew { get; set; }
        public Project Project { get; set; }
        public Level Level { get; set; }
        public DateTime Date { get; set; }
        public CrewTypeEnum CrewType { get; set; }
        public List<OtherWorksTimeEvidence> OtherWorksTimeEvidences { get; set; }
    }
}