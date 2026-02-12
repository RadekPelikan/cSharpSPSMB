using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Subject")]
public record SubjectEntity  : BaseEntity
{

    public string Name { get; set; }

    public ICollection<StudentEntity> Students { get; set; }
    public ICollection<TimeTableRecordEntity> TimeTableRecords { get; set; }
}