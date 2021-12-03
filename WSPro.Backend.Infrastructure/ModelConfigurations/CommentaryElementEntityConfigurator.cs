using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class CommentaryElementEntityConfigurator : IEntityTypeConfiguration<CommentaryElement>
    {
        public void Configure(EntityTypeBuilder<CommentaryElement> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Element).WithMany(e => e.Comments).IsRequired().HasForeignKey(e => e.ElementId);
        }
    }
}