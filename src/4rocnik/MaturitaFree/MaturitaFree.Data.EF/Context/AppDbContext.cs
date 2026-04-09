using MaturitaFree.Common.Entities;
using MaturitaFree.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace MaturitaFree.Data.EF;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<BookEntity> Books => Set<BookEntity>();
    public DbSet<PersonEntity> People => Set<PersonEntity>();
    public DbSet<PersonWorkingOnBook> PersonsWorkingOnBooks => Set<PersonWorkingOnBook>();
    public DbSet<BookChapterEntity> BookChapters => Set<BookChapterEntity>();
    public DbSet<BookParagraphEntity> BookParagraphs => Set<BookParagraphEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Automatically apply all IEntityTypeConfiguration implementations in this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ApplyAuditInfo();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void ApplyAuditInfo()
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateCreated = now;
                    entry.Entity.IsDeleted = false;
                    break;

                case EntityState.Modified:
                    entry.Entity.DateModified = now;
                    break;
                
                case EntityState.Deleted:
                    entry.Entity.DateDeleted = now;
                    entry.Entity.IsDeleted = true;
                    break;
            }
        }
    }
}
