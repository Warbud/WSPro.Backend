using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class BimModel : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelUrn { get; set; }
        public string? DefaultViewName { get; set; }
        public ICollection<Element> Elements { get; set; } = new List<Element>();
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public ICollection<Level> Levels { get; set; } = new List<Level>();
        public ICollection<BimModel_Level> BimModelsLevels { get; set; } = new List<BimModel_Level>();
        public ICollection<Crane> Cranes { get; set; } = new List<Crane>();
        public ICollection<BimModel_Crane> BimModelsCranes { get; set; } = new List<BimModel_Crane>();
        
    }
}