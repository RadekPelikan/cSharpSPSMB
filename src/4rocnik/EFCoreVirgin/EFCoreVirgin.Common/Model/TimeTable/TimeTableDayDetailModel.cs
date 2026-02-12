namespace EFCoreVirgin.Common.Model;

public record TimeTableDayDetailModel
{
    public DayOfWeek Day { get; set; }
    public List<TeachingSubjectClassDetailModel> ClasesOfTheDay { get; set; }
}