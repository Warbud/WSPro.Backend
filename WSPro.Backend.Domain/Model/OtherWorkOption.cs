using System;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model
{
    public class OtherWorkOption : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CrewTypeEnum CrewType { get; set; }
        public CrewWorkTypeEnum CrewWorkType { get; set; }
    }
}