using Console_Warrior.Items;
using Console_Warrior.Characters;
using Console_Warrior.NewFolder;
using Console_Warrior.MapObjects;
using Console_Warrior.Characters.Monsters;
using System.Collections.Generic;

namespace Console_Warrior
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Setting text code to ASCII.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Hiding the cursor. I will only have it visible whenever the player needs to input something.
            Console.CursorVisible = false;

            // Printing a simple menu using a switch case.
            bool runMenu = true;
            while(runMenu)
            {

                Console.Clear();
                Console.WriteLine("--- CONSOLE WARRIOR: Realm of the Abyssal Labyrinth ---");
                Console.WriteLine();
                Console.WriteLine("[1]: Start new game");
                Console.WriteLine("[2]: Instructions");
                Console.WriteLine("[3]: Exit");
                Console.WriteLine();
                Console.CursorVisible = true;
                Console.Write("Enter your choice: ");
                

                string userInput = Console.ReadLine();
                Console.CursorVisible = false;
                switch (userInput)
                {

                    
                    case "1":

                        Console.Clear();

                        // Creating a new 'Hero' and using my 'StoryText' - methods to print the story intro.

                        var player = new Hero();
                        StoryText.Intro();

                        Console.CursorVisible = true;
                        player.SetName(Console.ReadLine());
                        Console.CursorVisible = false;
                        StoryText.Intro(player.Name);

                        // Creating 2 int variables for storing the map size, and using them in a 2d array that will become the game map.

                        int mapHeight = 29;
                        int mapWidth = 120;

                        // Creating variables for the players position on the X and Y axis and initializing their values to 0,

                        int playerPositionY = mapHeight / 2;
                        int playerPositionX = mapWidth / 2;

                        // Creating a Tuple list for storing the positions of the monsters, and generating 5 unique positions.

                        var monsterPositions = new List<Tuple<int, int>>();
                        var random = new Random();

                        while(monsterPositions.Count < 5)
                        {
                            int randomY = random.Next(1, mapHeight - 1);
                            int randomX = random.Next(1, mapWidth - 1);
                            var position = new Tuple<int, int>(randomY, randomX);

                            if (!monsterPositions.Contains(position)&&
                                (position.Item1 != playerPositionY || position.Item2 != playerPositionX))
                            {
                                monsterPositions.Add(position);
                            }        
                        }

                        // Creating an IMapPrintAble-array which will be used for printing the map.

                        IMapPrintAble[,] map = new IMapPrintAble [mapHeight, mapWidth];

                        // Iterating through the array and assigning IMapPrintAble-objects to different places in the array.

                        for (int y = 0; y < mapHeight; y++)
                        {
                            for (int x = 0; x < mapWidth; x++)
                            {
                                if (y == 0 || y == mapHeight - 1 || x == 0 || x == mapWidth - 1)
                                {
                                    map[y, x] = new Stone();
                                }
                                else if (y == playerPositionY && x == playerPositionX)
                                {
                                    map[y, x] = player;
                                }
                                else
                                {
                                    Tuple<int,int> currentPos = new Tuple <int,int>(y, x);
                                    if (monsterPositions.Contains(currentPos))
                                    {
                                        map[y, x] = new Abyssal_Shadow();
                                    }
                                    else
                                    {
                                        map[y, x] = new Empty_Space();
                                    }                                                                                                                                             
                                }
                            }
                        }

                        // Creating a copy of the map which will be used to update the map after each movement.

                        IMapPrintAble[,] oldMap = (IMapPrintAble[,]) map.Clone();

                        // Hiding the cursor and printing the map to the console in a while-loop.

                        
                        bool runGame = true;
                        

                        while (runGame)
                        {
                            MapMethods.PrintMap(map);
                            
                            MapMethods.HandlePlayerMovement(map, ref playerPositionY, ref playerPositionX);
                            MapMethods.UpdateMap(map, oldMap);

                            // Creating a copy of the monsterPositions-list to iterate through.
                            // Triggers combat if player is on the same coordinates as a monster, and removes the monster from that position.

                            foreach(var monsterPos in monsterPositions.ToList())
                            {
                                int monsterY = monsterPos.Item1;
                                int monsterX = monsterPos.Item2;

                                if (playerPositionY == monsterY && playerPositionX == monsterX)
                                {
                                    monsterPositions.Remove(monsterPos);
                                    CombatMethods.RunCombat(player, new Abyssal_Shadow());
                                    MapMethods.UpdateMap(map, oldMap);
                                }
                            }                     
                        }
                        break;



                    // Prints instructions to the console.

                    case "2":

                        StoryText.Instructions();
                        break;

                    // Ends the game loop.

                    case "3":

                        Console.Clear();
                        runMenu = false;
                        break;

                    // Handles invalid input.

                    default:

                        Console.Clear();
                        Console.WriteLine("Invalid input...");
                        Console.ReadLine();
                        break;

                }
            }      
        }     
    }
}