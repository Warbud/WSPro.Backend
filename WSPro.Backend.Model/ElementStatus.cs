using System;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Model
{
    public class ElementStatus
    {
        public int Id { get; set; }
        public Element Element { get; set; }
        public DateTime Date { get; set; }
        public StatusEnum Status { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public ElementStatus PreviousStatus { get; set; }
        public bool IsActual { get; set; }
    }
}