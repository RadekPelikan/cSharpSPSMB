using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TimeTableRecordModel : TimeTableRecordEditModel, IBaseModel
{
    public required int Id { get; set; }
}