using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WSPro.Backend.Infrastructure.Converters;
using WSPro.Backend.Model;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure
{
    public class WSProContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Crane> Cranes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<ElementStatus> ElementStatuses { get; set; }
        public DbSet<DelayCause> DelayCauses { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Crew> Crews { get; set; }
        

        private string _connectionString;
        public WSProContext()
        {
            _connectionString = "Host=localhost;Database=wspro_test;Username=postgres;Password=admin";
        }

        public WSProContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>().Property(e => e.Vertical)
                .HasConversion(new EnumConverter<VerticalEnum>().Converter);

            modelBuilder.Entity<ElementStatus>().Property(es => es.Status)
                .HasConversion(new EnumConverter<StatusEnum>().Converter);
            
            modelBuilder.Entity<User>().Property(u => u.Provider)
                .HasConversion(new EnumConverter<AuthProviderEnum>().Converter);
            
            modelBuilder.Entity<Worker>().Property(u => u.CrewWorkTypeEnum)
                .HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);
            
            modelBuilder.Entity<Crew>().Property(u => u.CrewWorkType)
                .HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);
            modelBuilder.Entity<Crew>().Property(u => u.CrewType)
                .HasConversion(new EnumConverter<CrewTypeEnum>().Converter);
        }
    }
}