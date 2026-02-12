// See https://aka.ms/new-console-template for more information

using EFCoreVirgin;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;


Console.WriteLine("Running!....");

var dbContext = new AppDbContext();

dbContext.Database.Migrate();

// var profileRepository = new ProfileRepository();

var timeTableRecordId = SeedDB.TimeTableRecord(dbContext).Id;

var timeTable = dbContext.TimeTableRecords
    .Include(e => e.Subject)
    .Include(e => e.Teacher)
    .Include(e => e.Class)
    .ThenInclude(e => e.Students)
    .First(e => e.Id == timeTableRecordId);

Console.WriteLine("TimeTableRecord:");
Console.WriteLine(timeTable);
foreach (var student in timeTable.Class.Students)
{
    Console.WriteLine(student);
}

















