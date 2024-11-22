using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

public class AppDbContext : DbContext
{
    public DbSet<Movies> Movies { get; set; }
    public DbSet<TVShows> TVShows { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // TODO:
    }
}
