using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

public class AppDbContext : DbContext
{
    /// <summary>
    /// Database context for our Movie model
    /// </summary>
    public DbSet<Movies> Movies { get; set; }
    /// <summary>
    ///  Database context for our TV Shows model
    /// </summary>
    public DbSet<TVShows> TVShows { get; set; }
    public DbSet<Users> Users { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // TODO: 
    }
}
