using System.Collections.Generic;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;

namespace WSPro.Backend.Domain.Model
{
    public class CustomParams:EntityModificationDate,IEntity
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public CustomParamsDataTypes Type { get; set; }
        public bool CanBeNull { get; set; }
        public string Description { get; set; }
        public bool IsCustom { get; set; }
        public ICollection<CustomParamProject> CustomParamProject { get; set; } = new List<CustomParamProject>();
        public ICollection<Project> Project { get; set; } = new List<Project>();
        public ICollection<CustomParamValue> CustomParamValue { get; set; } = new List<CustomParamValue>();

        public override bool Equals(object? obj)
        {
            return Id == (((CustomParams)obj!)!).Id;
        }
    }
}