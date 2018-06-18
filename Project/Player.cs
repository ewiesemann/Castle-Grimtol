using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }

        public void ShowIventory()
        {
            Console.WriteLine($@"You currently have {Inventory[0].Name} | {Inventory[0].Description}");
        }
    }
}