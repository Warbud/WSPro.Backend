using System.Collections.Generic;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Model
{
    public class Worker
    {
        public int Id { get; set; }
        public WorkerTypeEnum WorkerTypeEnum { get; set; }
        public  bool IsHouseWorker { get; set; }
        public User AddedBy { get; set; }
        public Crew Crew { get; set; }
        public List<CrewSummary> CrewSummaries { get; set; }
    }

    public class HouseWorker:Worker
    {
        public string WarbudID { get; set; }

        public HouseWorker()
        {
            IsHouseWorker = true;
        }
    }

    public class ExternalWorker : Worker
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ExternalWorker()
        {
            IsHouseWorker = false;
        }
    }
}