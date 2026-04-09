using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Basket")]
[Index(nameof(UserId), IsUnique = true)]
public record BasketEntity : BaseEntity
{
    public Guid UserId { get; set; }
    
    public ICollection<ProductEntity> Products { get; set; }
}