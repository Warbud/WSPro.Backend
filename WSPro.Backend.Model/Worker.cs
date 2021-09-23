using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSPro.Backend.Model.Enums;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class Worker:EntityModificationDate
    {
        public int Id { get; set; }
        public CrewWorkTypeEnum? CrewWorkTypeEnum { get; set; }
        protected bool IsHouseWorker { get; set; }
        public User AddedBy { get; set; }
        private int? AddedById { get; set; }
        public List<CrewSummary> CrewSummaries { get; set; } = new List<CrewSummary>();

        public Worker()
        {
            
        }

        public Worker(CrewWorkTypeEnum? crewWorkTypeEnum)
        {
            CrewWorkTypeEnum = crewWorkTypeEnum;
        }
    }

    
    
    
    public class HouseWorker:Worker
    {
        [Required]
        public string WarbudID { get; set; }

        public HouseWorker(string warbudID,CrewWorkTypeEnum crewWorkTypeEnum):base(crewWorkTypeEnum)
        {
            WarbudID = warbudID;
            IsHouseWorker = true;
        }
    }

    
    
    
    public class ExternalWorker : Worker
    {
        [Required]
        public string Name { get; set; }

        public ExternalWorker(string name,CrewWorkTypeEnum crewWorkTypeEnum):base(crewWorkTypeEnum)
        {
            Name = name;
            IsHouseWorker = false;
        }
    }
}