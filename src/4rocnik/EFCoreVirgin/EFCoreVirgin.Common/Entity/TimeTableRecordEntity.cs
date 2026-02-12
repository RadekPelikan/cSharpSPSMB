using System.ComponentModel.DataAnnotations.Schema;
using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table("TimeTableRecord")]
public record TimeTableRecordEntity : BaseEntity
{
    public int SubjectId { get; set; }
    public SubjectEntity Subject { get; set; }

    public int TeacherId { get; set; }
    public TeacherEntity Teacher { get; set; }

    public int ClassId { get; set; }
    public ClassEntity Class { get; set; }

    public DateTime StartTime { get; set; }
    public int MinuteDuration { get; set; }
}
