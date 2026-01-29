using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Student")]
public class StudentEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ProfileEntity Profile { get; set; }

    public override string ToString()
    {
        return $"[{Id}] - {Name}";
    }
}