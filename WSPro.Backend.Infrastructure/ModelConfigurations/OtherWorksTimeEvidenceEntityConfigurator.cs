using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class OtherWorksTimeEvidenceEntityConfigurator : IEntityTypeConfiguration<OtherWorksTimeEvidence>
    {
        public void Configure(EntityTypeBuilder<OtherWorksTimeEvidence> builder)
        {
            builder.HasKey(e => e.Id);
            

            builder.Property(e => e.WorkedTime).HasPrecision(5, 1).IsRequired();
            builder.HasOne(e => e.OtherWorkOption).WithMany().HasForeignKey(e => e.OtherWorkOptionId);
            builder.HasOne(e => e.GroupedOtherWorkTimeEvidence).WithMany(e => e.OtherWorksTimeEvidences)
                .HasForeignKey(e => e.GroupedOtherWorkTimeEvidenceId);
            builder.Property(e => e.OtherWorkType).HasConversion(new EnumConverter<OtherWorkTypeEnum>().Converter);
            builder.Property(e => e.Type).HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);
        }
    }
}