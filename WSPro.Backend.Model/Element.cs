using System.Collections.Generic;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Model
{
    public class Element
    {
        public int Id { get; set; }
        public float Area { get; set; }
        public float Volume { get; set; }
        public float RunningMetre { get; set; }
        public int RevitID { get; set; }
        public string Vertical { get; set; }
        public string RealisationMode { get; set; }
        public int RotationDay { get; set; }
        public Level Level { get; set; }
        public Crane Crane { get; set; }
        public List<ElementStatus> ElementStatusList { get; set; }
        public Project Project { get; set; }
    }
}