using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EFCoreVirgin.Data.EF.Tests;

public class ProfileRepositoryTests
{
    private AppDbContext CreateInMemoryContext(out int studentId)
    {
        var connection = new SqliteConnection("DataSource=virgin.db");
        connection.Open();

        var context = new AppDbContext();
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        context.Database.ExecuteSqlRaw("PRAGMA foreign_keys = ON;");
        
        var classEntity = new ClassEntity { Name = "Test Class" };
        context.Classes.Add(classEntity);
        context.SaveChanges();
        
        var student = new StudentEntity
        {
            Name = "Test Student",
            ClassId = classEntity.Id,
            Class = classEntity
        };
        context.Students.Add(student);
        context.SaveChanges();

        studentId = student.Id;
        return context;
    }

    [Fact]
    public void Add_Should_Add_Profile()
    {
        var context = CreateInMemoryContext(out var studentId);
        var repo = new ProfileRepository(context);

        var student = context.Students.First(s => s.Id == studentId);

        var profile = new ProfileEntity { Bio = "Bio 1", StudentId = studentId, Student = student };
        var added = repo.Add(profile);

        Assert.NotNull(added);
        Assert.Equal("Bio 1", added.Bio);
        Assert.Equal(studentId, added.StudentId);
        Assert.True(repo.GetAll().Any(p => p.Bio == "Bio 1"));
    }

    [Fact]
    public void GetAll_Should_Return_All_Profiles()
    {
        var context = CreateInMemoryContext(out var studentId);
        var repo = new ProfileRepository(context);

        var student = context.Students.First(s => s.Id == studentId);
        
        repo.Add(new ProfileEntity { Bio = "Bio B", StudentId = studentId, Student = student });

        var all = repo.GetAll();

        Assert.True(all.Count >= 2);
        Assert.True(all.Any(p => p.Bio == "Bio B"), "Profile 'Bio B' not found");
    }

    [Fact]
    public void GetById_Should_Return_Correct_Profile()
    {
        var context = CreateInMemoryContext(out var studentId);
        var repo = new ProfileRepository(context);

        var student = context.Students.First(s => s.Id == studentId);

        var profile = repo.Add(new ProfileEntity { Bio = "Bio X", StudentId = studentId, Student = student });
        var fetched = repo.GetById(profile.Id);

        Assert.NotNull(fetched);
        Assert.Equal(profile.Id, fetched.Id);
        Assert.Equal("Bio X", fetched.Bio);
    }

    [Fact]
    public void Update_Should_Modify_Profile()
    {
        var context = CreateInMemoryContext(out var studentId);
        var repo = new ProfileRepository(context);

        var student = context.Students.First(s => s.Id == studentId);

        var profile = repo.Add(new ProfileEntity { Bio = "Old Bio", StudentId = studentId, Student = student });
        profile.Bio = "Updated Bio";

        var updated = repo.Update(profile);

        Assert.Equal("Updated Bio", updated.Bio);

        var dbProfile = repo.GetById(profile.Id);
        Assert.Equal("Updated Bio", dbProfile.Bio);
    }

    [Fact]
    public void Remove_Should_Delete_Profile()
    {
        var context = CreateInMemoryContext(out var studentId);
        var repo = new ProfileRepository(context);

        var student = context.Students.First(s => s.Id == studentId);

        var profile = repo.Add(new ProfileEntity { Bio = "To Delete", StudentId = studentId, Student = student });
        var removed = repo.Remove(profile.Id);

        Assert.Equal(profile.Id, removed.Id);
        Assert.False(repo.GetAll().Any(p => p.Id == profile.Id));
    }
}
