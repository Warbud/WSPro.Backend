using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class BimModelEntityConfigurator : IEntityTypeConfiguration<BimModel>
    {
        public void Configure(EntityTypeBuilder<BimModel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Project).WithMany(e => e.Models).HasForeignKey(e => e.ProjectId);


            builder
                .HasMany(e => e.Cranes)
                .WithMany(e => e.Models)
                .UsingEntity<BimModel_Crane>(
                    j => j.HasOne(e => e.Crane)
                        .WithMany()
                        .HasForeignKey(e => e.CraneId),
                    j => j.HasOne(e => e.Model)
                        .WithMany(e=>e.BimModelsCranes)
                        .HasForeignKey(e => e.ModelId),
                    j =>
                    {
                        j.HasKey(e => new { e.ModelId, e.CraneId });
                    }
                );

            builder
                .HasMany(e => e.Levels)
                .WithMany(e => e.Models)
                .UsingEntity<BimModel_Level>(
                    j => j.HasOne(e => e.Level)
                        .WithMany()
                        .HasForeignKey(e => e.LevelId),
                    j => j.HasOne(e => e.Model)
                        .WithMany(e=>e.BimModelsLevels)
                        .HasForeignKey(e => e.ModelId),
                    j =>
                    {
                        j.HasKey(e => new { e.ModelId, e.LevelId });
                    }
                );
        }
    }
}