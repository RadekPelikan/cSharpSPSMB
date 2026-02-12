using EFCoreVirgin.Common.Repository;

namespace EFCOreVirgin.Data.EF.Tests;

public class StudentRepositoryTests : BaseRepositoryTests
{
    private IStudentRepository StudentRepository;

    // public StudentRepositoryTests()
    // {
    //     _subjectRepository = new StudentRepository(DbContext);
    // }

    // Test every method
    
    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }
}