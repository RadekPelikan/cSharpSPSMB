using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Grade")]
public record GradeEntity  : BaseEntity
{
    public int Value { get; set; }
    
    public double Weight { get; set; }

    public ProfileEntity Profile { get; set; }
    
    public int StudentId { get; set; }
    public StudentEntity Student { get; set; }

    public int SubjectId { get; set; }
    public SubjectEntity Subject { get; set; }
}