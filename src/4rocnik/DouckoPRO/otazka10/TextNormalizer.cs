public class TextNormalizer
{
    private string[] _invalidValues = [".", "!?", "@@", "??", "!!", "()"];

    public string Normalize(string text)
    {
        foreach (var invalidValue in _invalidValues)
        {
            text = text.Replace(invalidValue, "");
        }

        return text;
    }
}