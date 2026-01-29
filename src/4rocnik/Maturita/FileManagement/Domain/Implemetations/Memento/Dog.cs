using System;

namespace StrategyPattern
{
    public class Dog
    {
        public string Name;
        public int Age;
        public int NumberOfBarks;
        public bool IsHungry;

        public Dog(string name, int age, int numberOfBarks, bool isHungry)
        {
            Name = name;
            Age = age;
            NumberOfBarks = numberOfBarks;
            IsHungry = isHungry;
        }

        public override string ToString()
        {
            return $"Dog named: {Name} is {Age} y.o., barked {NumberOfBarks} times and {(IsHungry ? "is hungry" : "isnt hungry")}";
        }
    }
}