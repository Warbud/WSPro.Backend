using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Enums;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class ProjectEntityConfigurator : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.MetodologyCode).HasMaxLength(20);
            builder.Property(e => e.WebconCode).HasMaxLength(20);
            builder.Property(e => e.CentralScheduleSync).HasDefaultValue(false);
            builder.Property(e => e.SupportedStatuses).HasConversion(
                new ListEnumConverter<StatusEnum>()
            );
            builder.Property(e => e.SupportedModules).HasConversion(
                new ListEnumConverter<AppEnum>()
            );

            builder.HasMany(e => e.CustomParams)
                .WithMany(e => e.Project)
                .UsingEntity<CustomParamProject>(
                    j => j.HasOne(e => e.CustomParams)
                        .WithMany(e => e.CustomParamProject)
                        .HasForeignKey(e => e.CustomParamsId),
                    j => j.HasOne(e => e.Project)
                        .WithMany(e => e.CustomParamProject)
                        .HasForeignKey(e => e.ProjectId),
                    j => { j.HasKey(e => new { e.CustomParamsId, e.ProjectId }); }
                );
        }
    }
}