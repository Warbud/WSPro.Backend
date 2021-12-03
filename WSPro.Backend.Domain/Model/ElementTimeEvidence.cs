using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class ElementsTimeEvidence : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public ICollection<Element> Elements { get; set; } = new List<Element>();
        public ICollection<Element_ElementsTimeEvidence> ElementElementsTimeEvidence { get; set; } = new List<Element_ElementsTimeEvidence>();
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public Crew Crew { get; set; }
        public int CrewId { get; set; }
        public decimal WorkedTime { get; set; }
    }
}