using System;
using System.Collections.Generic;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model
{
    public class Element : EntityModificationDate, IEntity
    {
        public int Id { get; set; }
        public decimal? Area { get; set; }
        public decimal? Volume { get; set; }
        public decimal? RunningMetre { get; set; }
        public int RevitId { get; set; }
        public VerticalEnum? Vertical { get; set; }
        public string? RealisationMode { get; set; }
        public int? RotationDay { get; set; }
        public Level? Level { get; set; }
        public int? LevelId { get; set; }
        public Crane? Crane { get; set; }
        public int? CraneId { get; set; }
        public ICollection<ElementStatus> ElementStatuses { get; set; } = new List<ElementStatus>();
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public string? Details { get; set; }
        public bool IsPrefabricated { get; set; }
        public ElementTerm? ElementTerm { get; set; }
        public int? ElementTermId { get; set; }
        public BimModel? BimModel { get; set; }
        public int? BimModelId { get; set; }
        public ICollection<CommentaryElement> Comments { get; set; } = new List<CommentaryElement>();
        public ICollection<ElementsTimeEvidence> TimeEvidences { get; set; } = new List<ElementsTimeEvidence>();
        public ICollection<CustomParamValue> CustomParamValues { get; set; } = new List<CustomParamValue>();
    }
}