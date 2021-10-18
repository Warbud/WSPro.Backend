using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Delay : EntityModificationDate
    {
        public int Id { get; set; }
        public string Commentary { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<DelayCause> DelayCauses { get; set; } 
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public Crane Crane { get; set; }
        public int CraneId { get; set; }
        [DataType(DataType.Date)] public DateTime Date { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}