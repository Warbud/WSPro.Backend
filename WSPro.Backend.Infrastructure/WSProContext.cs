using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Converters;
using WSPro.Backend.Domain.Model.V1;
using WSPro.Backend.Model.Enums;

namespace WSPro.Backend.Infrastructure
{
    public class WSProContext : DbContext
    {
        public WSProContext(DbContextOptions options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Crane> Cranes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<ElementTerm> ElementTerms { get; set; }
        public DbSet<GroupTerm> GroupTerms { get; set; }
        public DbSet<ElementStatus> ElementStatuses { get; set; }
        public DbSet<Delay_DelayCause> Delay_DelayCauses { get; set; }
        public DbSet<DelayCause> DelayCauses { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Crew> Crews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CraneEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrewEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Delay_DelayCauseEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DelayCauseEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DelayEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElementEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElementStatusEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElementTermEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupTermEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LevelEntityConfigurator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectEntityConfigurator).Assembly);

            modelBuilder.Entity<User>().Property(u => u.Provider)
                .HasConversion(new EnumConverter<AuthProviderEnum>().Converter);

            modelBuilder.Entity<Worker>().Property(u => u.CrewWorkType)
                .HasConversion(new EnumConverter<CrewWorkTypeEnum>().Converter);

            
            
        }
    }
}