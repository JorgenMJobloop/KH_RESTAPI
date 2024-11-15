using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Movies> Movies { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

}
