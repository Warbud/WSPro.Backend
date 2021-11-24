using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class ElementsTimeEvidenceEntityConfigurator : IEntityTypeConfiguration<ElementsTimeEvidence>
    {
        public void Configure(EntityTypeBuilder<ElementsTimeEvidence> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Date).HasColumnType("date");
            builder.Property(e => e.WorkedTime).HasPrecision(5, 1);

            builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId);
            builder.HasOne(e => e.Crew).WithMany().HasForeignKey(e => e.CrewId);

            builder
                .HasMany(e => e.Elements)
                .WithMany(e => e.TimeEvidences)
                .UsingEntity<Element_ElementsTimeEvidence>(
                    j => j.HasOne(e => e.Element)
                        .WithMany().HasForeignKey(e => e.ElementId),
                    j => j.HasOne(e => e.ElementsTimeEvidence)
                        .WithMany(e=>e.ElementElementsTimeEvidence).HasForeignKey(e => e.ElementsTimeEvidenceId),
                    j =>
                    {
                        j.HasKey(e => new { e.ElementId, e.ElementsTimeEvidenceId });
                    }
                );
        }
    }
}