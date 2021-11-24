using System;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model
{
    public class Crew : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
        public int UserId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public CrewWorkTypeEnum CrewWorkType { get; set; }
    }
}