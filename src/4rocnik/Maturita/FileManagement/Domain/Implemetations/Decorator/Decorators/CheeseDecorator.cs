using DecoratorExample.Interfaces;

namespace DecoratorExample.Decorators;

public class CheeseDecorator : PizzaDecorator
{
    public CheeseDecorator(IPizza pizza) : base(pizza) { }

    public override string GetContent()
    {
        return _pizza.GetContent() + " + cheese";
    }
}