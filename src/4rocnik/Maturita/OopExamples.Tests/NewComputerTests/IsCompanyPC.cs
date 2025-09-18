namespace OopExamples.Tests;

public class IsCompanyPC : NewComputerTests
{
    [Fact]
    public void NewComputer_IsCompany_False()
    {
        Assert.Null(Computer.Owner);
        Assert.False(Computer.IsCompanyPC);
    }
    
    [Fact]
    public void IsCompany_WithNoOwner_True()
    {
        Computer.ChangeOwner(null);
        
        Assert.Null(Computer.Owner);
        Assert.False(Computer.IsCompanyPC);
    }    
    
    [Fact]
    public void IsCompany_RemovedOwner_True()
    {
        Computer.RemoveOwner();
        
        Assert.Null(Computer.Owner);
        Assert.False(Computer.IsCompanyPC);
    } 
    
    [Fact]
    public void IsCompany_RemovedOwnerTwice_True()
    {
        Computer.RemoveOwner();
        Computer.RemoveOwner();
        
        Assert.Null(Computer.Owner);
        Assert.False(Computer.IsCompanyPC);
    }
    
    [Fact]
    public void IsCompany_WithCompany_True()
    {
        Computer.ChangeOwner(Company);
        
        Assert.NotNull(Computer.Owner);
        Assert.True(Computer.IsCompanyPC);
    }
    
    [Fact]
    public void IsCompany_WithPerson_True()
    {
        Computer.ChangeOwner(Person);
            
        Assert.NotNull(Computer.Owner);
        Assert.False(Computer.IsCompanyPC);
    }
}