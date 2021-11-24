using System;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class ElementTerm : EntityModificationDate, IEntity
    {
        public Element Element { get; set; }
        public int ElementId { get; set; }
        public DateTime? PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public DateTime? PlannedStartBP { get; set; }
        public DateTime? PlannedFinishBP { get; set; }
        public DateTime? RealStart { get; set; }
        public DateTime? RealFinish { get; set; }
        public GroupTerm? GroupTerm { get; set; }
        public int? GroupTermId { get; set; }
    }
}