using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }
        public bool Uniform { get; internal set; }

        public Player(string name)
        {
            Name = name;
            Inventory = new List<Item>();
        }

        public void ShowIventory(Player CurrentPlayer)
        {
            Console.WriteLine($@"You currently have {Inventory[0].Name} | {Inventory[0].Description}");
        }

        internal void Add(string v)
        {
            throw new NotImplementedException();
        }
    }
}