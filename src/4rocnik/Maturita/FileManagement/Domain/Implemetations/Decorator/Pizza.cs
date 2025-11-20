using DecoratorExample.Interfaces;

namespace DecoratorExample;

public class Pizza : IPizza
{
    public string GetContent()
    {
        return "Pizza";
    }
}