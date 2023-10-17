using Console_Warrior.Items;

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
                 
                        var player = new Hero();
                        StoryText.Intro();
                        
                        player.SetName(Console.ReadLine());

                        StoryText.Intro(player.Name);                       
                        break;

                    case "2":

                        StoryText.Instructions();
                        break;

                    case "3":

                        Console.Clear();
                        isRunning = false;
                        break;

                    default:

                        Console.Clear();
                        Console.WriteLine("Invalid input...");
                        Console.ReadLine();
                        break;
                }
            }













            //// Using the ToSymbol() method to create printable variables for each object I need.

            //var playerChar = MapMethods.ToSymbol(Objects.Player);
            //var monster = MapMethods.ToSymbol(Objects.Monster);
            //var openSpace = MapMethods.ToSymbol(Objects.None);
            //var wall = MapMethods.ToSymbol(Objects.Wall);

            //// Creating 2 int variables for storing the map size, and using them in a 2d array that will be the game map.
                    
            //int mapHeight = 29;
            //int mapWidth = 60;

            //// Creating variables for the players position on the X and Y axis and initializing their values to 0,

            //int playerPositionY = mapHeight / 2;
            //int playerPositionX = mapWidth / 2;

            //// Bool for controlling the gameloop.

            //bool isRunning = true;

            //// Creating 2D array which will be used for printing the map.

            //Objects[,] map = new Objects [mapHeight, mapWidth];

            //// Iterating through the array and assigning enum-objects to different places in the array.

            //for (int y = 0; y < mapHeight; y++)
            //{
            //    for (int x = 0; x < mapWidth; x++)
            //    {
            //        if(y == 0 || y == mapHeight-1 || x == 0 || x == mapWidth - 1)
            //        {
            //            map[y, x] = Objects.Wall;
            //        }
            //        else if (y == playerPositionY && x == playerPositionX)
            //        {
            //            map[y, x] = Objects.Player;
            //        }                  
            //    }
            //}
            
            //while (isRunning)
            //{
                
            //    MapMethods.PrintMap(map, playerPositionY, playerPositionX);

            //    // Reads the players key input and stores it in a variable. Doesnt print input to the console.

            //    ConsoleKeyInfo keyPressed = Console.ReadKey(intercept:true);

            //    // Reads the player input and changes the positional coordinates accordingly,
            //    // but only if the proposed coordinate change is within the outer walls of the map.

            //    if (keyPressed.Key == ConsoleKey.W)
            //    {
            //        if(playerPositionY > 1)
            //        {
            //            playerPositionY--;
            //        }                   
            //    }

            //    else if (keyPressed.Key == ConsoleKey.A)
            //    {
            //        if(playerPositionX > 1)
            //        {
            //            playerPositionX--;
            //        }                                    
            //    }        

            //    else if (keyPressed.Key == ConsoleKey.S)
            //    {
            //        if(playerPositionY < mapHeight-2)
            //        {
            //            playerPositionY++;
            //        }                    
            //    }

            //    else if (keyPressed.Key == ConsoleKey.D)
            //    {

            //        if(playerPositionX < mapWidth-2)
            //        {
            //            playerPositionX++;
            //        }                                   
            //    }

            //    else 
            //    {                  
            //    }
            //}

        }
      
    }
}