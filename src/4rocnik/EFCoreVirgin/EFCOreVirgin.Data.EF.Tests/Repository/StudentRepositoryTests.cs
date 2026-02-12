using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCOreVirgin.Data.EF.Tests;

public class StudentRepositoryTests : BaseRepositoryTests
{
    private readonly StudentRepository _studentRepository;

    public StudentRepositoryTests()
    {
        _studentRepository = new StudentRepository(DbContext);
    }

    private ClassEntity CreateClass(int id = 1)
    {
        var classEntity = new ClassEntity
        {
            Id = id,
            Name = $"Class {id}"
        };

        DbContext.Classes.Add(classEntity);
        DbContext.SaveChanges();
        return classEntity;
    }

    private StudentEntity CreateStudent(int id, string name, int classId)
    {
        var student = new StudentEntity
        {
            Id = id,
            Name = name,
            ClassId = classId
        };

        DbContext.Students.Add(student);
        DbContext.SaveChanges();
        return student;
    }

    [Fact]
    public void Add_ShouldAddStudentWithClass()
    {
        var classEntity = CreateClass();

        var student = new StudentEntity
        {
            Name = "Martin",
            ClassId = classEntity.Id
        };

        var result = _studentRepository.Add(student);

        Assert.NotNull(result);
        Assert.Equal(1, DbContext.Students.Count());
        Assert.Equal("Martin", result.Name);
    }

    [Fact]
    public void GetById_ShouldReturnStudentWithIncludes()
    {
        var classEntity = CreateClass();
        var student = CreateStudent(1, "Petr", classEntity.Id);

        var result = _studentRepository.GetById(student.Id);

        Assert.NotNull(result);
        Assert.NotNull(result.Class); // test Include(Class)
        Assert.Equal("Petr", result.Name);
        Assert.Equal(classEntity.Id, result.ClassId);
    }

    [Fact]
    public void GetAll_ShouldReturnAllStudents()
    {
        var classEntity = CreateClass();

        CreateStudent(1, "A", classEntity.Id);
        CreateStudent(2, "B", classEntity.Id);

        var result = _studentRepository.GetAll();

        Assert.Equal(2, result.Count);
        Assert.All(result, s => Assert.NotNull(s.Class));
    }

    [Fact]
    public void Update_ShouldChangeName()
    {
        var classEntity = CreateClass();
        var student = CreateStudent(1, "OldName", classEntity.Id);

        var updated = new StudentEntity
        {
            Id = student.Id,
            Name = "NewName",
            ClassId = classEntity.Id
        };

        var result = _studentRepository.Update(updated);

        Assert.NotNull(result);
        Assert.Equal("NewName", result.Name);

        var fromDb = DbContext.Students.Find(student.Id);
        Assert.Equal("NewName", fromDb.Name);
    }

    [Fact]
    public void Update_ShouldReturnNull_WhenStudentNotExists()
    {
        var classEntity = CreateClass();

        var student = new StudentEntity
        {
            Id = 999,
            Name = "Ghost",
            ClassId = classEntity.Id
        };

        var result = _studentRepository.Update(student);

        Assert.Null(result);
    }

    [Fact]
    public void Remove_ShouldDeleteStudent()
    {
        var classEntity = CreateClass();
        var student = CreateStudent(1, "ToDelete", classEntity.Id);

        var result = _studentRepository.Remove(student.Id);

        Assert.NotNull(result);
        Assert.Empty(DbContext.Students);
    }

    [Fact]
    public void Remove_ShouldReturnNull_WhenStudentNotExists()
    {
        var result = _studentRepository.Remove(123);

        Assert.Null(result);
    }
}