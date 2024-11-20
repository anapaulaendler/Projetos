using Microsoft.EntityFrameworkCore;
using PracticeAbstractClass.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Professor> Professors { get; set; } = null!;
    
}