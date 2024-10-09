using System;

namespace StartingAgain
{
    public class Character
    {
        public string Name;
        public Inventory MyInventory;

        public Character(string name, Inventory myInventory)
        {
            Name = name;
            MyInventory = myInventory;
        }

        public void PrintInventory()
        {
            Console.WriteLine("Pepa Inventory: ");
            MyInventory.PrintMyself();
        }
    }
}
