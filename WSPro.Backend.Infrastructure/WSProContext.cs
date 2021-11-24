using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Domain.Model.General;
using WSPro.Backend.Infrastructure.ModelConfigurations;

namespace WSPro.Backend.Infrastructure
{
    public class WSProContext : DbContext
    {
        public WSProContext(DbContextOptions options) : base(options)
        {
            Database.SetCommandTimeout(120);
        }

        public DbSet<BimModel_Crane> BimModel_Cranes { get; set; }
        public DbSet<BimModel_Level> BimModel_Levels { get; set; }
        public DbSet<BimModel> BimModels { get; set; }
        public DbSet<CommentaryElement> CommentaryElements { get; set; }
        public DbSet<Crane> Cranes { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<CrewSummary> CrewSummaries { get; set; }
        public DbSet<CustomParamProject> CustomParamProjects { get; set; }
        public DbSet<CustomParams> CustomParams { get; set; }
        public DbSet<CustomParamValue> CustomParamValues { get; set; }
        public DbSet<Delay_DelayCause> Delay_DelayCauses { get; set; }
        public DbSet<Delay> Delays { get; set; }
        public DbSet<DelayCause> DelayCauses { get; set; }
        public DbSet<Element_ElementsTimeEvidence> Element_ElementsTimeEvidences { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<ElementStatus> ElementStatuses { get; set; }
        public DbSet<ElementsTimeEvidence> ElementsTimeEvidences { get; set; }
        public DbSet<ElementTerm> ElementTerms { get; set; }
        public DbSet<GroupedOtherWorkTimeEvidence> GroupedOtherWorkTimeEvidences { get; set; }
        public DbSet<GroupTerm> GroupTerms { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<OtherWorkOption> OtherWorkOptions { get; set; }
        public DbSet<OtherWorksTimeEvidence> OtherWorksTimeEvidences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Worker_CrewSummary> Worker_CrewSummaries { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerTimeEvidence> WorkerTimeEvidences { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityModificationDate && e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                ((EntityModificationDate) entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    ((EntityModificationDate) entityEntry.Entity).CreatedAt = DateTime.Now;
            }

            return await base.SaveChangesAsync().ConfigureAwait(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllProjectConfigurations();
        }
    }

    public static class ConfiguratorExtenstion
    {
        public static ModelBuilder ApplyAllProjectConfigurations(this ModelBuilder modelBuilder)
        {
            foreach (var type in typeof(BimModelEntityConfigurator).Assembly.GetTypes())
                if (type.GetInterface(typeof(IEntityTypeConfiguration<>).Name) != null)
                    modelBuilder.ApplyConfigurationsFromAssembly(type.Assembly);

            return modelBuilder;
        }
    }
}