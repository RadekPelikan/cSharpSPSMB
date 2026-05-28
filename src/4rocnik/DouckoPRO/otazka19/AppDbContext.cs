using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<CharacterEntity> Character { get; set; }
    
    public DbSet<WeaponEntity> Weapon { get; set; }
    
    public string FileName { get; init; } = "zkouska19.db";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var projectFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../"));
        var path = Path.Combine(projectFolder, FileName);

        Console.WriteLine($"Cesta k {FileName}: {path}");
        optionsBuilder.UseSqlite($"Data Source={path}");
    }
}