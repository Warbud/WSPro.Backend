using System;
using System.Collections.Generic;

namespace WSPro.Backend.Model
{
    /// <summary>
    /// Crew summary in given time period
    /// </summary>
    public class CrewSummary
    {
        public int Id { get; set; }
        public Crew Crew { get; set; }
        public int CrewId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}