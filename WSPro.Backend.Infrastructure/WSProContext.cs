using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WSPro.Backend.Model;

namespace WSPro.Backend.Infrastructure
{
    public class WSProContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<Worker> Worker { get; set; }
        // public DbSet<HouseWorker> HouseWorker { get; set; }
        // public DbSet<ExternalWorker> ExternalWorker { get; set; }

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
    }
}