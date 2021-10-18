using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class ElementStatus : EntityModificationDate
    {
        // non relational attributes
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public StatusEnum Status { get; set; }
        // public bool IsActual { get; set; }


        // relational attributes
        public Element Element { get; set; }
        public User User { get; set; }
        private int? UserId { get; set; }
        public Project Project { get; set; }
        private int? ProjectId { get; set; }
        // public ElementStatus PreviousStatus { get; set; }
        // private int? PreviousStatusId { get; set; }

    }
}