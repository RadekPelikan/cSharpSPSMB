using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Student")]
public record StudentEntity  : BaseEntity
{
    public string Name { get; set; }

    public ProfileEntity Profile { get; set; }


    public int ClassId { get; set; }
    public ClassEntity Class { get; set; }
    
    public ICollection<StudentEntity> Students { get; set; }
}