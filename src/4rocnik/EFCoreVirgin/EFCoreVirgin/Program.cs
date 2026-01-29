// See https://aka.ms/new-console-template for more information

using EFCoreVirgin;
using EFCoreVIrgin.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var password = Helpers.ReadSecret("Enter password: ");

var dbContext = new AppDbContext() { Password = password};

var students = dbContext.Students.ToList();

Console.WriteLine("test");

