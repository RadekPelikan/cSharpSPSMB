using OopExamples.Interfaces.Exceptions;

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
    [InlineData("4 + 5", 9)]
    [InlineData("\t4 + 5", 9)]
    [InlineData("\t4 \t+ 5", 9)]
    [InlineData("\t4 \t+ 5\t", 9)]
    [InlineData("\n4 \n+ 5\n", 9)]
    [InlineData("\n4 \n+\n\t \t 5\n", 9)]
    public void ComputeEquationsWithDifferentWhitespace_Equal(string equation, float result)
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

    [Theory]
    [InlineData("4 + 5 f")]
    [InlineData("f 4 - 8")]
    [InlineData("  9 * b   8 ")]
    [InlineData(" 9 / / 2")]
    [InlineData(" 9 / * 2")]
    [InlineData(" 9  // * 2")]
    [InlineData(" 9  b 2")]
    [InlineData(" 9 * b *  2")]
    [InlineData(" 9 **  2")]
    public void ComputeEquations_InvalidEquation_ThrowsInvalidEquation(string equation)
    {
        Assert.Throws<InvalidEquationException>(() =>
        {
            Computer.Compute(equation);
        });
    }
}