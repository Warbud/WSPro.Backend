using System;

namespace WSPro.Backend.Domain.Model.V1.General
{
    public class EntityModificationDate
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}