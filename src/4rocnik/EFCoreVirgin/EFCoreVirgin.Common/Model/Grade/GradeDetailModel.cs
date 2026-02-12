using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record GradeDetailModel : GradeEditModel, IBaseDetailModel
{
    public required int Id { get; set; }
    
    public required StudentModel Student { get; set; }
    
    public required SubjectModel Subject { get; set; }
}