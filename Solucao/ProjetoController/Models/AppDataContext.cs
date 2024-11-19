
using Microsoft.EntityFrameworkCore;

public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; } = null!;
    
}