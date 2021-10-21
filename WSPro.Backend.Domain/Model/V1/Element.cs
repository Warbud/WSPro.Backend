using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Element : EntityModificationDate
    {
        public int Id { get; set; }
        public decimal? Area { get; set; }
        public decimal? Volume { get; set; }
        public decimal? RunningMetre { get; set; }
        public int RevitID { get; set; }
        public VerticalEnum? Vertical { get; set; }
        public string? RealisationMode { get; set; }
        public int? RotationDay { get; set; }
        public Level? Level { get; set; }
        public Crane? Crane { get; set; }
        public ICollection<ElementStatus> ElementStatuses { get; set; }
        public Project Project { get; set; }
        public string? Details { get; set; }
        public bool IsPrefabricated { get; set; }
        public GroupTerm? GroupTerm { get; set; }
        public ElementTerm? ElementTerm { get; set; }
     
        //todo dodać relacje z object_time_evidences

    }


    public class ElementEntityConfigurator : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.Vertical).HasConversion(new EnumConverter<VerticalEnum>().Converter);
            builder.Property(e => e.IsPrefabricated).HasDefaultValue(false);
            
            builder.HasOne(e => e.Project).WithMany();
            builder.HasOne(e => e.Crane).WithMany();
            builder.HasOne(e => e.Level).WithMany();
            builder.HasMany(e => e.ElementStatuses)
                .WithOne(e => e.Element);

            builder.HasOne(e => e.GroupTerm).WithMany(e => e.Elements);
            builder.HasOne(e => e.ElementTerm).WithOne(e => e.Element);
        }
    }
    
}