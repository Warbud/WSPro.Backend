using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Interfaces;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Domain.Model.V1;
using WSPro.Backend.Infrastructure.Converters;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure
{
    public class WSProContext : DbContext
    {
        public WSProContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Crane> Cranes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<ElementStatus> ElementStatuses { get; set; }
        public DbSet<DelayCause> DelayCauses { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Crew> Crews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>().Property(e => e.Vertical)
                .HasConversion(new EnumConverter<VerticalEnum>().Converter);

            modelBuilder.Entity<Element>().Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            modelBuilder.Entity<Element>().Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<ElementStatus>().Property(es => es.Status)
                .HasConversion(new EnumConverter<StatusEnum>().Converter);

            modelBuilder.Entity<User>().Property(u => u.Provider)
                .HasConversion(new EnumConverter<AuthProviderEnum>().Converter);

            modelBuilder.Entity<Worker>().Property(u => u.CrewWorkType)
                .HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);

            modelBuilder.Entity<Crew>().Property(u => u.CrewWorkType)
                .HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);
            modelBuilder.Entity<Crew>().Property(u => u.CrewType)
                .HasConversion(new EnumConverter<CrewTypeEnum>().Converter);
            
            // modelBuilder.Entity<Crane>().Property(x => x.CreatedAt).HasDefaultValueSql("now()");
            // modelBuilder.Entity<Crane>().Property(x => x.UpdatedAt).HasDefaultValueSql("now()");
        }
    }
}