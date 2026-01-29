// See https://aka.ms/new-console-template for more information

using EFCoreVirgin;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

var dbContext = new AppDbContext();

dbContext.Database.Migrate();

var student = new StudentEntity()
{
    Name = "Pepa2"
};

dbContext.Students.Add(student);

dbContext.SaveChanges();

var students = dbContext.Students.ToList();


foreach (var studentEntity in students)
{
    Console.WriteLine(studentEntity);
}

