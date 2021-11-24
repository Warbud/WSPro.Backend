using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model
{
    public class GroupTerm : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public VerticalEnum Vertical { get; set; }
        public DateTime? PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public DateTime? PlannedStartBP { get; set; }
        public DateTime? PlannedFinishBP { get; set; }
        public DateTime? RealStart { get; set; }
        public DateTime? RealFinish { get; set; }
        public Crane? Crane { get; set; }
        public int? CraneId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public Level? Level { get; set; }
        public int? LevelId { get; set; }
        public ICollection<ElementTerm> Terms { get; set; } = new List<ElementTerm>();
    }
}