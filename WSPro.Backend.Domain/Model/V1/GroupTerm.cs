using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class GroupTerm : EntityModificationDate
    {
        public int Id { get; set; }
        public VerticalEnum Vertical { get; set; }
        public DateTime? PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public DateTime? PlannedStartBP { get; set; }
        public DateTime? PlannedFinishBP { get; set; }
        public DateTime? RealStart { get; set; }
        public DateTime? RealFinish { get; set; }
        public Crane? Crane { get; set; }
        public Project Project { get; set; }
        public Level? Level { get; set; }
        public ICollection<Element> Elements { get; set; }
        public ICollection<ElementTerm> Terms { get; set; }
    }
    
    public class GroupTermEntityConfigurator:IEntityTypeConfiguration<GroupTerm>
    {
        public void Configure(EntityTypeBuilder<GroupTerm> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.PlannedStartBP).HasColumnType("date");
            builder.Property(e => e.PlannedFinishBP).HasColumnType("date");
            builder.Property(e => e.PlannedStart).HasColumnType("date");
            builder.Property(e => e.PlannedFinish).HasColumnType("date");
            builder.Property(e => e.RealStart).HasColumnType("date");
            builder.Property(e => e.RealFinish).HasColumnType("date");
            builder.Property(e => e.Vertical).HasConversion(new EnumConverter<VerticalEnum>().Converter);
            builder.HasOne(e => e.Crane).WithMany();
            builder.HasOne(e => e.Level).WithMany();
            builder.HasOne(e => e.Project).WithMany();
            builder.HasMany(e => e.Terms).WithOne();
            builder.HasMany(e => e.Elements).WithOne(e => e.GroupTerm);
        }
    }
}