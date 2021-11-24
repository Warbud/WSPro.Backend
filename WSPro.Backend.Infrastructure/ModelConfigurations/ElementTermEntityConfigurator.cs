using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class ElementTermEntityConfigurator : IEntityTypeConfiguration<ElementTerm>
    {
        public void Configure(EntityTypeBuilder<ElementTerm> builder)
        {
            
            builder.HasKey(e => e.ElementId);
            
            builder.HasOne(e => e.Element)
                .WithOne(e => e.ElementTerm!).HasForeignKey<ElementTerm>(e => e.ElementId);

            builder.HasOne(e => e.GroupTerm).WithMany(e => e.Terms).HasForeignKey(e => e.GroupTermId);

            builder.Property(e => e.PlannedStartBP).HasColumnType("date");
            builder.Property(e => e.PlannedFinishBP).HasColumnType("date");
            builder.Property(e => e.PlannedStart).HasColumnType("date");
            builder.Property(e => e.PlannedFinish).HasColumnType("date");
            builder.Property(e => e.RealStart).HasColumnType("date");
            builder.Property(e => e.RealFinish).HasColumnType("date");
        }
    }
}