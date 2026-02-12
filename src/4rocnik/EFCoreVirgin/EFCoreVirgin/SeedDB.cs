using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin;

public static class SeedDB
{
    public static TimeTableRecordEntity TimeTableRecord(AppDbContext dbContext)
    {
        var subject = AddSubject(dbContext);
        var teacher = AddTeacher(dbContext);
        var _class = subject.Students.First().Class;

        var now = DateTime.Now;
        var startTime = new DateTime(now.Year, now.Month, now.Day, 7, 55, 0);
        var timeTableRecord = new TimeTableRecordEntity()
        {
            Subject = subject,
            Teacher = teacher,
            Class = _class,
            StartTime = startTime,
            MinuteDuration = 90
        };

        dbContext.TimeTableRecords.Add(timeTableRecord);
        dbContext.SaveChanges();
        return timeTableRecord;
    }

    public static TeacherEntity AddTeacher(AppDbContext dbContext)
    {
        var teacher = new TeacherEntity()
        {
            Name = "Teacher entity",
        };
        dbContext.Teachers.Add(teacher);
        dbContext.SaveChanges();

        return teacher;
    }
    
    public static SubjectEntity AddSubject(AppDbContext dbContext)
    {
        var myClass = AddClass(dbContext);
        var student = new StudentEntity()
        {
            Name = "Honza",
            Class = myClass
        };

        var subject = new SubjectEntity()
        {
            Name = "Programko",
            Students = new List<StudentEntity>() { {student}}
        };

        dbContext.Subjects.Add(subject);
        dbContext.SaveChanges();

        return subject;
    }

    public static ClassEntity AddClass(AppDbContext dbContext)
    {
        var myClass = new ClassEntity()
        {
            Name = "4.Ai"
        };

        var students = new List<StudentEntity>();

        for (int i = 0; i < 10; i++)
        {
            students.Add(
                new StudentEntity()
                {
                    Name = $"Pepa_class_{i + 1}",
                    Class = myClass
                }
            );
        }

        dbContext.Classes.Add(myClass);
        dbContext.Students.AddRange(students);

        dbContext.SaveChanges();

        return myClass;
    }
}