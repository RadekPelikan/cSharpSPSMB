using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record SubjectDetailModel : SubjectEditModel, IBaseDetailModel
{
    public int Id { get; set; }
}