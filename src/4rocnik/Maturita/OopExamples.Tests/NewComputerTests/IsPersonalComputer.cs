namespace OopExamples.Tests;

public class IsPersonalComputer : NewComputerTests
{
    [Fact]
    public void NewComputer_IsPersonal_False()
    {
        Assert.Null(Computer.Owner);
        Assert.False(Computer.IsPersonalPC);
    }
    
    [Fact]
    public void IsPersonal_WithNoOwner_False()
    {
        Computer.ChangeOwner(null);
        
        Assert.Null(Computer.Owner);
        Assert.False(Computer.IsPersonalPC);
    }    
    
    [Fact]
    public void IsPersonal_RemovedOwner_False()
    {
        Computer.RemoveOwner();
        
        Assert.Null(Computer.Owner);
        Assert.False(Computer.IsPersonalPC);
    } 
    
    [Fact]
    public void IsPersonal_RemovedOwnerTwice_False()
    {
        Computer.RemoveOwner();
        Computer.RemoveOwner();
        
        Assert.Null(Computer.Owner);
        Assert.False(Computer.IsPersonalPC);
    }
    
    [Fact]
    public void IsPersonal_WithPerson_True()
    {
        Computer.ChangeOwner(Person);
        
        Assert.NotNull(Computer.Owner);
        Assert.True(Computer.IsPersonalPC);
    }
    
    [Fact]
    public void IsPersonal_WithCompany_False()
    {
        Computer.ChangeOwner(Company);
            
        Assert.NotNull(Computer.Owner);
        Assert.False(Computer.IsPersonalPC);
    }

}