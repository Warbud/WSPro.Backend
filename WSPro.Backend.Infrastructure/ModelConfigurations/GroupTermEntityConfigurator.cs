using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class GroupTermEntityConfigurator : IEntityTypeConfiguration<GroupTerm>
    {
        public void Configure(EntityTypeBuilder<GroupTerm> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.PlannedStartBP).HasColumnType("date");
            builder.Property(e => e.PlannedFinishBP).HasColumnType("date");
            builder.Property(e => e.PlannedStart).HasColumnType("date");
            builder.Property(e => e.PlannedFinish).HasColumnType("date");
            builder.Property(e => e.RealStart).HasColumnType("date");
            builder.Property(e => e.RealFinish).HasColumnType("date");
            builder.Property(e => e.Vertical).HasConversion(new EnumConverter<VerticalEnum>().Converter);
            builder.HasOne(e => e.Crane).WithMany().HasForeignKey(e => e.CraneId);
            builder.HasOne(e => e.Level).WithMany().HasForeignKey(e => e.LevelId);
            builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId);
        }
    }
}