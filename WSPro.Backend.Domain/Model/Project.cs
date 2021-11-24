using System.Collections.Generic;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class Project : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? WebconCode { get; set; }
        public string? MetodologyCode { get; set; }
        public bool CentralScheduleSync { get; set; }
        public IEnumerable<StatusEnum> SupportedStatuses { get; set; } = new List<StatusEnum>();
        public IEnumerable<AppEnum> SupportedModules { get; set; } = new List<AppEnum>();
        public ICollection<BimModel> Models { get; set; } = new List<BimModel>();
        public ICollection<CustomParamProject> CustomParamProject { get; set; } = new List<CustomParamProject>();
        public ICollection<CustomParams> CustomParams { get; set; } = new List<CustomParams>();
    }
}