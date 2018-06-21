using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public bool Playing { get; set; }

        //----------This is the game guide section----------\\
        public void Guide()
        {
            Console.WriteLine("Type 'H' to access this game guide");
            Console.WriteLine("Type 'N' to go North");
            Console.WriteLine("Type 'S' to go South");
            Console.WriteLine("Type 'E' to go East");
            Console.WriteLine("Type 'W' to go West");
            Console.WriteLine("Type 'Take <ItemName>' to pick up an Item found in a room");
            Console.WriteLine("Type 'Use <ItemName>' to use and Item from your Inventory");
            Console.WriteLine("Type 'X' to exit the game");
        }

        //Takes in the players command inputs
        public void UserCommand()
        {
            string UserCommand = Console.ReadLine().ToUpper();
            switch (UserCommand.ToUpper())
            {
                case "H":
                    Guide();
                    break;
                case "N":
                    Go(UserCommand);
                    break;
                case "S":
                    Go(UserCommand);
                    break;
                case "E":
                    Go(UserCommand);
                    break;
                case "W":
                    Go(UserCommand);
                    break;
                case "take":
                    TakeItem();
                    break;
                case "Use":
                    UseItem();
                    break;
                case "X":
                    Console.WriteLine("Brave Adventurer ran away.\n");
                    Console.WriteLine("Bravely ran away away. \n");
                    Console.WriteLine("When Danger reared it's ugly head.\n");
                    Console.WriteLine("You bravely turnred your tail and fled.\n");
                    Console.WriteLine("Yes brave Adventurer turned about.\n");
                    Console.WriteLine("And gallantly you chickened out");
                    Game.Quit(0);
                    break;         
            }
        }


        //Sets up the initial game with Rooms and Items and starting point
        public void Setup()
        {
            //----------This section is for each Room and the access they each have----------\\

            Room EntryHallway = new Room("Entry Hallway", "You find yourself in a small hall there doesn't appear to be anything of interest here. You see a passage to the ['N', 'S'] and straight ahead to the ['E'] is an open archway.  This appears to lead to what appears to be an open Courtyard");
            Room SouthHallway = new Room("South Hallway", "You find yourself in a small hall there doesn't appear to be anything of interest here. You see an open archway to the ['N'] halfway down the hall and a door straight ahead to the you see a door");
            Room NorthHallway = new Room("North Hallway", "You find yourself in a small hall there doesn't appear to be anything of interest here. You see a set of closed double doors further down the hall to the ['N'].  There is also a set of stairs to the ['E'] that lead upwards");
            Room Barracks = new Room("Barracks", "You see a room with several sleeping guards, The room smells of sweaty men. You see a bed that appears to be empty and there are several guard uniforms ['Guard Uniform'] tossed about");
            Room Courtyard = new Room("Courtyard", "You step into the large castle courtyard there is a flowing fountain in the middle of the grounds and a few guards patrolling the area");
            Room CaptainsQuarters = new Room("Captain's Quarters", "As you approach the captains Quarters you swallow hard and notice your lips are dry, Stepping into the room you see a few small tables and maps of the countryside sprawled out.");
            Room GuardRoom = new Room("Guard Room", "Pushing open the door of the guard room you look around and notice the room is empty, There are a few small tools in the corner and a chair propped against the wall near the that likely leads to the dungeon.");
            Room Dungeon = new Room("Dungeon", "As you descend the stairs to the dungeon you notice a harsh chill to the air. Landing a the base of the stairs you see what the remains of a previous prisoner.");
            Room SquireRoom = new Room("Squire Room", "As you finish climbing the stairs to the squire tower you see a messenger nestled in his bed. His messenger overcoat is hanging from his bed post.");
            Room WarRoom = new Room("War Room", "Steping into the war room you see several maps spread across tables. On the maps many of the villages have been marked for purification. You also notice several dishes of prepared food to the side perhaps the war council will be meeting soon");
            Room ThroneRoom = new Room("Throne Room", "As you unlock the door and swing it wide you see an enormous hall stretching out before you. At the opposite end of the hall sitting on his throne you see the dark lord. The Dark Lord shouts at you demanding why you dared to interrupt him during his Ritual of Evil Summoning... Dumbfounded you mutter an incoherent response. Becoming more enraged the Dark Lord complains that you just ruined his concentration and he will now have to start the ritual over... Quickly striding towards you he smirks at least I know have a sacrificial volunteer. Plunging his jewel encrusted dagger into your heart your world slowly fades away.");

            //Entry Hallway - access to Barracks, Captain's Quarters, Courtyard
            EntryHallway.Directions.Add("north", Barracks);
            EntryHallway.Directions.Add("south", CaptainsQuarters);
            EntryHallway.Directions.Add("east", Courtyard);

            //Barracks - access to Entry Hallway
            Barracks.Directions.Add("south", EntryHallway);

            //Captain's Quarters - access to Entry Hallway, South Hallway
            CaptainsQuarters.Directions.Add("north", EntryHallway);
            CaptainsQuarters.Directions.Add("east", SouthHallway);

            //South Hallway - Access to Courtyard, GuardRoom, Captain's Quarters
            SouthHallway.Directions.Add("north", Courtyard);
            SouthHallway.Directions.Add("east", GuardRoom);
            SouthHallway.Directions.Add("west", CaptainsQuarters);

            //Courtyard - access to South Hallway, North Hallway, Entry Hallway
            Courtyard.Directions.Add("south", SouthHallway);
            Courtyard.Directions.Add("north", NorthHallway);
            Courtyard.Directions.Add("west", EntryHallway);

            //Guard Room - access to Dungeon, South Hallway
            GuardRoom.Directions.Add("north", Dungeon);
            GuardRoom.Directions.Add("west", SouthHallway);

            //Dungeon - access to Guard Room
            Dungeon.Directions.Add("south", GuardRoom);

            //North Hallway - access to Throne Room, Squire Room, Courtyard
            NorthHallway.Directions.Add("north", ThroneRoom);
            NorthHallway.Directions.Add("east", SquireRoom);
            NorthHallway.Directions.Add("south", Courtyard);

            //Squire Room - access to War Room, North Hallway
            SquireRoom.Directions.Add("north", WarRoom);
            SquireRoom.Directions.Add("west", NorthHallway);

            //War Room - access to Squire Room
            WarRoom.Directions.Add("south", SquireRoom);


            //----------This section is for Items and what Room they are found in----------\\

            //Barracks
            Item Uniform = new Item("guard uniform", "This would make a great disguise!");
            Item Bed = new Item("bed", "A good place to hide and possibly blend in.");

            //Captain's Quarters
            Item Key = new Item("key", "Not sure what this unlocks, but a good idea to hold on to it.");

            //Dungeon
            Item Lock = new Item("lock", "This sure looks like that key you found will unlock this.");


            //Adding Items to rooms

            //Barracks
            Barracks.Items.Add(Uniform);
            Barracks.Items.Add(Bed);
            //Captain's Quarters
            CaptainsQuarters.Items.Add(Key);
            //Dungeon
            Dungeon.Items.Add(Lock);

            Console.WriteLine("Brave Young Warrior our forces are failing and the enemy grows stronger everyday.  I fear if we don't act now our people will be driven from their homes.");
            Console.WriteLine("These dark times have left us with one final course of action. We must cut the head off of the snake by assasinating the Dark Lord of Grimtol.");
            Console.WriteLine("Our sources have identified a small tunnel that leads into the rear of the castle.\n");
            Console.WriteLine("Once you sneak through the tunnel you will need to find a way to disguise yourself and kill the Dark Lord. We don't know exactly how so you'll need to use your wit and cunning to think of something.\n");
            Console.WriteLine("Good Luck brave one.");







            //----------Resetting the game back to the start----------\\

            Playing = true;
            CurrentRoom = EntryHallway;
        }

        public void Play()
        {
            Setup();

        }
        public void Go(string UserCommand)
        {
        

        }

        //This sets up how a player can pick up an item and add to inventory
        public void TakeItem(string itemName)
        {

            Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
            if (item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
                Console.WriteLine($"{itemName} added to your inventory");
                CurrentPlayer.ShowIventory(CurrentPlayer);
            }
            else
            {
                Console.WriteLine("You are not able to take that!");
            }
        }

        //This is for how a player uses and item from their inventory
        public void UseItem(string itemName)
        {
            //Check to make sure item is in inventory
            Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);
            if (item != null)
            {

            }

        }

        //Leaving the game
        public void Quit()
        {
            Playing = false;
        }

        //Resets the game back to the intial setup and restarts it
        public void Reset()
        {
            Setup();

        }

    }
}