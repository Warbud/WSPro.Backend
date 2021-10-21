using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model.V1.General;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Domain.Model.V1
{
    public class ElementStatus : EntityModificationDate
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public StatusEnum Status { get; set; }
        
        public Element Element { get; set; }
        public User SetBy { get; set; }
        public Project Project { get; set; }
    }
    
    public class ElementStatusEntityConfigurator:IEntityTypeConfiguration<ElementStatus>
    {
        public void Configure(EntityTypeBuilder<ElementStatus> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.Status).HasConversion(new EnumConverter<StatusEnum>().Converter);

            builder.HasOne(e => e.Element).WithMany(e => e.ElementStatuses);
            builder.HasOne(e => e.SetBy).WithMany();
            builder.HasOne(e => e.Project).WithMany();

        }
    }
}