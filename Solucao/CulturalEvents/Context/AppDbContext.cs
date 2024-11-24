using CulturalEvents.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<CardPayment> CardPayments { get; set; } = null!;
    public DbSet<Concert> Concerts { get; set; } = null!;
    public DbSet<Exhibition> Exhibitions { get; set; } = null!;
    public DbSet<Participant> Participants { get; set; } = null!;
    public DbSet<PixPayment> PixPayments { get; set; } = null!;
    public DbSet<TheaterPlay> TheaterPlays { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
}