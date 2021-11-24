using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class BimModel_Crane : EntityModificationDate, IEntity
    {
        public Crane Crane { get; set; }
        public int CraneId { get; set; }
        public BimModel Model { get; set; }
        public int ModelId { get; set; }
    }
}