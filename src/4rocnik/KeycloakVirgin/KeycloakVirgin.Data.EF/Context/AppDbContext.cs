using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVIrgin.Data.EF.Context;

public class AppDbContext : DbContext
{
    public DbSet<BasketEntity> Baskets { get; private set; }

    public DbSet<ProductEntity> Products { get; private set; }
    
    public string FileName { get; init; } = "virgin.db";

    protected AppDbContext(string fileName)
    {
        FileName = fileName;
    }
    
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