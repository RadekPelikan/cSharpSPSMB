using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record GradeEditModel : IBaseEditModel
{
    public int Value { get; set; }

    public double Weight { get; set; }
    
    public int StudentId { get; set; }
    
    public int SubjectId { get; set; }
}