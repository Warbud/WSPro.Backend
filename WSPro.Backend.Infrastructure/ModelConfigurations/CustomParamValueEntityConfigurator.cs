using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class CustomParamValueEntityConfigurator:IEntityTypeConfiguration<CustomParamValue>
    {
        public void Configure(EntityTypeBuilder<CustomParamValue> builder)
        {
            builder.HasKey(e => new { e.CustomParamsId, e.ElementId });
            builder.HasOne(e => e.Element)
                .WithMany(e => e.CustomParamValues)
                .HasForeignKey(e => e.ElementId);
            builder.HasOne(e => e.CustomParams)
                .WithMany(e=>e.CustomParamValue)
                .HasForeignKey(e => e.CustomParamsId);
        }
    }
}