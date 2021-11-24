using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class WorkerTimeEvidenceEntityConfigurator : IEntityTypeConfiguration<WorkerTimeEvidence>
    {
        public void Configure(EntityTypeBuilder<WorkerTimeEvidence> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Date).HasColumnType("date").IsRequired();
            builder.Property(e => e.WorkedTime).HasPrecision(3, 1).IsRequired();
            builder.HasOne(e => e.Project)
                .WithMany()
                .IsRequired()
                .HasForeignKey(e => e.ProjectId);
            builder.HasOne(e => e.SetByEngineer)
                .WithMany()
                .IsRequired()
                .HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Worker)
                .WithMany(e => e.TimeEvidences)
                .IsRequired()
                .HasForeignKey(e => e.WorkerId);
            builder.HasOne(e => e.CrewSummary)
                .WithMany(e => e.TimeEvidences)
                .IsRequired()
                .HasForeignKey(e => e.CrewSummaryId);
        }
    }
}