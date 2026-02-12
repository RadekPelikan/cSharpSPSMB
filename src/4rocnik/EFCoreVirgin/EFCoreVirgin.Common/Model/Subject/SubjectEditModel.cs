using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record SubjectEditModel : IBaseEditModel
{
    public string Name { get; set; }
}