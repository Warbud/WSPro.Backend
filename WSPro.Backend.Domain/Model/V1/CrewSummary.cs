using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class CrewSummary : EntityModificationDate
    {
        public int Id { get; set; }
        public Crew Crew { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User CrewOwner { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public Project Project { get; set; }
    }
    
    public class CrewSummaryEntityConfigurator:IEntityTypeConfiguration<CrewSummary>
    {
        public void Configure(EntityTypeBuilder<CrewSummary> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.StartDate).HasColumnType("date");
            builder.Property(e => e.EndDate).HasColumnType("date");

            builder.HasOne(e => e.Crew).WithMany();
            builder.HasOne(e => e.CrewOwner).WithMany();
            builder.HasOne(e => e.Project).WithMany();
        }
    }
}