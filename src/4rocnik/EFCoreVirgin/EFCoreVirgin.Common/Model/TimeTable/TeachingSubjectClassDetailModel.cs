namespace EFCoreVirgin.Common.Model;

public record TeachingSubjectClassDetailModel
{
    public SubjectModel Subject { get; set; }
    
    public TeacherModel Teacher { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }

    public TimeSpan Duration => EndTime - StartTime;
}