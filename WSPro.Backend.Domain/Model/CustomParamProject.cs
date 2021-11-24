using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class CustomParamProject:EntityModificationDate, IEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public CustomParams CustomParams { get; set; }
        public int CustomParamsId { get; set; }
    }
}