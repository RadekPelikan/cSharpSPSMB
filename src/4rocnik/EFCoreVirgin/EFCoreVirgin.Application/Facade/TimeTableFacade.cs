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
    private ITimeTableRecordRepository TimeTableRecordRepository { get; init; }
    private IClassRepository ClassRepository { get; init; }

    public TimeTableModel GetForClass(int id)
    {
        var class_ = ClassRepository.GetById(id);
        List<TimeTableRecordEntity> timeTableRecords_ = TimeTableRecordRepository.GetByClassId(id);


        var now = DateTime.Now;
        var nowDayOfWeek = DateTime.Now.DayOfWeek;
        var startDate = now - new TimeSpan((int)nowDayOfWeek + 1, 0, 0, 0);
        var endDate = now + new TimeSpan((int)(7 - nowDayOfWeek), 0, 0, 0);

        var timeTableRecordsGrouped_ = timeTableRecords_
            .Where(e => e.StartTime > startDate && e.StartTime < endDate)
            .GroupBy(e => e.StartTime.DayOfWeek)

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

        return new TimeTableModel()
        {
            Days = timeTableDayModels
        };
    }

    public TimeTableModel GetForTeacher(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableModel GetForStudent(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableDetailModel GetDetailForClass(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableDetailModel GetDetailForTeacher(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableDetailModel GetDetailForStudent(int id)
    {
        throw new NotImplementedException();
    }
}