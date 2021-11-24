using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class Delay_DelayCause : EntityModificationDate, IEntity
    {
        public DelayCause Cause { get; set; }
        public int DelayCauseId { get; set; }
        public Delay Delay { get; set; }
        public int DelayId { get; set; }
    }
}