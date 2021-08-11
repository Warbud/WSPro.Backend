using System;
using System.Collections.Generic;

namespace WSPro.Backend.Model
{
    public class Term
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
        public Project Project { get; set; }
        public Level Level { get; set; }
        public User User { get; set; }
        public List<Element> Elements { get; set; }
        
    }
}