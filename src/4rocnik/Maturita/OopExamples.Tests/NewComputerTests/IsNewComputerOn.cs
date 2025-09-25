namespace OopExamples.Tests;

public class IsNewComputerOn : NewComputerTests
{
    [Fact]
    public void IsOnReturns_False()
    {
        Assert.False(Computer.IsOn);
    }
    
    [Fact]
    public void PowerUp_TurnsOnPC()
    {
        Computer.PowerUp();
        Assert.True(Computer.IsOn);
    }
    
    [Fact]
    public void PowerUpAndShutDown_TurnsOffPC()
    {
        Computer.PowerUp();
        Computer.ShutDown();
        Assert.False(Computer.IsOn);
    }
    
    [Fact]
    public void PowerUpTwice_TurnsOnPC()
    {
        Computer.PowerUp();
        Computer.PowerUp();
        Assert.True(Computer.IsOn);
    }
    
    [Fact]
    public void ShutDownTwice_TurnsOnPC()
    {
        Computer.ShutDown();
        Computer.ShutDown();
        Assert.False(Computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButton_TurnsOnPC()
    {
        Computer.PressPowerButton();
        Assert.True(Computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButtonTwice_TurnsOffPC()
    {
        Computer.PressPowerButton();
        Computer.PressPowerButton();
        Assert.False(Computer.IsOn);
    }
    
    [Fact]
    public void PressPowerButtonThreeTimes_TurnsOnPC()
    {
        Computer.PressPowerButton();
        Computer.PressPowerButton();
        Computer.PressPowerButton();
        Assert.True(Computer.IsOn);
    }
}