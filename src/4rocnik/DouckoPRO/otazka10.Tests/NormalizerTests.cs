namespace otazka10.Tests;

public class NormalizerTests
{
    [Fact]
    public void TextWithInvalid_ReturnNormalizedText()
    {
        // "ahoj !!" => "ahoj "
        
        // Arrange
        var text = "ahoj !!";
        var normalized = "ahoj ";
        var normalizer = new TextNormalizer();
        
        // Act
        var output = normalizer.Normalize(text);

        // Assert
        Assert.NotEmpty(output);
        Assert.Equal(normalized, output);
    }
    
    [Fact]
    public void TextWithoutInvalid_ReturnSameText()
    {
        // "ahoj" => "ahoj"
        
        // Arrange
        var text = "ahoj";
        var normalizer = new TextNormalizer();
        
        // Act
        var output = normalizer.Normalize(text);

        // Assert
        Assert.NotEmpty(output);
        Assert.Equal("ahoj", output);
    }
    
    [Fact]
    public void TextOnlyInvalid_ThrowsException()
    {
        // "!!!?" => vyhodí vyjímku
        
        // Arrange
        var text = "!!!?";
        var normalizer = new TextNormalizer();
        
        // Act + Assert
        Assert.Throws<TextNormalizationException>(() =>
        {
            // Act
            var output = normalizer.Normalize(text);
        });
    }
}