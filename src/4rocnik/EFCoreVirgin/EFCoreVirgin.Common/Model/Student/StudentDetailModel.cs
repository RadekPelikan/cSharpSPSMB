using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record StudentDetailModel : StudentEditModel, IBaseDetailModel
{
    public int Id { get; set; }
}