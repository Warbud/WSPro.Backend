using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure.ModelConfigurations
{
    public class UserEntityConfigurator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Provider).HasConversion(new EnumConverter<AuthProviderEnum>().Converter);
        }
    }
}