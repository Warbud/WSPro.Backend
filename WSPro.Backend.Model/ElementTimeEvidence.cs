using System;
using System.Collections.Generic;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class ElementTimeEvidence : EntityModificationDate
    {
        public int Id { get; set; }
        public List<Element> Elements { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public Crew Crew { get; set; }
        public float WorkedTime { get; set; }
    }
}