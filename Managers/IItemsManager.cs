using ItemLibrary;
using System.Collections.Generic;

namespace ItemRestAPI.Managers
{
    public interface IItemsManager
    {
        Item Add(Item newItem);
        Item Delete(int id);
        IEnumerable<Item> GetAll(string contains);
        Item GetById(int id);
        Item Update(int id, Item updates);
    }
}