using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class CrewEntityConfigurator : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.CrewWorkType).HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);

            builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId);
            builder.HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.UserId);
        }
    }
}