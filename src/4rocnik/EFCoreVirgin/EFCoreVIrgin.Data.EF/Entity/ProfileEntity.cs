using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Profile")]
public class ProfileEntity
{
    public int Id { get; set; }
    public string Bio { get; set; }
    
    public int StudentId { get; set; }
    public StudentEntity Student { get; set; }
}