using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TeacherEditModel : IBaseEditModel
{
    public string Name { get; set; }
}