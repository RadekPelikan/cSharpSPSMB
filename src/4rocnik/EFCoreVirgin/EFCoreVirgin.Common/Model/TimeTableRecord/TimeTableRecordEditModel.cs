using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TimeTableRecordEditModel : IBaseEditModel
{
    
    public DateTime StartTime { get; set; }
    public int MinuteDuration { get; set; }
}