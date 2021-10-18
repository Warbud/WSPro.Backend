using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Term : EntityModificationDate
    {
        public int Id { get; set; }
        public string Vertical { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedFinish { get; set; }
        public DateTime PlannedStartBP { get; set; }
        public DateTime PlannedFinishBP { get; set; }
        public DateTime RealStart { get; set; }
        public DateTime RealFinish { get; set; }
        public Crane Crane { get; set; }
        public int CraneId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Element> Elements { get; set; }
    }
}