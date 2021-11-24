using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class CustomParamValue:EntityModificationDate, IEntity
    {
        public int ElementId { get; set; }
        public Element Element { get; set; }
        public CustomParams CustomParams { get; set; }
        public int CustomParamsId { get; set; }
        public string Value { get; set; }
    }
}