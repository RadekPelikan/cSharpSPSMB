// See https://aka.ms/new-console-template for more information

using EFCoreVirgin;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;


Console.WriteLine("Running!....");


var now = DateTime.Now;
var nowDayOfWeek = DateTime.Now.DayOfWeek;
var startDate = now - new TimeSpan((int)nowDayOfWeek + 1, 0, 0, 0);
var endDate = now + new TimeSpan((int)(7 - nowDayOfWeek), 0, 0, 0);

Console.WriteLine($"{startDate} - {endDate}");

// var dbContext = new AppDbContext();
//
// dbContext.Database.Migrate();
//
//
// var timeTableRecordId = SeedDB.TimeTableRecord(dbContext).Id;
//
// var timeTable = dbContext.TimeTableRecords
//     .Include(e => e.Subject)
//     .Include(e => e.Teacher)
//     .Include(e => e.Class)
//     .ThenInclude(e => e.Students)
//     .First(e => e.Id == timeTableRecordId);
//
// Console.WriteLine(timeTable);
// foreach (var student in timeTable.Class.Students)
// {
//     Console.WriteLine(student);
// }
//
//
