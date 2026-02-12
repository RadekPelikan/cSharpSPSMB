using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TeacherModel :TeacherEditModel, IBaseModel
{
    public int Id { get; set; }
}