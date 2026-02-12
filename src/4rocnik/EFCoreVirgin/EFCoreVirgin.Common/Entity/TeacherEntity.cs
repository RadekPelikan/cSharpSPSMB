using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("Teacher")]
public record TeacherEntity : BaseEntity
{
    public string Name { get; set; }
    
    public ICollection<TimeTableRecordEntity> TimeTableRecords { get; set; }
}