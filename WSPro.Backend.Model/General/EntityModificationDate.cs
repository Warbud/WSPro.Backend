using System;

namespace WSPro.Backend.Model.General
{
    public class EntityModificationDate
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public void UpdateDate()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}