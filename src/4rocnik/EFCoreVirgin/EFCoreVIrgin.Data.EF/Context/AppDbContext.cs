using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVIrgin.Data.EF.Context;

public class AppDbContext : DbContext
{
    public DbSet<StudentEntity> Students { get; private set; }
    
    public DbSet<ProfileEntity> Profiles { get; private set; }

    public string FileName { get; init; } = "virgin.db";
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentEntity>(entity => {
            
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.UseSqlite($"Data Source={FileName}");
    }
}