using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class Delay : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public string Commentary { get; set; }
        public string UserId { get; set; }
        public Level? Level { get; set; }
        public int? LevelId { get; set; }
        public Crane? Crane { get; set; }
        public int? CraneId { get; set; }
        [DataType(DataType.Date)] public DateTime Date { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public ICollection<DelayCause> DelayCauses { get; set; } = new List<DelayCause>();
        public ICollection<Delay_DelayCause> DelayDelayCause { get; set; } = new List<Delay_DelayCause>();
    }
}