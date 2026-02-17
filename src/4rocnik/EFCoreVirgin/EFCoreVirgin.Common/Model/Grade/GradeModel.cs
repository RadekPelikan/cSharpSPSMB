using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record GradeModel : GradeEditModel, IBaseModel
{
    public required int Id { get; set; }
}