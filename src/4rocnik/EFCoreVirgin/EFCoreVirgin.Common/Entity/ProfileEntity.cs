using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Profile")]
public record ProfileEntity : BaseEntity
{
    public string Bio { get; set; }
    
    public int StudentId { get; set; }
    public StudentEntity Student { get; set; }
}