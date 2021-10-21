using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Delay : EntityModificationDate
    {
        public int Id { get; set; }
        public string Commentary { get; set; }
        public User User { get; set; }
        // public ICollection<DelayCause> DelayCauses { get; set; } 
        public Level? Level { get; set; }
        public Crane? Crane { get; set; }
        [DataType(DataType.Date)] 
        public DateTime Date { get; set; }
        public Project Project { get; set; }
        public ICollection<Delay_DelayCause> DelayCauses { get; set; }
    }
    
    public class DelayEntityConfigurator:IEntityTypeConfiguration<Delay>
    {
        public void Configure(EntityTypeBuilder<Delay> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(e => e.Crane).WithMany();
            builder.HasOne(e => e.Level).WithMany();
            builder.HasOne(e => e.Project).WithMany();
            builder.HasOne(e => e.User).WithMany();

            builder.HasMany(e => e.DelayCauses).WithOne(e => e.Delay);

        }
    }
}