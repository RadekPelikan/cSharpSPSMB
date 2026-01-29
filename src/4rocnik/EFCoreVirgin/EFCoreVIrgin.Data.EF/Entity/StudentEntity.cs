using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Student")]
public class StudentEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ProfileEntity Profile { get; set; }
}