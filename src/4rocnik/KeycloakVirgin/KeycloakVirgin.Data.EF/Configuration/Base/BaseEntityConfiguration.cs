using EFCoreVIrgin.Data.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreVIrgin.Data.EF.Configuration;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // Automatically set table name based on entity name without "Entity" suffix
        var entityName = typeof(TEntity).Name;
        var tableName = entityName.EndsWith("Entity") 
            ? entityName.Substring(0, entityName.Length - 6) 
            : entityName;
        builder.ToTable(tableName);
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}
