using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreVIrgin.Data.EF.Configuration;

public class BasketEntityConfiguration : BaseEntityConfiguration<BasketEntity>
{
    public override void Configure(EntityTypeBuilder<BasketEntity> builder)
    {
        base.Configure(builder);
        
        builder.HasIndex(b => b.UserId)
            .IsUnique();
        
        builder.Property(b => b.UserId)
            .IsRequired();
        
        // Relationships
        builder.HasMany(b => b.Products)
            .WithOne(p => p.Basket)
            .HasForeignKey(p => p.BasketId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
