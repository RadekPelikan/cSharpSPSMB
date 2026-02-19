using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Product")]
public record ProductEntity : BaseEntity
{
    public string Name { get; set; }
    
    public Guid BasketId { get; set; }
    public BasketEntity Basket { get; set; }
}