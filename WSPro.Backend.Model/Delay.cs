using System;
using System.Collections.Generic;

namespace WSPro.Backend.Model
{
    public class Delay
    {
        
        public int Id { get; set; }
        /// <summary>
        /// Text description about delay
        /// </summary>
        public string Commentary { get; set; }
        /// <summary>
        /// user 
        /// </summary>
        public User User { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// list of delay causes associated with current delay
        /// </summary>
        public List<DelayCause> DelayCauses { get; set; } = new List<DelayCause>();
        /// <summary>
        /// level when delay 
        /// </summary>
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public Crane Crane { get; set; }
        public int CraneId { get; set; }
        public DateTime Date { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}