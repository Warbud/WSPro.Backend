using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class GroupedOtherWorkTimeEvidenceEntityConfigurator : IEntityTypeConfiguration<GroupedOtherWorkTimeEvidence>
    {
        public void Configure(EntityTypeBuilder<GroupedOtherWorkTimeEvidence> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Date).HasColumnType("date");
            builder.Property(e => e.CrewType).HasConversion(new EnumConverter<CrewTypeEnum>().Converter);
            builder.HasOne(e => e.Crew).WithMany().HasForeignKey(e => e.CrewId);
            builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId);
            builder.HasOne(e => e.Level).WithMany().HasForeignKey(e => e.LevelId);
        }
    }
}