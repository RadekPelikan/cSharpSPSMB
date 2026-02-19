using System.Reflection;
using EFCoreVIrgin.Data.EF.Entity;
using EFCoreVIrgin.Data.EF.Entity.Base;
using KeycloakVirgin.Common.AppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCoreVIrgin.Data.EF.Context;

public abstract class AppDbContext : DbContext, IAppDbContext
{
    protected readonly DatabaseConfig _databaseConfig;
    public Guid? CurrentUser { get; set; }
    
    public override DbSet<TEntity> Set<TEntity>()
    {
        return base.Set<TEntity>();
    }

    protected AppDbContext(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig ?? throw new ArgumentNullException(nameof(databaseConfig));
    }

    protected AppDbContext(DbContextOptions options, DatabaseConfig databaseConfig) 
        : base(options)
    {
        _databaseConfig = databaseConfig ?? throw new ArgumentNullException(nameof(databaseConfig));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Register all entity configurations from the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public override int SaveChanges()
    {
        ApplyAuditInformation();
        return base.SaveChanges();
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditInformation();
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    private void ApplyAuditInformation()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || 
                       e.State == EntityState.Modified || 
                       e.State == EntityState.Deleted)
            .ToList();
        
        var auditLogs = new List<AuditLogEntity>();
        var now = DateTime.UtcNow;
        
        foreach (var entry in entries)
        {
            // Skip AuditLogEntity itself to avoid infinite loops
            if (entry.Entity is AuditLogEntity)
                continue;
            
            // Handle BaseAuditEntity fields
            if (entry.Entity is BaseAuditEntity auditEntity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntity.Created = now;
                        
                        if (entry.Entity is BaseOwnerAuditEntity ownerAuditEntity && CurrentUser.HasValue)
                        {
                            ownerAuditEntity.CreatedBy = CurrentUser.Value;
                        }
                        break;
                    
                    case EntityState.Modified:
                        auditEntity.Updated = now;
                        
                        if (entry.Entity is BaseOwnerAuditEntity ownerAuditEntityModified && CurrentUser.HasValue)
                        {
                            ownerAuditEntityModified.UpdatedBy = CurrentUser.Value;
                        }
                        
                        // Create audit log entries for modified properties (excluding creates/deletes)
                        auditLogs.AddRange(CreateAuditLogsForModifiedEntity(entry, now));
                        break;
                    
                    case EntityState.Deleted:
                        // Soft delete
                        entry.State = EntityState.Modified;
                        auditEntity.IsDeleted = true;
                        auditEntity.DeletedAt = now;
                        
                        if (entry.Entity is BaseOwnerAuditEntity ownerAuditEntityDeleted && CurrentUser.HasValue)
                        {
                            ownerAuditEntityDeleted.DeletedBy = CurrentUser.Value;
                        }
                        break;
                }
            }
        }
        
        // Add audit logs to the context
        if (auditLogs.Any())
        {
            Set<AuditLogEntity>().AddRange(auditLogs);
        }
    }
    
    private List<AuditLogEntity> CreateAuditLogsForModifiedEntity(EntityEntry entry, DateTime now)
    {
        var auditLogs = new List<AuditLogEntity>();
        var entityName = entry.Entity.GetType().Name;
        var entityId = GetEntityId(entry);
        
        if (!entityId.HasValue)
            return auditLogs;
        
        foreach (var property in entry.Properties)
        {
            // Skip if property hasn't changed
            if (!property.IsModified)
                continue;
            
            // Skip audit fields themselves
            if (IsAuditProperty(property.Metadata.Name))
                continue;
            
            var previousValue = property.OriginalValue?.ToString();
            var newValue = property.CurrentValue?.ToString();
            
            // Only log if values actually changed
            if (previousValue == newValue)
                continue;
            
            auditLogs.Add(new AuditLogEntity
            {
                EntityName = entityName,
                EntityId = entityId.Value,
                ColumnName = property.Metadata.Name,
                PreviousValue = previousValue,
                NewValue = newValue,
                ChangedAt = now,
                ChangedBy = CurrentUser ?? Guid.Empty,
                Action = "UPDATE"
            });
        }
        
        return auditLogs;
    }
    
    private Guid? GetEntityId(EntityEntry entry)
    {
        if (entry.Entity is BaseEntity baseEntity)
        {
            return baseEntity.Id;
        }
        
        return null;
    }
    
    private bool IsAuditProperty(string propertyName)
    {
        return propertyName is "Created" or "CreatedBy" or "Updated" or "UpdatedBy" 
            or "IsDeleted" or "DeletedAt" or "DeletedBy";
    }
}