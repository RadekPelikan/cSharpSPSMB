using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using EFCoreVirgin.Common.Repository;
using Xunit;

namespace EFCOreVirgin.Data.EF.Tests;

public class SubjectRepositoryTests : BaseRepositoryTests
{
    private static AppDbContext CreateFreshDbContext()
    {
        var dbFile = $"subject_tests_{Guid.NewGuid():N}.db";

        var ctx = new AppDbContext
        {
            FileName = dbFile
        };

        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        return ctx;
    }

    private static SubjectEntity NewSubject(string name)
        => new SubjectEntity { Name = name };

    [Fact]
    public void Add_ShouldAddSubject_AndReturnEntity()
    {
        using var ctx = CreateFreshDbContext();
        var repo = new SubjectRepository(ctx);

        var added = repo.Add(NewSubject("Physics"));

        Assert.NotNull(added);
        Assert.True(added.Id > 0);
        Assert.Equal("Physics", added.Name);

        var fromDb = ctx.Set<SubjectEntity>().Find(added.Id);
        Assert.NotNull(fromDb);
        Assert.Equal("Physics", fromDb!.Name);
    }

    [Fact]
    public void GetAll_ShouldReturnAllSubjects()
    {
        using var ctx = CreateFreshDbContext();
        var repo = new SubjectRepository(ctx);

        repo.Add(NewSubject("English"));
        repo.Add(NewSubject("History"));

        var all = repo.GetAll();

        Assert.NotNull(all);
        Assert.True(all.Count >= 2);
        Assert.Contains(all, s => s.Name == "English");
        Assert.Contains(all, s => s.Name == "History");
    }

    [Fact]
    public void GetById_ShouldReturnSubject_WhenExists()
    {
        using var ctx = CreateFreshDbContext();
        var repo = new SubjectRepository(ctx);

        var added = repo.Add(NewSubject("Biology"));

        var found = repo.GetById(added.Id);

        Assert.NotNull(found);
        Assert.Equal(added.Id, found.Id);
        Assert.Equal("Biology", found.Name);
    }

    [Fact]
    public void GetById_ShouldThrow_WhenNotFound()
    {
        using var ctx = CreateFreshDbContext();
        var repo = new SubjectRepository(ctx);

        Assert.ThrowsAny<Exception>(() => repo.GetById(999999));
    }

    [Fact]
    public void Update_ShouldUpdateExistingSubject()
    {
        using var ctx = CreateFreshDbContext();
        var repo = new SubjectRepository(ctx);

        var added = repo.Add(NewSubject("Chem"));
        added.Name = "Chemistry";

        var updated = repo.Update(added);

        Assert.NotNull(updated);
        Assert.Equal(added.Id, updated.Id);
        Assert.Equal("Chemistry", updated.Name);

        var fromDb = ctx.Set<SubjectEntity>().Find(added.Id);
        Assert.NotNull(fromDb);
        Assert.Equal("Chemistry", fromDb!.Name);
    }

    [Fact]
    public void Remove_ShouldRemoveExistingSubject_AndReturnRemovedEntity()
    {
        using var ctx = CreateFreshDbContext();
        var repo = new SubjectRepository(ctx);

        var added = repo.Add(NewSubject("Art"));

        var removed = repo.Remove(added.Id);

        Assert.NotNull(removed);
        Assert.Equal(added.Id, removed.Id);
        Assert.Null(ctx.Set<SubjectEntity>().Find(added.Id));
    }

    [Fact]
    public void Remove_ShouldThrow_WhenNotFound()
    {
        using var ctx = CreateFreshDbContext();
        var repo = new SubjectRepository(ctx);

        Assert.ThrowsAny<Exception>(() => repo.Remove(888888));
    }
}
