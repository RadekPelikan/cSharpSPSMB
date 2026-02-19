using EFCoreVIrgin.Data.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreVIrgin.Data.EF.Configuration;

public abstract class BaseAuditEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
    where TEntity : BaseAuditEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        
        builder.Property(e => e.Created)
            .IsRequired();
        
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);
        
        // Global query filter to exclude soft-deleted records by default
        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}
