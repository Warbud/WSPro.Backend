using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class DelayCause : EntityModificationDate, IEntity
    {
        public DelayCause()
        {
        }

        public DelayCause(string name, DelayCause? parent = null)
        {
            Name = name;
            IsMain = parent == null;
            Parent = parent;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public DelayCause? Parent { get; set; }
        public int? DelayCauseId { get; set; }
        public ICollection<Delay> Delays { get; set; }
    }
}