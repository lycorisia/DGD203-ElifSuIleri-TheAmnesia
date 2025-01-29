using System;
using System.Collections.Generic;

namespace TheAmnesiaGame
{
    [Serializable]
    public class Inventory
    {
        // Expose items as a public property for serialization
        public List<string> Items { get; set; }

        public Inventory()
        {
            Items = new List<string>();
        }

        public void AddItem(string item)
        {
            Items.Add(item);
            Console.WriteLine($"{item} added to your inventory.");
        }

        public bool HasItem(string item)
        {
            return Items.Contains(item);
        }

        public void RemoveItem(string item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                Console.WriteLine($"{item} removed from your inventory.");
            }
            else
            {
                Console.WriteLine($"{item} is not in your inventory.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("Your inventory contains:");
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}