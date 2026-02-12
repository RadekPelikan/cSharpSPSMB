using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TimeTableRecordDetailModel : TimeTableRecordEditModel, IBaseDetailModel
{
    public required int Id { get; set; }
}