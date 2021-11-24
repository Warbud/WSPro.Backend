using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class CustomParamsEntityConfigurator : IEntityTypeConfiguration<CustomParams>
    {
        public void Configure(EntityTypeBuilder<CustomParams> builder)
        {
            builder.HasKey(e => e.Id);
            builder
                .Property(e => e.Type)
                .HasConversion(new EnumConverter<CustomParamsDataTypes>().Converter);

            
            
            
        }
    }
}