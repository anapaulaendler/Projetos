using CulturalEvents.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Event> Events { get; set; } = null!;
    
    public DbSet<Concert> Concerts { get; set; } = null!;
    public DbSet<Exhibition> Exhibitions { get; set; } = null!;
    public DbSet<TheaterPlay> TheaterPlays { get; set; } = null!;


    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Participant> Participants { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>()
            .HasDiscriminator<string>("event_type")
            .HasValue<Concert>("concert")
            .HasValue<Exhibition>("exhibition")
            .HasValue<TheaterPlay>("theater_play");
        // modelBuilder.Ignore<Event>();
        //  modelBuilder.Entity<Abstract>().UseTpcMappingStrategy();

        // modelBuilder.Entity<Concert>().UseTpcMappingStrategy().ToTable("Concerts");
        // modelBuilder.Entity<Exhibition>().UseTpcMappingStrategy().ToTable("Exhibitions");
        // modelBuilder.Entity<TheaterPlay>().UseTpcMappingStrategy().ToTable("TheaterPlays");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}