namespace CustomExceptions.Tests;

public class UnitTest1
{
    [Fact]
    public void StandaIsMissing_WithoutStanda()
    {
        // Arrange
        StandaMissing standaMissing = new StandaMissing("Tadeas", "Lukas", "Matej", "Michal", "Roman");

        // Act + Assert
        Assert.Throws<TiCoViException>(() => standaMissing.IsStandaMissing());
    }

    [Fact]
    public void StandaIsMissing_WithStanda()
    {
        // Arrange
        StandaMissing standaMissing = new StandaMissing("Tadeas", "Lukas", "Matej", "Michal", StandaMissing.Standa);

        // Act
        bool isStandaMissing = standaMissing.IsStandaMissing();

        // Assert
        Assert.False(isStandaMissing);
    }

    [Theory]
    [InlineData(true, "Tadeas", "Lukas")]
    [InlineData(true, "Tadeas", "Roman")]
    [InlineData(false, StandaMissing.Standa, "Roman", "Ondra")]
    [InlineData(true, "Roman", "Ondra")]
    [InlineData(false, "Roman", "Ondra", StandaMissing.Standa, "Zdarsky")]
    public void StandaIsMissing_WithInlineData(bool isStandaMissing, params string[] names)
    {
        // Arrange
        StandaMissing standaMissing = new StandaMissing(names);

        // Act + Assert
        if (isStandaMissing)
            Assert.Throws<TiCoViException>(() => standaMissing.IsStandaMissing());
        else
        {
            bool isStandaMissingResult = standaMissing.IsStandaMissing();
            Assert.False(isStandaMissingResult);
        }
    }
}