using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class ElementStatusEntityConfigurator : IEntityTypeConfiguration<ElementStatus>
    {
        public void Configure(EntityTypeBuilder<ElementStatus> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Element).WithMany(e => e.ElementStatuses).HasForeignKey(e => e.ElementId);
            builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId);
        }
    }
}