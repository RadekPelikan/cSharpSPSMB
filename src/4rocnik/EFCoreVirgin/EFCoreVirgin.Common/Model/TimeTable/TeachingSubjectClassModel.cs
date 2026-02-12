namespace EFCoreVirgin.Common.Model;

public record TeachingSubjectClassModel
{
    public string SubjectName { get; set; }
    
    public string TeacherName { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }

    public TimeSpan Duration => EndTime - StartTime;
}