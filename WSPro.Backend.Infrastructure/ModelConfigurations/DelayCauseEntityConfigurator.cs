using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class DelayCauseEntityConfigurator : IEntityTypeConfiguration<DelayCause>
    {
        public void Configure(EntityTypeBuilder<DelayCause> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(200);

            builder.HasOne(e => e.Parent).WithMany().HasForeignKey(e => e.DelayCauseId);
        }
    }
}