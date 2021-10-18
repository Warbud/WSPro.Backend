﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Element : EntityModificationDate
    {
        // private Element()
        // {
        // }
        //
        // /// <summary>
        // ///     Wymagane elementy
        // /// </summary>
        // /// <param name="id"></param>
        // /// <param name="revitId"></param>
        // /// <param name="project"></param>
        // public Element(int revitId, Project project)
        // {
        //     RevitID = revitId;
        //     Project = project;
        // }

        [Required] public int Id { get; private set; }

        public decimal? Area { get; set; }
        public decimal? Volume { get; set; }
        public decimal? RunningMetre { get; set; }
        [Required] public int RevitID { get; private set; }
        public VerticalEnum? Vertical { get; set; }
        public string? RealisationMode { get; set; }
        public int? RotationDay { get; set; }
        public Level? Level { get; set; }
        private int? LevelID { get; set; }
        public Crane? Crane { get; set; }
        private int? CraneID { get; set; }
        public ICollection<ElementStatus> ElementStatuses { get; set; } 

        [Required] public Project Project { get; }

        public string Details { get; set; }

        public bool IsPrefabricated { get; set; }
        
        //todo dodać relacje z object_time_evidences
        //todo dodać relacje z terms

        // public override string ToString()
        // {
        //     return $"{Id - RevitID - Project.Id}";
        // }
    }
}