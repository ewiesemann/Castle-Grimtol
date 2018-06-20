using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        private string v;

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Directions { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Directions = new Dictionary <string, Room>();
        }

        public Room(string v)
        {
            this.v = v;
        }

        public void UseItem(Item item)
        {

        }
    }
}