using DecoratorExample;
using DecoratorExample.Decorators;
using DecoratorExample.Interfaces;

class Program
{
    static void Main()
    {
        IPizza pizza = new Pizza();
        Console.WriteLine(pizza.GetContent());
        
        IPizza pizzaWithTomato = new TomatoDecorator(pizza);
        Console.WriteLine(pizzaWithTomato.GetContent());
        
        IPizza pizzaWithCheese = new CheeseDecorator(pizza);
        Console.WriteLine(pizzaWithCheese.GetContent());
        
        IPizza pizzaWithCheeseAndTomato  = new TomatoDecorator(pizzaWithCheese);
        Console.WriteLine(pizzaWithCheeseAndTomato.GetContent());
    }
}