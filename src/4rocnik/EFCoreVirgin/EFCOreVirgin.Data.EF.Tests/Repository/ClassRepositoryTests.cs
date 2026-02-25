using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCOreVirgin.Data.EF.Tests;

public class ClassRepositoryTests : BaseRepositoryTests
{
    public readonly AppDbContext _dbContext;
    public readonly ClassRepository _classRepository;
    
    public ClassRepositoryTests()
    {
        _dbContext = new AppDbContext();
        _classRepository = new ClassRepository(_dbContext);
    }

    [Fact]
    public void GetAll_ReturnsClasses()
    {
        var result =  _classRepository.GetAll();
        Assert.NotEmpty(result);
    }
    
    [Fact]
    public void GetById_ReturnsClass_WhenExists()
    {
        var existing = _dbContext.Classes.First();
        var result = _classRepository.GetById(existing.Id);
        Assert.NotNull(result);
        Assert.Equal(existing.Name, result.Name);
    }
    
    [Fact]
    public void GetById_ReturnsNull_WhenNotExists()
    {
        var result = _classRepository.GetById(-1);
        Assert.Null(result);
    }
    
    [Fact]
    public void Add_AddsClass()
    {
        var newClass = new ClassEntity { Name = "Test Class" };
        var added = _classRepository.Add(newClass);

        Assert.NotNull(added);
        Assert.Equal("Test Class", added.Name);

        var all = _classRepository.GetAll();
        Assert.Contains(all, c => c.Name == "Test Class");
    }
    
    [Fact]
    public void Update_UpdatesClass()
    {
        var existing = _dbContext.Classes.First();
        existing.Name = "Updated Name";
        var updated = _classRepository.Update(existing);

        Assert.Equal("Updated Name", updated.Name);

        var fromDb = _classRepository.GetById(existing.Id);
        Assert.Equal("Updated Name", fromDb.Name);
    }
    [Fact]
    public void Remove_DeletesClass()
    {
        var existing = _dbContext.Classes.First();
        var removed = _classRepository.Remove(existing.Id);

        Assert.Equal(existing.Id, removed.Id);
        Assert.Null(_classRepository.GetById(existing.Id));
    }
    
}