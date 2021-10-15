using System;
using System.Collections.Generic;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
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
        private int CraneId { get; set; }
        public Project Project { get; set; }
        private int ProjectId { get; set; }
        public Level Level { get; set; }
        private int LevelId { get; set; }
        public User User { get; set; }
        private int UserId { get; set; }
        public List<Element> Elements { get; set; } = new();
    }
}