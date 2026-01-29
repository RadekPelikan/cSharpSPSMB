// See https://aka.ms/new-console-template for more information

using EFCoreVirgin;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

var dbContext = new AppDbContext();

dbContext.Database.Migrate();


var dbClasses = dbContext.Classes
    .Include(e => e.Students)
    .ToList();

foreach (var classEntity in dbClasses)
{
    Console.WriteLine(classEntity);
    foreach (var student in classEntity.Students)
    {
        Console.WriteLine($"\t{nameof(StudentEntity)}[{student.Id}]: {student.Name}");
    }
}