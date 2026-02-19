using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreVIrgin.Data.EF.Configuration;

public class ProductEntityConfiguration : BaseEntityConfiguration<ProductEntity>
{
    public override void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        base.Configure(builder);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(p => p.Description)
            .HasMaxLength(1000);
        
        builder.Property(p => p.BasketId)
            .IsRequired();
        
        // Relationships
        builder.HasOne(p => p.Basket)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BasketId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
