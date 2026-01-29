// See https://aka.ms/new-console-template for more information

using EFCoreVirgin;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;


Console.WriteLine("Running!....");

var dbContext = new AppDbContext();

dbContext.Database.Migrate();


var subjectId = SeedDB.AddSubject(dbContext).Id;

var subject = dbContext.Subjects
    .Include(e => e.Students)
    .First(e => e.Id == subjectId);

Console.WriteLine(subject);
foreach (var student in subject.Students)
{
    Console.WriteLine(student);
}


