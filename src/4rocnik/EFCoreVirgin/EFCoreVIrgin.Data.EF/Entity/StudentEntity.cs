using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Student")]
public record StudentEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public ProfileEntity Profile { get; set; }


    public int ClassId { get; set; }
    public ClassEntity Class { get; set; }
}