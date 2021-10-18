using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Worker : EntityModificationDate
    {
        public int Id { get; set; }
        public CrewWorkTypeEnum? CrewWorkType { get; set; }
        protected bool IsHouseWorker { get; set; }
        public User AddedBy { get; set; }
        private int? AddedById { get; set; }
        public List<CrewSummary> CrewSummaries { get; set; } = new();
    }


    public class HouseWorker : Worker
    {
        public HouseWorker()
        {
            IsHouseWorker = true;
        }

        [Required] public string WarbudID { get; set; }
    }


    public class ExternalWorker : Worker
    {
        public ExternalWorker() 
        {
            IsHouseWorker = false;
        }

        [Required] public string Name { get; set; }
    }
}