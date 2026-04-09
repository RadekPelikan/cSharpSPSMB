using MaturitaFree.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaturitaFree.Data.EF.Configurations;

/// <summary>
/// Base configuration for all entities that inherit from <see cref="BaseEntity"/>.
/// Inherit from this class and add entity-specific configuration.
/// </summary>
public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        var entityName = typeof(T).Name;
        var tableName = entityName.EndsWith("Entity") 
            ? entityName.Substring(0, entityName.Length - 6) 
            : entityName;
        builder.ToTable(tableName);
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.DateCreated)
            .IsRequired();

        builder.Property(e => e.DateModified)
            .IsRequired(false);

        builder.Property(e => e.DateDeleted)
            .IsRequired(false);

        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        // Soft-delete query filter: by default, only return non-deleted records
        builder.HasQueryFilter(e => !e.IsDeleted);

        ConfigureEntity(builder);
    }

    /// <summary>
    /// Override to add entity-specific EF configuration.
    /// </summary>
    protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}
