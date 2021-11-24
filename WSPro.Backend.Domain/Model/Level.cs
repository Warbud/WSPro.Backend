using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class Level : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BimModel> Models { get; set; }
    }
}