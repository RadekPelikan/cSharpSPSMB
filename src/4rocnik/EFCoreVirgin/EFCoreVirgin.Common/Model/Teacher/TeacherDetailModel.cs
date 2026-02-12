using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TeacherDetailModel : TeacherEditModel, IBaseDetailModel
{
    public int Id { get; set; }
}