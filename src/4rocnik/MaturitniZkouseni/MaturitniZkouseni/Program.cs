// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaturitniZkouseni;
using MaturitniZkouseni.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

// vytvor entitu student a entitu class
// entita student bude mit:
// - id
// - name
// - ClassId
// - Class

// entita class bude mit:
// - id
// - name
// - ICollection<StudentEntity> Students

// udelas migrace
// Pridas do program.cs Database.Migrate()
// Pridej funkci createStudent, ktera vytvori studenta s nejakou random tridou
// Trida se taky vytvori v teto metode
// Druha Funkce: GetAllStudents, ktera ziska vsechny studenty a jejich tridu


var context = new AppDbContext();
context.Database.Migrate();


void CreateStudent()
{
    context.Student.Add(new StudentEntity()
    {
        Name = "Pepa",
        Class = new ClassEntity()
        {
            Name = "4.Ai"
        }
    });

    context.SaveChanges();
}

List<StudentEntity> GetAllStudnets()
{
    var students = context.Student.ToList();
    return students;
}

foreach (var student in GetAllStudnets())
{
    Console.WriteLine(student);
}
