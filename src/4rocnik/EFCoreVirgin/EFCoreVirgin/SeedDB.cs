using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin;

public static class SeedDB
{
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