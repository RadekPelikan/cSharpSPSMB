using System;
using NUnit.Framework;

namespace Tests.Calculator
{
    [TestFixture]
    public class Tests
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
    }
}