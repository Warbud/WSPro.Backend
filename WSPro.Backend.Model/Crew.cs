using System.Collections.Generic;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Model
{
    public class Crew
    {
        /// <summary>
        /// Id of Crew
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of Crew. Creator pass name to identify Crew in client App.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Owner of Crew
        /// </summary>
        public User User { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// Project where crew is working
        /// </summary>
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        /// <summary>
        /// List of workers in Crew
        /// </summary>
        public List<Worker> Workers { get; set; } = new List<Worker>();
        /// <summary>
        /// Parameter qualified Crew as Steel Fixer Crew, Carpenter or other.
        /// </summary>
        public WorkerTypeEnum WorkerType { get; set; }
        /// <summary>
        /// Parameter qualified Crew as House or Subcontractor Crew
        /// </summary>
        public CrewTypeEnum CrewType { get; set; }
    }

}