namespace CustomExceptions.Tests;

public class UnitTest1
{
    [Fact]
    public void StudentIsMissing_Standa_WithoutStanda()
    {
        // Arrange
        StudentMissing studentMissing = new StudentMissing("Tadeas", "Lukas", "Matej", "Michal", "Roman");

        // Act + Assert
        Assert.Throws<TiCoViException>(() => studentMissing.IsStudentMissing("Standa"));
    }

    [Fact]
    public void StudentIsMissing_Standa_WithStanda()
    {
        // Arrange
        StudentMissing studentMissing = new StudentMissing("Tadeas", "Lukas", "Matej", "Michal", "Standa");

        // Act
        bool isStandaMissing = studentMissing.IsStudentMissing("Standa");

        // Assert
        Assert.False(isStandaMissing);
    }

    [Theory]
    [InlineData(true, "Tadeas", "Lukas")]
    [InlineData(true, "Tadeas", "Roman")]
    [InlineData(false, "Standa", "Roman", "Ondra")]
    [InlineData(true, "Roman", "Ondra")]
    [InlineData(false, "Roman", "Ondra", "Standa", "Zdarsky")]
    public void StudentIsMissing_Standa_WithInlineData(bool isStandaMissing, params string[] names)
    {
        // Arrange
        StudentMissing studentMissing = new StudentMissing(names);

        // Act + Assert
        if (isStandaMissing)
            Assert.Throws<TiCoViException>(() => studentMissing.IsStudentMissing("Standa"));
        else
        {
            bool isStandaMissingResult = studentMissing.IsStudentMissing("Standa");
            Assert.False(isStandaMissingResult);
        }
    }

    [Fact]
    public void StudentIsMissing_Pavel_Results_True()
    {
        // Arrange
        StudentMissing studentMissing = new StudentMissing("Tadeas", "Matej", "Ondra");

        // Act + Assert
        Assert.Throws<TiCoViException>(() => studentMissing.IsStudentMissing("Lukas"));
    }

    [Fact]
    public void StudentIsMissing_Pavel_Results_False()
    {
        // Arrange
        StudentMissing studentMissing = new StudentMissing("Tadeas", "Matej", "Lukas");

        // Act
        bool isPavelMissing = studentMissing.IsStudentMissing("Lukas");
        
        // Assert
        Assert.NotNull(isPavelMissing);
        Assert.False(isPavelMissing);
    }
}