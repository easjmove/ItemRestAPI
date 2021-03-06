using ItemLibrary;
using ItemRestAPI.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemRestAPI.Managers
{
    public class ItemsManagerDB : IItemsManager
    {
        public ItemContext _context;

        public ItemsManagerDB(ItemContext context)
        {
            _context = context;
        }

        public Item Add(Item newItem)
        {
            newItem.Id = 0; // to ignore the ID supplied from the user
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public Item Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAll(string contains)
        {
            if (string.IsNullOrWhiteSpace(contains))
            {
                return _context.Items.ToList();
            }
            IEnumerable<Item> items = from item in _context.Items
                                      where item.Name.Contains(contains)
                                      select item;
            return items;
        }

        public Item GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Item Update(int id, Item updates)
        {
            throw new NotImplementedException();
        }
    }
}
