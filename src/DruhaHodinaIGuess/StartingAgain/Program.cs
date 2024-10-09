using System;
using System.Collections.Generic;

namespace StartingAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            var pepaInventory = new Inventory();
            pepaInventory.AddItem(new Item("sekera"));
            pepaInventory.AddItem(new Item("poleno"));
            var pepa = new Character("Pepa", pepaInventory);
            
            pepa.PrintInventory();
            Console.WriteLine(pepaInventory.InventorySize());
            pepaInventory.RemoveAt(0);
            Console.WriteLine(pepaInventory.InventorySize());
            pepa.PrintInventory();
            
            Console.ReadLine();
            
          
        }
    }
}