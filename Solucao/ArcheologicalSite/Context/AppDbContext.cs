using ArcheologicalSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ArcheologicalSite.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Archeologist> Archeologists { get; set; } = null!;
        public DbSet<Artefact> Artefacts { get; set; } = null!;
        public DbSet<Fossil> Fossils { get; set; } = null!;
        public DbSet<Paleontologist> Paleontologists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}