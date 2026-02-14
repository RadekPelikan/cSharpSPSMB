using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;
using EFCOreVirgin.Data.EF.Tests;

public class ProfileRepositoryTests : BaseRepositoryTests
{
    private readonly ProfileRepository _profileRepository;

    public ProfileRepositoryTests()
    {
        _profileRepository = new ProfileRepository(DbContext);
    }

    [Fact]
    public void GetAll_ReturnsProfiles()
    {
        var result = _profileRepository.GetAll();
        Assert.NotEmpty(result);
    }

    [Fact]
    public void GetById_ReturnsProfile_WhenExists()
    {
        var existing = DbContext.Profiles.First();

        var result = _profileRepository.GetById(existing.Id);

        Assert.NotNull(result);
        Assert.Equal(existing.Bio, result.Bio);
    }

    [Fact]
    public void GetById_ReturnsNull_WhenNotExists()
    {
        var result = _profileRepository.GetById(-1);
        Assert.Null(result);
    }

    [Fact]
    public void Add_AddsProfile()
    {
        var newStudent = new StudentEntity
        {
            Name = "Test Student " + Guid.NewGuid(),
            ClassId = DbContext.Classes.First().Id
        };
        DbContext.Students.Add(newStudent);
        DbContext.SaveChanges();
        
        var newProfile = new ProfileEntity
        {
            Bio = "Test Bio",
            StudentId = newStudent.Id
        };
        
        var added = _profileRepository.Add(newProfile);

        // 4️⃣ Ověříme, že profil byl přidán
        Assert.NotNull(added);
        Assert.Equal("Test Bio", added.Bio);

        var all = _profileRepository.GetAll();
        Assert.Contains(all, p => p.Bio == "Test Bio" && p.StudentId == newStudent.Id);
    }


    [Fact]
    public void Update_UpdatesProfile()
    {
        var existing = DbContext.Profiles.First();
        existing.Bio = "Updated Bio";

        var updated = _profileRepository.Update(existing);

        Assert.Equal("Updated Bio", updated.Bio);

        var fromDb = _profileRepository.GetById(existing.Id);
        Assert.Equal("Updated Bio", fromDb.Bio);
    }

    [Fact]
    public void Remove_DeletesProfile()
    {
        var existing = DbContext.Profiles.First();

        var removed = _profileRepository.Remove(existing.Id);

        Assert.Equal(existing.Id, removed.Id);
        Assert.Null(_profileRepository.GetById(existing.Id));
    }
}
