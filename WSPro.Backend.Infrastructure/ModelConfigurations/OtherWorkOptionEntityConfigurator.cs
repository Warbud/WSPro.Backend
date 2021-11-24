using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class OtherWorkOptionEntityConfigurator : IEntityTypeConfiguration<OtherWorkOption>
    {
        public void Configure(EntityTypeBuilder<OtherWorkOption> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(250);
            
            builder.Property(e => e.CrewType).HasConversion(new EnumConverter<CrewTypeEnum>().Converter);
            builder.Property(e => e.CrewWorkType).HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);
        }
    }
}