using DecoratorExample.Interfaces;

namespace DecoratorExample.Decorators;

public class TomatoDecorator : PizzaDecorator
{
    public TomatoDecorator(IPizza pizza) : base(pizza) { }

    public override string GetContent()
    {
        return _pizza.GetContent() + " + tomato";
    }
}