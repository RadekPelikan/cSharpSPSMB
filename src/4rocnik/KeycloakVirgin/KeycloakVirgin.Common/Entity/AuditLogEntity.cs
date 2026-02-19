using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

public record AuditLogEntity : BaseEntity
{
    public string EntityName { get; set; }
    public Guid EntityId { get; set; }
    public string ColumnName { get; set; }
    public string? PreviousValue { get; set; }
    public string? NewValue { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    public Guid ChangedBy { get; set; }
    public string Action { get; set; } // INSERT, UPDATE, DELETE
}
