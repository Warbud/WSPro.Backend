using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    /// <summary>
    ///     Klasa poziomu
    /// </summary>
    public class Level : EntityModificationDate
    {
        /// <summary>
        ///     Indeks w bazie poziomu
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Nazwa poziomu
        /// </summary>
        public string Name { get; set; }
    }
    
    public class LevelEntityConfigurator:IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();

        }
    }
}