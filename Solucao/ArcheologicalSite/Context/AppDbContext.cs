using ArcheologicalSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ArcheologicalSite.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Archeologist> Archeologists { get; set; } = null!;
        public DbSet<Artefact> Artefacts { get; set; } = null!;
        public DbSet<Fossil> Fossils { get; set; } = null!;
        public DbSet<Paleontologist> Paleontologists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}