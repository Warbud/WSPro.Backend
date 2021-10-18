﻿using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class OtherWorksTimeEvidence : EntityModificationDate
    {
        public int Id { get; set; }
        public float WorkedTime { get; set; }
        public OtherWorkTypeEnum OtherWorkType { get; set; }
        public string Description { get; set; }
        public CrewWorkTypeEnum Type { get; set; }
        public OtherWorkOption OtherWorkOption { get; set; }
        public GroupedOtherWorkTimeEvidence GroupedOtherWorkTimeEvidence { get; set; }
    }
}