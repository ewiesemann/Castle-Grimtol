using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Item : IItem
    {
        private string v;

        public string Name {get; set;}
        public string Description {get; set;}

        private readonly Item item;

        public Item GetItem()
        {
            return item;
        }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Item(string ItemName) => this.item = GetItem();
    }
}