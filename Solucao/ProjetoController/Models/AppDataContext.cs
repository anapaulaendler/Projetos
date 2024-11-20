
using Microsoft.EntityFrameworkCore;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options)
    {
    }
    public DbSet<Produto> Produtos { get; set; } = null!;
    
}