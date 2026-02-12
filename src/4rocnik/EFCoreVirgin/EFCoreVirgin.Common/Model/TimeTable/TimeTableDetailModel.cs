using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TimeTableDetailModel
{
    public Dictionary<DayOfWeek, TimeTableDayDetailModel> Days { get; set; } = new Dictionary<DayOfWeek, TimeTableDayDetailModel>();
}