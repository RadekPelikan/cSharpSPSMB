using OopExamples.Interfaces;

namespace OopExamples.Tests;

public class IsComputerOn
{
    private readonly IComputer _computer;

    public IsComputerOn()
    {
        // Create instance of IComputer, using your implementation
        _computer = null;
        
        // Do not touch this
        _computer = _computer ?? throw new System.NotImplementedException($"{nameof(_computer)} not implemented");
    }
    
    [Fact]
    public void IsOnReturns_False()
    {
        Assert.False(_computer.IsOn);
    }
    
    [Fact]
    public void PowerUp_TurnsOnPC()
    {
        _computer.PowerUp();
        Assert.True(_computer.IsOn);
    }
    
    [Fact]
    public void PowerUpAndShutDown_TurnsOffPC()
    {
        _computer.PowerUp();
        _computer.ShutDown();
        Assert.False(_computer.IsOn);
    }
    
    [Fact]
    public void PowerUpTwice_TurnsOnPC()
    {
        _computer.PowerUp();
        _computer.PowerUp();
        Assert.True(_computer.IsOn);
    }
    
    [Fact]
    public void ShutDownTwice_TurnsOnPC()
    {
        _computer.ShutDown();
        _computer.ShutDown();
        Assert.False(_computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButton_TurnsOnPC()
    {
        _computer.PressPowerButton();
        Assert.True(_computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButtonTwice_TurnsOffPC()
    {
        _computer.PressPowerButton();
        _computer.PressPowerButton();
        Assert.True(_computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButtonThreeTimes_TurnsOnPC()
    {
        _computer.PressPowerButton();
        _computer.PressPowerButton();
        _computer.PressPowerButton();
        Assert.True(_computer.IsOn);
    }
}