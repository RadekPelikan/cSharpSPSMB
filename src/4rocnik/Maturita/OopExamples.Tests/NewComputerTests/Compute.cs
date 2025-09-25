namespace OopExamples.Tests;

public class Compute : NewComputerTests
{
    [Theory]
    [InlineData("4 + 5", 9)]
    [InlineData("4 - 8", -4)]
    [InlineData("9 *   8 ", 72)]
    [InlineData(" 9 / 2", 4.5)]
    public void ComputeEquations_Equal(string equation, float result)
    {
        Assert.Equal(Computer.Compute(equation), result);
    }

    [Theory]
    [InlineData("4 + 5", 45)]
    [InlineData("4 - 8", 8)]
    [InlineData("  9 *   8 ", 4)]
    [InlineData(" 9 / 2", 5)]
    [InlineData(" 9 / 2", 4)]
    public void ComputeEquations_NotEqual(string equation, float result)
    {
        Assert.NotEqual(Computer.Compute(equation), result);
    }
}