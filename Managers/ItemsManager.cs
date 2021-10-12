using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemLibrary;

namespace ItemRestAPI.Managers
{
    public class ItemsManager
    {
        private static int _nextID = 1;
        private static readonly List<Item> Data = new List<Item>
        {
            new Item{Id = _nextID++, Name="Soda", ItemQuality = 3, Quantity = 5 },
            new Item{Id = _nextID++, Name="Water", ItemQuality = 4, Quantity = 3 }
            };

        public IEnumerable<Item> GetAll(string contains)
        {
            List<Item> items = new List<Item>(Data);
            if (contains != null)
            {
                items = items.FindAll(item => item.Name.Contains(contains,StringComparison.OrdinalIgnoreCase));
            }
            return items;
        }

        public Item GetById(int id)
        {
            return Data.Find(item => item.Id == id);
        }

        public Item Add(Item newItem)
        {
            newItem.Id = _nextID++;
            Data.Add(newItem);
            return newItem;
        }

        public Item Delete(int id)
        {
            Item item = GetById(id);
            if (item == null) return null;
            Data.Remove(item);
            return item;
        }

        public Item Update(int id, Item updates)
        {
            Item item = GetById(id);
            if (item == null) return null;
            item.Name = updates.Name;
            item.ItemQuality = updates.ItemQuality;
            item.Quantity = updates.Quantity;
            return item;
        }
    }
}
