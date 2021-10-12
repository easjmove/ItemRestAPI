using System;

namespace ItemLibrary
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemQuality { get; set; }
        public int Quantity { get; set; }

        public Item(int Id, string Name, int ItemQuality, int Quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.ItemQuality = ItemQuality;
            this.Quantity = Quantity;
        }

        public Item()
        {
        }
    }
}
