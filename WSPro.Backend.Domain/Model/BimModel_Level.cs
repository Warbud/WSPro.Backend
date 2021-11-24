using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class BimModel_Level : EntityModificationDate, IEntity
    {
        public Level Level { get; set; }
        public int LevelId { get; set; }
        public BimModel Model { get; set; }
        public int ModelId { get; set; }
    }
}