using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    public class Delay_DelayCause:EntityModificationDate
    {
        public DelayCause Cause { get; set; }
        public int CauseId { get; set; }
        public Delay Delay { get; set; }
        public int DelayId { get; set; }
    }
    
    public class Delay_DelayCauseEntityConfigurator:IEntityTypeConfiguration<Delay_DelayCause>
    {
        public void Configure(EntityTypeBuilder<Delay_DelayCause> builder)
        {
            builder.HasKey(e => new{ e.CauseId,e.DelayId });
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();

        }
    }
}