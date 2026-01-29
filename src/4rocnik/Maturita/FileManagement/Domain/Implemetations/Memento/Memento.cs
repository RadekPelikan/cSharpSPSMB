using System;

namespace StrategyPattern
{
    public static class Memento
    {
        private static Dog _savedDog;
        public static void Save(Dog savedDog)
        {
            _savedDog = new Dog(savedDog.Name, savedDog.Age, savedDog.NumberOfBarks, savedDog.IsHungry);
        }

        public static Dog GetSavedDog()
        {
            return _savedDog;
        }
        
        
    }
}