using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Crew : EntityModificationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
        public Project Project { get; set; }
        public CrewWorkTypeEnum CrewWorkType { get; set; }
    }

    public class CrewEntityConfigurator : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.CrewWorkType).HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();
            
            builder.HasOne(e => e.Project).WithMany();
            builder.HasOne(e => e.Owner).WithMany();
        }
    }
}