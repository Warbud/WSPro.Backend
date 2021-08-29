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
        }
    }
}