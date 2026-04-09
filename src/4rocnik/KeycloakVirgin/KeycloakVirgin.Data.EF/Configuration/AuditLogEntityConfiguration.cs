using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreVIrgin.Data.EF.Configuration;

public class AuditLogEntityConfiguration : BaseEntityConfiguration<AuditLogEntity>
{
    public override void Configure(EntityTypeBuilder<AuditLogEntity> builder)
    {
        base.Configure(builder);
        
        builder.Property(a => a.EntityName)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(a => a.EntityId)
            .IsRequired();
        
        builder.Property(a => a.ColumnName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(a => a.PreviousValue)
            .HasMaxLength(2000);
        
        builder.Property(a => a.NewValue)
            .HasMaxLength(2000);
        
        builder.Property(a => a.ChangedAt)
            .IsRequired();
        
        builder.Property(a => a.ChangedBy)
            .IsRequired();
        
        builder.Property(a => a.Action)
            .IsRequired()
            .HasMaxLength(20);
        
        // Indexes for better query performance
        builder.HasIndex(a => a.EntityName);
        builder.HasIndex(a => a.EntityId);
        builder.HasIndex(a => a.ChangedAt);
        builder.HasIndex(a => new { a.EntityName, a.EntityId });
    }
}
