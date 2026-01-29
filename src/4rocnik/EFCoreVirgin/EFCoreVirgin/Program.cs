// See https://aka.ms/new-console-template for more information

using EFCoreVirgin;
using EFCoreVIrgin.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

var dbContext = new AppDbContext();

dbContext.Database.Migrate();

var students = dbContext.Students.ToList();

Console.WriteLine("test");

