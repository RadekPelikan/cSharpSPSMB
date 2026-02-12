using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record StudentModel : StudentEditModel, IBaseModel
{
    public required int Id { get; set; }
    
    public required string ClassName { get; set; }
}