using System.Collections.Generic;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class BimModel : EntityModificationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelUrn { get; set; }
        public ICollection<Element> Elements { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public ICollection<Level> Levels { get; set; }
        public ICollection<Crane> Cranes { get; set; } 
    }
}