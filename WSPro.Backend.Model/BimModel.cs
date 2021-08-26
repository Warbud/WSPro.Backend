﻿using System.Collections.Generic;

namespace WSPro.Backend.Model
{
    public class BimModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelUrn { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public List<Level> Levels { get; set; } = new List<Level>();
        public List<Crane> Cranes { get; set; } = new List<Crane>();
    }
}