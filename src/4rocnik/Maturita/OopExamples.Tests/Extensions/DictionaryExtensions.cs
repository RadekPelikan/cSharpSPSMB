namespace OopExamples.Tests.Extensions;

public static class DictionaryExtensions
{
    public static Dictionary<string, object> AddProperty(this Dictionary<string, object> properties, string propertyName, object propertyValue)
    {
        properties[propertyName] = propertyValue;
        return properties;
    }
}