using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Subject")]
public record SubjectEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<StudentEntity> Students { get; set; }
    public ICollection<TimeTableRecordEntity> TimeTableRecords { get; set; }
}