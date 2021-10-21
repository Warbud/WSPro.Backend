using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class DelayCause : EntityModificationDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public DelayCause? Parent { get; set; }
    }
    
    public class DelayCauseEntityConfigurator:IEntityTypeConfiguration<DelayCause>
    {
        public void Configure(EntityTypeBuilder<DelayCause> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(200); 
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(e => e.Parent).WithMany();
            builder.HasMany<Delay_DelayCause>().WithOne(e => e.Cause);
        }
    }
}