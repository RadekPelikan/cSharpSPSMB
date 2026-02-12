using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record ClassEditModel : IBaseEditModel
{
    public string Name { get; set; }
}