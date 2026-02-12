using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record ClassModel : ClassEditModel, IBaseModel
{
    public int Id { get; set; }
    
    public int StudentCount { get; set; }
}