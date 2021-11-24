using System;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model
{
    public class OtherWorksTimeEvidence : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public decimal WorkedTime { get; set; }
        public OtherWorkTypeEnum OtherWorkType { get; set; }
        public string? Description { get; set; }
        public CrewWorkTypeEnum Type { get; set; }
        public OtherWorkOption OtherWorkOption { get; set; }
        public int OtherWorkOptionId { get; set; }
        public GroupedOtherWorkTimeEvidence? GroupedOtherWorkTimeEvidence { get; set; }
        public int? GroupedOtherWorkTimeEvidenceId { get; set; }
    }
}