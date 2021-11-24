using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class WorkerEntityConfigurator : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Ignore("_warbudId");

            builder.Property(u => u.CrewWorkType)
                .HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);


            builder.HasOne(e => e.AddedBy).WithMany().HasForeignKey(e => e.UserId);
        }
    }
}