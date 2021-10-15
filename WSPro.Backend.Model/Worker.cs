using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSPro.Backend.Model.Enums;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class Worker : EntityModificationDate
    {
        public Worker()
        {
        }

        public Worker(CrewWorkTypeEnum? crewWorkType)
        {
            CrewWorkType = crewWorkType;
        }

        public int Id { get; set; }
        public CrewWorkTypeEnum? CrewWorkType { get; set; }
        protected bool IsHouseWorker { get; set; }
        public User AddedBy { get; set; }
        private int? AddedById { get; set; }
        public List<CrewSummary> CrewSummaries { get; set; } = new();
    }


    public class HouseWorker : Worker
    {
        public HouseWorker(string warbudID, CrewWorkTypeEnum crewWorkTypeEnum) : base(crewWorkTypeEnum)
        {
            WarbudID = warbudID;
            IsHouseWorker = true;
        }

        [Required] public string WarbudID { get; set; }
    }


    public class ExternalWorker : Worker
    {
        public ExternalWorker(string name, CrewWorkTypeEnum crewWorkTypeEnum) : base(crewWorkTypeEnum)
        {
            Name = name;
            IsHouseWorker = false;
        }

        [Required] public string Name { get; set; }
    }
}