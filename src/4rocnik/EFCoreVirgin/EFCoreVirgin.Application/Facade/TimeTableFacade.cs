using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class TimeTableFacade : ITimeTableFacade
{
    // Pouzij repozitare
    private ISubjectRepository SubjectRepository { get; init; }
    private ITeacherRepository TeacherRepository { get; init; }
    private IStudentRepository StudentRepository { get; init; }
    private IClassRepository ClassRepository { get; init; }
    private ITimeTableRecordRepository TimeTableRecordRepository { get; init; }

    private Dictionary<DayOfWeek, TimeTableDayDetailModel> GroupDaysOfCurrentWeekDetail(List<TimeTableRecordEntity> timeTableRecordEntities)
    {
        var now = DateTime.Now;
        var nowDayOfWeek = DateTime.Now.DayOfWeek;
        var startDate = now - new TimeSpan((int)nowDayOfWeek + 1, 0, 0, 0);
        var endDate = now + new TimeSpan((int)(7 - nowDayOfWeek), 0, 0, 0);

        var timeTableRecordsGrouped_ = timeTableRecordEntities
            .Where(e => e.StartTime > startDate && e.StartTime < endDate)
            .GroupBy(e => e.StartTime.DayOfWeek);

        var timeTableDayModels = new Dictionary<DayOfWeek, TimeTableDayDetailModel>();

        foreach (var timeTableRecordEntitiese in timeTableRecordsGrouped_)
        {
            timeTableDayModels.Add(timeTableRecordEntitiese.Key, new TimeTableDayDetailModel()
            {
                Day = timeTableRecordEntitiese.Key,
                ClasesOfTheDay = timeTableRecordEntitiese.Select(c => new TeachingSubjectClassDetailModel()
                {
                    StartTime = c.StartTime,
                    EndTime = c.StartTime + new TimeSpan(0, c.MinuteDuration, 0),
                    Subject = new SubjectModel()
                    {
                        Name = c.Subject.Name,
                    },
                    Teacher = new TeacherModel()
                    {
                        Name = c.Teacher.Name,
                    }
                }).ToList()
            });
        }

        return timeTableDayModels;
    }
    
    private Dictionary<DayOfWeek, TimeTableDayModel> GroupDaysOfCurrentWeek(List<TimeTableRecordEntity> timeTableRecordEntities)
    {
        var now = DateTime.Now;
        var nowDayOfWeek = DateTime.Now.DayOfWeek;
        var startDate = now - new TimeSpan((int)nowDayOfWeek + 1, 0, 0, 0);
        var endDate = now + new TimeSpan((int)(7 - nowDayOfWeek), 0, 0, 0);

        var timeTableRecordsGrouped_ = timeTableRecordEntities
            .Where(e => e.StartTime > startDate && e.StartTime < endDate)
            .GroupBy(e => e.StartTime.DayOfWeek);

        var timeTableDayModels = new Dictionary<DayOfWeek, TimeTableDayModel>();

        foreach (var timeTableRecordEntitiese in timeTableRecordsGrouped_)
        {
            timeTableDayModels.Add(timeTableRecordEntitiese.Key, new TimeTableDayModel()
            {
                Day = timeTableRecordEntitiese.Key,
                ClasesOfTheDay = timeTableRecordEntitiese.Select(c => new TeachingSubjectClassModel()
                {
                    StartTime = c.StartTime,
                    EndTime = c.StartTime + new TimeSpan(0, c.MinuteDuration, 0),
                    SubjectName = c.Subject.Name,
                    TeacherName = c.Teacher.Name
                }).ToList()
            });
        }

        return timeTableDayModels;
    }

    public TimeTableModel GetForClass(int id)
    {
        List<TimeTableRecordEntity> timeTableRecords_ = TimeTableRecordRepository.GetByClassId(id);
        return new TimeTableModel()
        {
            Days = GroupDaysOfCurrentWeek(timeTableRecords_)
        };
    }

    public TimeTableModel GetForTeacher(int id)
    {
        List<TimeTableRecordEntity> timeTableRecords_ = TimeTableRecordRepository.GetByTeacherId(id);
        return new TimeTableModel()
        {
            Days = GroupDaysOfCurrentWeek(timeTableRecords_)
        };
    }

    public TimeTableModel GetForStudent(int id)
    {
        List<TimeTableRecordEntity> timeTableRecords_ = TimeTableRecordRepository.GetByStudentId(id);
        return new TimeTableModel()
        {
            Days = GroupDaysOfCurrentWeek(timeTableRecords_)
        };
    }

    public TimeTableDetailModel GetDetailForClass(int id)
    {
        List<TimeTableRecordEntity> timeTableRecords_ = TimeTableRecordRepository.GetByClassId(id);
        return new TimeTableDetailModel()
        {
            Days = GroupDaysOfCurrentWeekDetail(timeTableRecords_)
        };
    }

    public TimeTableDetailModel GetDetailForTeacher(int id)
    {
        List<TimeTableRecordEntity> timeTableRecords_ = TimeTableRecordRepository.GetByTeacherId(id);
        return new TimeTableDetailModel()
        {
            Days = GroupDaysOfCurrentWeekDetail(timeTableRecords_)
        };
    }

    public TimeTableDetailModel GetDetailForStudent(int id)
    {
        List<TimeTableRecordEntity> timeTableRecords_ = TimeTableRecordRepository.GetByStudentId(id);
        return new TimeTableDetailModel()
        {
            Days = GroupDaysOfCurrentWeekDetail(timeTableRecords_)
        };
    }
}