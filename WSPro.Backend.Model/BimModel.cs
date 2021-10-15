using System.Collections.Generic;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class BimModel : EntityModificationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelUrn { get; set; }
        public List<Element> Elements { get; set; } = new();
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public List<Level> Levels { get; set; } = new();
        public List<Crane> Cranes { get; set; } = new();
    }
}