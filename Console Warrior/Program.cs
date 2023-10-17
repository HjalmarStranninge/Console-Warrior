using Console_Warrior.Items;
using Console_Warrior.Characters;
using Console_Warrior.NewFolder;

namespace Console_Warrior
{

    // Creating an enum for handling the different objects that will be used in the game.
    enum Objects
    {
        None,
        Player,
        Wall,
        Monster,
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            // Setting text code to ASCII.
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            // Printing a simple menu using a switch case.
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("--- CONSOLE WARRIOR: Realm of the Abyssal Labyrinth ---");
                Console.WriteLine();
                Console.WriteLine("[1]: Start new game");
                Console.WriteLine("[2]: Instructions");
                Console.WriteLine("[3]: Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
             
                string userInput = Console.ReadLine();
                switch (userInput)
                {

                    // Creating a new 'Hero' and using my 'StoryText' - methods to print the story intro.
                    case "1":
                 
                        // Creating instances of the classes needed in the initial creation of the map.
                        var player = new Hero();
                        var wall = new Stone();
                        var empty = new Empty_Space();

                        //StoryText.Intro();
                        
                        player.SetName(Console.ReadLine());

                        //StoryText.Intro(player.Name);

                        // Creating 2 int variables for storing the map size, and using them in a 2d array that will become the game map.

                        int mapHeight = 29;
                        int mapWidth = 60;

                        // Creating variables for the players position on the X and Y axis and initializing their values to 0,

                        int playerPositionY = mapHeight / 2;
                        int playerPositionX = mapWidth / 2;

                        Console.Clear();

                        // Creating an IMapPrintAble-array which will be used for printing the map.

                        IMapPrintAble[,] map = new IMapPrintAble [mapHeight, mapWidth];

                        // Iterating through the array and assigning IMapPrintAble-objects to different places in the array.

                        for (int y = 0; y < mapHeight; y++)
                        {
                            for (int x = 0; x < mapWidth; x++)
                            {
                                if (y == 0 || y == mapHeight - 1 || x == 0 || x == mapWidth - 1)
                                {
                                    map[y, x] = wall;
                                }
                                else if (y == playerPositionY && x == playerPositionX)
                                {
                                    map[y, x] = player;
                                }
                                else
                                {
                                    map[y, x] = empty;
                                }
                            }
                        }

                        // Bool for running the gamemap in the console.

                        bool runMap = true;

                        while (runMap)
                        {

                            // Using static methods to run print the map and move the player around it.

                            Console.CursorVisible = false;
                            MapMethods.PrintMap(map, playerPositionY, playerPositionX);
                            
                            MapMethods.HandlePlayerMovement(map, ref playerPositionY, ref playerPositionX);
                        }

                        break;

                    // Prints instructions to the console.

                    case "2":

                        StoryText.Instructions();
                        break;

                    // Ends the game loop.

                    case "3":

                        Console.Clear();
                        isRunning = false;
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