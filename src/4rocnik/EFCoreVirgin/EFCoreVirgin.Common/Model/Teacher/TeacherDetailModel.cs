using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TeacherDetailModel : TeacherEditModel, IBaseDetailModel
{
    public required int Id { get; set; }
    public  int ClassCount => Classs?.Count ?? 0;

    public  required List<ClassModel>? Classs { get; set; } = new List<ClassModel>();
}