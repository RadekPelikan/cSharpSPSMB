using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace StartingAgain
{
    public class Inventory
    {
        public List<Item> ItemList;

        public Inventory()
        {
            ItemList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            ItemList.Add(item);
        }

        public Item Pop()
        {
            //  [ Item("sekera"), Item("poleno") ] 
            var last = ItemList.Last();
            ItemList.Remove(last);
            return last;
        }

        public Item RemoveAt(int index)
        {
            var itemToremove = ItemList[index];
            var removeItem = ItemList.Remove(itemToremove);
            return itemToremove;
        }


        public int InventorySize()
        {
            return ItemList.Count;
        }
        
        public void PrintMyself()
        {
            foreach (var item in ItemList)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}