using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class CrewSummaryEntityConfigurator : IEntityTypeConfiguration<CrewSummary>
    {
        public void Configure(EntityTypeBuilder<CrewSummary> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.StartDate).HasColumnType("date");
            builder.Property(e => e.EndDate).HasColumnType("date");

            builder.HasOne(e => e.Crew).WithMany().HasForeignKey(e => e.CrewId);
            builder.HasOne(e => e.CrewOwner).WithMany().HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId);

            builder
                .HasMany(e => e.Workers)
                .WithMany(e => e.CrewSummaries)
                .UsingEntity<Worker_CrewSummary>(
                    j =>
                        j.HasOne(wcs => wcs.Worker).WithMany().HasForeignKey(e => e.WorkerId),
                    j =>
                        j.HasOne(wcr => wcr.CrewSummary).WithMany().HasForeignKey(e => e.CrewSummaryId),
                    j =>
                    {
                        j.HasKey(e => new { e.WorkerId, e.CrewSummaryId });
                    }
                );
        }
    }
}