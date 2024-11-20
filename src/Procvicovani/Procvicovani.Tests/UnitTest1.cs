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

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void CellAlive_WithNeighbours_ResultsAlive(int numOfNeighbours)
    {
        // Arrange + Act
        bool isAlive = Cell.IsAliveWithNeighbours(numOfNeighbours);
        
        // Assert
        Assert.True(isAlive);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(5)]
    public void CellAlive_WithNeighbours_ResultsDead(int numOfNeighbours)
    {
        // Arrange + Act
        bool isAlive = Cell.IsAliveWithNeighbours(numOfNeighbours);
        
        // Assert
        Assert.False(isAlive);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    [InlineData(-5)]
    public void CellAlive_WithNeighbours_ResultsDead(int numOfNeighbours)
    {
        // Arrange + Act + Assert
        Assert.Throws<InvalidDataException>(() => Cell.IsAliveWithNeighbours(numOfNeighbours));
        
    }
}