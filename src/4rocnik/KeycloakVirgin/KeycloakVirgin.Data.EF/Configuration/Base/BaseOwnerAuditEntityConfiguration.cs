using EFCoreVIrgin.Data.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreVIrgin.Data.EF.Configuration;

public abstract class BaseOwnerAuditEntityConfiguration<TEntity> : BaseAuditEntityConfiguration<TEntity>
    where TEntity : BaseOwnerAuditEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        
        builder.Property(e => e.CreatedBy)
            .IsRequired();
    }
}
