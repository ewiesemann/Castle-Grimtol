using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Directions { get; set; }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Directions = new Dictionary<string, Room>();
        }

        public void addItem(Item item)
        {
            Items.Add(item);
        }

        public Room ChangeRoom(string direction)
        {
            if (Directions.ContainsKey(direction))
            {
                return Directions[direction];
            }
            System.Console.WriteLine("Invalid Direction");
            return this;
        }

        public void UseItem(Item item)
        {

        }
    }
}