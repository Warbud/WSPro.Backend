using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class DelayEntityConfigurator : IEntityTypeConfiguration<Delay>
    {
        public void Configure(EntityTypeBuilder<Delay> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Crane).WithMany().HasForeignKey(e => e.CraneId);
            builder.HasOne(e => e.Level).WithMany().HasForeignKey(e => e.LevelId);
            builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId);

            builder.HasMany(e => e.DelayCauses).WithMany(e => e.Delays).UsingEntity<Delay_DelayCause>(
                j => j.HasOne(e => e.Cause).WithMany().HasForeignKey(e => e.DelayCauseId),
                j => j.HasOne(e => e.Delay).WithMany(e=>e.DelayDelayCause).HasForeignKey(e => e.DelayId),
                j =>
                {
                    j.HasKey(e => new { e.DelayCauseId, e.DelayId });
                }
            );
        }
    }
}