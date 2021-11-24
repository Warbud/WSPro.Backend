using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class Worker_CrewSummary : EntityModificationDate, IEntity
    {
        public Worker Worker { get; set; }
        public int WorkerId { get; set; }
        public CrewSummary CrewSummary { get; set; }
        public int CrewSummaryId { get; set; }
    }
}