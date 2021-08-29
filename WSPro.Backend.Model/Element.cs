using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSPro.Backend.Model.Enums;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class Element:EntityModificationDate
    {
        [Required]
        public int Id { get; set; }
        public decimal? Area { get; set; }
        public decimal? Volume { get; set; }
        public decimal? RunningMetre { get; set; }
        [Required]
        public int RevitID { get; set; }
        public VerticalEnum? Vertical { get; set; }
        public string? RealisationMode { get; set; }
        public int? RotationDay { get; set; }
        public Level Level { get; set; }
        public int? LevelID { get; set; }
        public Crane Crane { get; set; }
        public int? CraneID { get; set; }
        public List<ElementStatus> ElementStatusList { get; set; } = new List<ElementStatus>();
        [Required]
        public Project Project { get; set; }

        public int ProjectID { get; set; }
    }
}