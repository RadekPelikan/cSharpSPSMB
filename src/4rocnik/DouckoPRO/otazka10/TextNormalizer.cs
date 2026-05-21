public class TextNormalizer
{
    private string[] _invalidValues = [".", "!?", "@@", "??", "!!", "()"];

    public string Normalize(string text)
    {
        foreach (var invalidValue in _invalidValues)
        {
            text = text.Replace(invalidValue, "");
        }

        if (string.IsNullOrEmpty(text))
            throw new TextNormalizationException();

        return text;
    }
}