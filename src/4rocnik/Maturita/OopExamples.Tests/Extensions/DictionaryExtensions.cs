namespace OopExamples.Tests.Extensions;

public static class DictionaryExtensions
{
    public static Dictionary<string, object> AddProperty(this Dictionary<string, object> properties, string propertyName, object protertyValue)
    {
        properties.Add(propertyName, protertyValue);
        return properties; 
    }
}