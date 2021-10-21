using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class ElementTerm:EntityModificationDate
    {
        public Element Element { get; set; }
        public DateTime? PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public DateTime? PlannedStartBP { get; set; }
        public DateTime? PlannedFinishBP { get; set; }
        public DateTime? RealStart { get; set; }
        public DateTime? RealFinish { get; set; }
    }
    
    public class ElementTermEntityConfigurator:IEntityTypeConfiguration<ElementTerm>
    {
        public void Configure(EntityTypeBuilder<ElementTerm> builder)
        {
            builder.Property<int>("ElementId");
            builder.HasKey("ElementId");
            builder.Property(e => e.PlannedStartBP).HasColumnType("date");
            builder.Property(e => e.PlannedFinishBP).HasColumnType("date");
            builder.Property(e => e.PlannedStart).HasColumnType("date");
            builder.Property(e => e.PlannedFinish).HasColumnType("date");
            builder.Property(e => e.RealStart).HasColumnType("date");
            builder.Property(e => e.RealFinish).HasColumnType("date");
        }
    }
}