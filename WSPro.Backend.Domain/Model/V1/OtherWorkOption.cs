using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class OtherWorkOption : EntityModificationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CrewTypeEnum CrewType { get; set; }
        public CrewWorkTypeEnum CrewWorkType { get; set; }
    }
}