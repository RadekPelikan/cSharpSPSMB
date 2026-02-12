using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TeacherModel :TeacherEditModel, IBaseModel
{
    public required int Id { get; set; }
    
    public required int ClassCount { get; set; }
}