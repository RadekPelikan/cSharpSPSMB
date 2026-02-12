using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record StudentEditModel : IBaseEditModel
{
    
    public string Name { get; set; }

    public int ClassId { get; set; }
}