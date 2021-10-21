using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSPro.Backend.Domain.Model.V1.General;

namespace WSPro.Backend.Domain.Model.V1
{
    /// <summary>
    ///     Klasa projektu. Reprezentuje budowę/projekt na której uruchomiony jest system.
    /// </summary>
    public class Project : EntityModificationDate
    {

        /// <summary>
        ///     ID projektu w bazie danych
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Nazwa projektu
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Identyfikator projektu w systemie ERP
        /// </summary>
        public string? WebconCode { get; set; }

        /// <summary>
        ///     Identyfikator projektu w systemie harmonogramowym
        /// </summary>
        public string? MetodologyCode { get; set; }

        /// <summary>
        ///     Parametr określa czy projekt ma być synchronizowany z centralnym harmonogramem DIP. Jeśli tak, to konieczne jest
        ///     podanie parametru <i>MetodologyCode</i>
        /// </summary>
        public bool CentralScheduleSync { get; set; }
    }
    
    public class ProjectEntityConfigurator:IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.MetodologyCode).HasMaxLength(20);
            builder.Property(e => e.WebconCode).HasMaxLength(20);
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.CentralScheduleSync).HasDefaultValue(false);

        }
    }
}