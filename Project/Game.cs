using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void Guide()
        {
            Console.WriteLine("Type 'Help' to access this game guide");
            Console.WriteLine("Type 'North' to go North");
            Console.WriteLine("Type 'South' to go South");
            Console.WriteLine("Type 'East' to go East");
            Console.WriteLine("Type 'West' to go West");
            Console.WriteLine("Type 'Take <ItemName>' to pick up an Item found in a room");
            Console.WriteLine("Type 'Use <ItemName>' to use and Item from your Inventory");
        }

        public void Reset()
        {


        }
        public void Setup()
        {
            Room EntryHallway = new Room("Entry Hallway", "You find yourself in a small hall there doesn't appear to be anything of interest here. You see a passage to the ['North', 'South'] and straight ahead to the ['East'] is an open archway.  This appears to lead to what appears to be an open Courtyard");
            Room SouthHallway = new Room("South Hallway", "You find yourself in a small hall there doesn't appear to be anything of interest here. You see an open archway to the ['North'] halfway down the hall and a door straight ahead to the you see a door");
            Room NorthHallway = new Room("North Hallway", "You find yourself in a small hall there doesn't appear to be anything of interest here. You see a set of closed double doors further down the hall to the ['North'].  There is also a set of stairs to the ['East'] that lead upwards");
            Room Barracks = new Room("Barracks", "You see a room with several sleeping guards, The room smells of sweaty men. The bed closest to you is empty and there are several uniforms tossed about");
            Room Courtyard = new Room("Courtyard", "You step into the large castle courtyard there is a flowing fountain in the middle of the grounds and a few guards patrolling the area");
            Room CaptainsQuarters = new Room("Captain's Quarters", "As you approach the captains Quarters you swallow hard and notice your lips are dry, Stepping into the room you see a few small tables and maps of the countryside sprawled out.");
            Room GuardRoom = new Room("Guard Room", "Pushing open the door of the guard room you look around and notice the room is empty, There are a few small tools in the corner and a chair propped against the wall near the that likely leads to the dungeon.");
            Room Dungeon = new Room("Dungeon", "As you descend the stairs to the dungeon you notice a harsh chill to the air. Landing a the base of the stairs you see what the remains of a previous prisoner.");
            Room SquireRoom = new Room("Squire Room", "As you finish climbing the stairs to the squire tower you see a messenger nestled in his bed. His messenger overcoat is hanging from his bed post.");
            Room WarRoom = new Room("War Room", "Steping into the war room you see several maps spread across tables. On the maps many of the villages have been marked for purification. You also notice several dishes of prepared food to the side perhaps the war council will be meeting soon");
            Room ThroneRoom = new Room("Throne Room", "As you unlock the door and swing it wide you see an enormous hall stretching out before you. At the opposite end of the hall sitting on his throne you see the dark lord. The Dark Lord shouts at you demanding why you dared to interrupt him during his Ritual of Evil Summoning... Dumbfounded you mutter an incoherent response. Becoming more enraged the Dark Lord complains that you just ruined his concentration and he will now have to start the ritual over... Quickly striding towards you he smirks at least I know have a sacrificial volunteer. Plunging his jewel encrusted dagger into your heart your world slowly fades away.");

            //Entry Hallway
            EntryHallway.Directions.Add("North", Barracks);
            EntryHallway.Directions.Add("South", CaptainsQuarters);
            EntryHallway.Directions.Add("East", Courtyard);

            //Barracks
            Barracks.Directions.Add("South", EntryHallway);

            //Captain's Quarters
            CaptainsQuarters.Directions.Add("North", EntryHallway);
            CaptainsQuarters.Directions.Add("East", SouthHallway);

            //South Hallway
            SouthHallway.Directions.Add("North", Courtyard);
            SouthHallway.Directions.Add("East", GuardRoom);
            SouthHallway.Directions.Add("West", CaptainsQuarters);

            //Courtyard
            Courtyard.Directions.Add("South", SouthHallway);
            Courtyard.Directions.Add("North", NorthHallway);
            Courtyard.Directions.Add("West", EntryHallway);

            //Guard Room
            GuardRoom.Directions.Add("North", Dungeon);
            GuardRoom.Directions.Add("West", SouthHallway);

            //Dungeon
            Dungeon.Directions.Add("South", GuardRoom);

            //North Hallway
            NorthHallway.Directions.Add("North", ThroneRoom);
            NorthHallway.Directions.Add("East", SquireRoom);
            NorthHallway.Directions.Add("South", Courtyard);

            //Squire Room
            SquireRoom.Directions.Add("North", WarRoom);
            SquireRoom.Directions.Add("West", NorthHallway);


        }


        public void UseItem(string itemName)
        {


        }

    }
}