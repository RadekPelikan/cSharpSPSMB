namespace Procvicovani.Tests;

public class UnitTest1
{
    [Fact]
    public void CellZeroZeroIsAlive_ResultsTrue()
    {
        // Arrange
        GameOfLife gameOfLife = new GameOfLife();
        gameOfLife.grid[0,0] = true;

        // Act
        bool isAlive = gameOfLife.IsAlive(0, 0);

        // Assert
        Assert.True(gameOfLife.grid.Length > 0);
        Assert.True(isAlive);
    }
    
    
    [Fact]
    public void Generation()
    {
        // Arrange
        GameOfLife gameOfLife = new GameOfLife();
        gameOfLife.grid[0,0] = true;

        // Act
        gameOfLife.NextGeneration();

        // Assert
        Assert.False(gameOfLife.grid[0,0]);
    }
}