namespace EFCoreVIrgin.Data.EF.Entity.Base;

public abstract record BaseOwnerAuditEntity : BaseAuditEntity
{
    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid? DeletedBy { get; set; }
}