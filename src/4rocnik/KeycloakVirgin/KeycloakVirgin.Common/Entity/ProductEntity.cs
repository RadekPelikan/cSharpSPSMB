using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

public record ProductEntity : BaseOwnerAuditEntity
{
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public Guid BasketId { get; set; }
    public BasketEntity Basket { get; set; }
}