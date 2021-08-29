using WSPro.Backend.Model.Enums;
using WSPro.Backend.Model.General;

namespace WSPro.Backend.Model
{
    public class OtherWorkOption:EntityModificationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CrewTypeEnum CrewType { get; set; }
        public CrewWorkTypeEnum CrewWorkType { get; set; }
    }
}