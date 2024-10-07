using Microsoft.EntityFrameworkCore;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=movies.db");
    }
}
