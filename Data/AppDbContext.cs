using Microsoft.EntityFrameworkCore;

using MusicApp.Models;

namespace MusicApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Artist> Artists { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");

}
