using DecoratorExample.Interfaces;

namespace DecoratorExample.Decorators;

public abstract class PizzaDecorator : IPizza
{
    protected IPizza _pizza;

    public PizzaDecorator(IPizza pizza)
    {
        _pizza = pizza;
    }

    public abstract string GetContent();
}