namespace EFCoreVirgin.Common.Model;

public record TimeTableDayModel
{
    public DayOfWeek Day { get; set; }
    public List<TeachingSubjectClassModel> ClasesOfTheDay { get; set; }
}