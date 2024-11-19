using Microsoft.EntityFrameworkCore;

namespace EfCrud.Data;

public class AppDbContext : DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; } = null!;
}