using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TimeTableModel
{
    public Dictionary<DayOfWeek, TimeTableDayModel> Days { get; set; } = new Dictionary<DayOfWeek, TimeTableDayModel>();
}