using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Crew : EntityModificationDate
    {
        // private Crew()
        // {
        // }
        //
        // public Crew(string name, CrewWorkTypeEnum crewWorkType, CrewTypeEnum crewType)
        // {
        //     CrewWorkType = crewWorkType;
        //     CrewType = crewType;
        //     Name = name;
        // }

        /// <summary>
        ///     Id of Crew
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Name of Crew. Creator pass name to identify Crew in client App.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Owner of Crew
        /// </summary>
        public User User { get; set; }

        private int? UserId { get; set; }

        /// <summary>
        ///     Project where crew is working
        /// </summary>
        public Project Project { get; set; }

        private int? ProjectId { get; set; }

        /// <summary>
        ///     Parameter qualified Crew as Steel Fixer Crew, Carpenter or other.
        /// </summary>
        public CrewWorkTypeEnum CrewWorkType { get; set; }

        /// <summary>
        ///     Parameter qualified Crew as House or Subcontractor Crew
        /// </summary>
        public CrewTypeEnum CrewType { get; set; }
    }
}