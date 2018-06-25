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
            Console.WriteLine("Type 'LOOK' to print the room description again");
            //Console.WriteLine("Press 'I' to access your inventory");
            Console.WriteLine("Type 'X' to exit the game");
        }

        //----------Takes in the players command inputs----------\\
        public void UserCommand()
        {
            string input = Console.ReadLine().ToUpper();
            string input1 = input.Split(" ")[0];
            string input2 = "";
            if (input.Split(" ").Length > 1)
            {
                input2 = input.Split(" ")[1];
            }

            switch (input1.ToUpper())
            {
                case "HELP":
                case "H":
                    Guide();
                    break;
                case "NORTH":
                case "N":
                    Console.Clear();
                    CurrentRoom = CurrentRoom.ChangeRoom("north");
                    Look();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("What do you do next?");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "SOUTH":
                case "S":
                    Console.Clear();
                    CurrentRoom = CurrentRoom.ChangeRoom("south");
                    Look();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("What do you do next?");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "EAST":
                case "E":
                    Console.Clear();
                    CurrentRoom = CurrentRoom.ChangeRoom("east");
                    Look();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("What do you do next?");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "WEST":
                case "W":
                    Console.Clear();
                    CurrentRoom = CurrentRoom.ChangeRoom("west");
                    Look();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("What do you do next?");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "TAKE":
                case "T":
                    {
                        TakeItem(input2);
                    }
                    break;
                case "USE":
                case "use":
                    {
                        UseItem(input2);
                    }
                    break;
                // case "I":
                //     {
                //         ShowInventory();
                //     }
                //     break;
                case "LOOK":
                    {
                        Look();
                    }
                    break;
                case "R":
                    Reset();
                    break;
                case "X":
                    Console.Clear();
                    Console.WriteLine("Brave Adventurer ran away.\n");
                    Console.WriteLine("Bravely ran away away. \n");
                    Console.WriteLine("When Danger reared it's ugly head.\n");
                    Console.WriteLine("You bravely turnred your tail and fled.\n");
                    Console.WriteLine("Yes brave Adventurer turned about.\n");
                    Console.WriteLine("And gallantly you chickened out. \n");
                    Console.WriteLine("Please press ['R'] to restart the game.");
                    break;
            }
        }

        // private void ShowInventory()
        // {
        //     throw new NotImplementedException();
        // }

        //----------Sets up the initial game with Rooms and Items and starting point----------\\
        public void Setup()
        {
            //----------This section is for each Room and the access they each have----------\\

            Room EntryHallway = new Room("Entry Hallway", "You find yourself in a small hall and there doesn't appear to be anything of interest here. You see a dorr to your ['N'], and to the  ['S'].  Straight ahead to the ['E'] is an open archway.  This appears to lead to an open Courtyard.  You can see several guards involved in combat drills.  You need to be very careful and quiet.\n");
            Room SouthHallway = new Room("South Hallway", "You find yourself in a small hall and there doesn't appear to be anything of interest here. You see an open archway to the ['N'] halfway down the hall and a door straight ahead to the ['E'] you see a door.  As you move down the hall you see that the passage to the ['N'] leads to the same Courtyard.\n");
            Room NorthHallway = new Room("North Hallway", "You find yourself in a small hall and there doesn't appear to be anything of interest here. You see a set of closed double doors further down the hall to the ['N'].  There is also a set of stairs to the ['E'] that lead upwards.\n");
            Room Barracks = new Room("Barracks", "You see a room with several sleeping guards laying in beds and on the floor. The room smells of sweat and stale mead.  You see several guard uniforms ['Guard Uniform'] tossed about the floor.  There are no other doors in this room except the one you can in through to the ['S'].\n");
            Room Courtyard = new Room("Courtyard", "You step into the large castle courtyard and see a flowing fountain in the middle of the grounds and a few guards doing combat drills.  The Captain of the Guard is shouting orders and seems to pay no attention to you.  There are archways leading out of this area to the ['N'], ['S'], and ['W'].\n");
            Room CaptainsQuarters = new Room("Captain's Quarters", "As you approach the Captains Quarters you swallow hard and notice your lips are dry.  Stepping into the room you see a few small tables and maps of the countryside sprawled out.  There are two doors leading out of this room.  One to the ['N'} and one to the ['E'}.\n");
            Room GuardRoom = new Room("Guard Room", "Pushing open the door of the guard room you look around and notice the room is empty.  The must all be in the Courtyard doing drills. There is a door to the ['N'] with a chair next to it.  You wonder if this door leads to the dungeon.\n");
            Room Dungeon = new Room("Dungeon", "As you descend the stairs to the dungeon you notice a harsh chill to the air. Landing a the base of the stairs you see a series of cells.  Checking each cell you see they have the remains of previous prisoners except the last one.  In this cell you see the assassin you have been looking for.  Searching the area you find on a hook the keys to the cells.  Opening the cell he thanks you for rescuing him.  He tells you he is going to finish his mission and for you to return to the village to let everyone know.  Please type ['R'] to restart the game.\n");
            Room SquireRoom = new Room("Squire Room", "As you finish climbing the stairs to the tower you see a messenger nestled in his bed. His messenger overcoat is hanging from his bed post.  To the ['N'} is an open door and you think you can make out a large table with several items across it's top.");
            Room WarRoom = new Room("War Room", "Steping into the room you see several maps spread across the large table. On the maps many of the villages have been marked for purification.   Taking a closer look you see that your villiage is marked as the next target.  You also notice several dishes of prepared food to the side perhaps the war council will be meeting soon.  The only way out of this room is back to the ['S'].\n");
            Room ThroneRoom = new Room("Throne Room", "As you unlock the door and swing it wide you see an enormous hall stretching out before you. At the opposite end of the hall sitting on his throne you see the dark lord. The Dark Lord shouts at you demanding why you dared to interrupt him during his Ritual of Evil Summoning... Dumbfounded you mutter an incoherent response. Becoming more enraged the Dark Lord complains that you just ruined his concentration and he will now have to start the ritual over... Quickly striding towards you he smirks at least I know have a sacrificial volunteer. Plunging his jewel encrusted dagger into your heart your world slowly fades away.  You have died, the rebellion has failed.  Please press ['R'] to restart the game.\n");

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


            //Adding Items to rooms

            //Barracks
            Barracks.Items.Add(Uniform);

            //----------Resetting the game back to the start----------\\
            CurrentPlayer = new Player("Hero");
            Playing = true;
            CurrentRoom = EntryHallway;
        }

        //----------Allows players to reprint the room description----------\\
        public void Look()
        {
            if (CurrentRoom.Name != "Barracks" && !CurrentPlayer.Uniform)
            {
                Console.WriteLine("As you enter you see a guard approaching you. (GUARD) Wat?!?  Who the blazes are you? Quickly he raises the alarm and several men turn towards you. Quick Jenkins sieze him.... Jenkins a bit over-zelous swings his sword cleaving you in half.  You have died, the rebellion has failed.\n");
                Console.WriteLine("Press ['R'] to restart the game");

            }
            else
            {
                Console.WriteLine(CurrentRoom.Description);
                // Console.ForegroundColor = ConsoleColor.Yellow;
                // Console.WriteLine("What would you like to do?\n");
                // Console.ForegroundColor = ConsoleColor.White;
            }


        }

        //----------Starts the game----------\\
        public void Play()
        {
            Console.Clear();
            Console.WriteLine("--------------------Welcome to Castle Grimtol--------------------\n");
            Setup();
            Console.WriteLine("Brave Young Warrior our forces are failing and the enemy grows stronger everyday.  I fear if we don't act now our people will be driven from their homes.  These dark times have left us with one final course of action. We must cut the head off of the snake by assasinating the Dark Lord of Grimtol.\n");
            Console.WriteLine("Our assassin has not returned from the castle and we need you to find out what happened to him.\n");
            Console.WriteLine("Enter the castle through the back entrance and discover his fate.  We believe the barracks are to the ['N'] once you are inside.  Find that room and take a guard uniform to disguise yourself with.\n");
            Console.WriteLine("Good Luck brave one.\n");
            Console.WriteLine("Press ['H'] to access the game menu at any time, or ['X'] to leave the game.\n");

            Console.WriteLine(CurrentRoom.Description);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What would you like to do?\n");
            Console.ForegroundColor = ConsoleColor.White;

            while (Playing)
            {
                UserCommand();
            }

        }

        //----------This sets up how a player can pick up an item and add to inventory----------\\

        public void TakeItem(string itemName)
        {
            Item item = CurrentRoom.Items.Find(i => i.Name.ToUpper().Contains(itemName));

            if (CurrentRoom.Items.Contains(item))
            {
                System.Console.WriteLine($"You picked up {item.Name}.  To equip this item make sure you ['use'] it so you are not discovered.");
                CurrentPlayer.Inventory.Add(item);
                CurrentRoom.Items.Remove(item);
            }
            else
            {
                System.Console.WriteLine("There is nothing by that name in this room.");
            }
        }

        //----------This is for how a player uses and item from their inventory----------\\

        public void UseItem(string itemName)
        {
            Item item = CurrentPlayer.Inventory.Find(i => i.Name.ToUpper().Contains(itemName));
            if (item != null)
            {
                if (itemName == "uniform") NewMethod();
                {
                    CurrentPlayer.Uniform = !CurrentPlayer.Uniform;
                    CurrentPlayer.Inventory.Remove(item);
                }

                Console.WriteLine("You quickly slip the uniform on!  Now to find the assassin.\n");
                Console.WriteLine("You have to go back the way you came to the ['S'].\n");
            }


            else
            {
                System.Console.WriteLine("You don't have that item in your inventory.\n");
            }

        }

        private static void NewMethod()
        {
            ;
        }

        //----------Leaving the game----------\\

        public void Quit()
        {
            Playing = false;
        }

        //----------Resets the game back to the intial setup and restarts it----------\\
        public void Reset()
        {
            Play();

        }

    }
}