using MaturitniZkouseni.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaturitniZkouseni;

public class AppDbContext : DbContext
{
    public DbSet<StudentEntity> Student { get; private set; }
    public DbSet<ClassEntity> Class { get; private set; }
    
    public string FileName { get; init; } = "virgin.db";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite($"Data Source={FileName}");
    }
}