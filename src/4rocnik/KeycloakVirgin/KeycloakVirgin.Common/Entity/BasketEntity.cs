using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVIrgin.Data.EF.Entity;

public record BasketEntity : BaseOwnerAuditEntity
{
    public Guid UserId { get; set; }
    
    public ICollection<ProductEntity> Products { get; set; }
}