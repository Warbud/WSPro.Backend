using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class ElementEntityConfigurator : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Vertical).HasConversion(new EnumConverter<VerticalEnum>().Converter);
            builder.Property(e => e.IsPrefabricated).HasDefaultValue(false);

            builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId);
            builder.HasOne(e => e.Crane).WithMany().HasForeignKey(e => e.CraneId);
            builder.HasOne(e => e.Level).WithMany().HasForeignKey(e => e.LevelId);
            builder.HasOne(e => e.BimModel).WithMany(e => e!.Elements!).HasForeignKey(e => e.BimModelId);
            builder.HasOne(e => e.ElementTerm).WithOne(e => e!.Element);
        }
    }
}