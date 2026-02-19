namespace EFCoreVIrgin.Data.EF.Entity.Base;

public abstract record BaseAuditEntity : BaseEntity
{
    // Audit fields
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}