using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record SubjectModel : SubjectEditModel, IBaseModel
{
    public required int Id { get; set; }
    
    public required int StudentCount { get; set; }
    
    public required int TeacherCount { get; set; }
}