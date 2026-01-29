using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin;

public static class SeedDB
{
    public static SubjectEntity AddSubject(AppDbContext dbContext)
    {
        var myClass = new ClassEntity()
        {
            Name = "4.Ai"
        };
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

    public static void AddClass(AppDbContext dbContext)
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
    }
}