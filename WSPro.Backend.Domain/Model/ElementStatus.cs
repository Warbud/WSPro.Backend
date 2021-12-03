using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class ElementStatus : EntityModificationDate, IEntity
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public StatusEnum Status { get; set; }
        public Element Element { get; set; }
        public int ElementId { get; set; }
        public string UserId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}