using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSPro.Backend.Domain.Model.V1.General
{
    public class EntityModificationDate
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}