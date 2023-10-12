namespace Console_Warrior
{

    // Creating an enum for handling the different objects that are used in the game.
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

            // Setting text code to UTF8.
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Using the ToSymbol() method to create printable variables for each object I need.

            var playerChar = MapMethods.ToSymbol(Objects.Player);
            var monster = MapMethods.ToSymbol(Objects.Monster);
            var openSpace = MapMethods.ToSymbol(Objects.None);
            var wall = MapMethods.ToSymbol(Objects.Wall);

            // Creating 2 int variables for storing the map size, and using them in a 2d array that will be the game map.
                    
            int mapHeight = 25;
            int mapWidth = 100;

            // Creating variables for the players position on the X and Y axis and initializing their values to 0,

            int playerPositionY = mapHeight / 2;
            int playerPositionX = mapWidth / 2;

            // Bool for controlling the gameloop.

            bool isRunning = true;

            Objects[,] map = new Objects [mapHeight, mapWidth];

            // Iterating through the array and assigning enum-objects to different places in the array.

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if(y == 0 || y == mapHeight-1 || x == 0 || x == mapWidth - 1)
                    {
                        map[y, x] = Objects.Wall;
                    }
                    else if (y == playerPositionY && x == playerPositionX)
                    {
                        map[y, x] = Objects.Player;
                    }                  
                }
            }
            
            while (isRunning)
            {
                
                MapMethods.PrintMap(map, playerPositionY, playerPositionX);

                // Reads the players key input and stores it in a variable.

                ConsoleKeyInfo keyPressed = Console.ReadKey(intercept:true);

                // Reads the player input and changes the positional coordinates accordingly,
                // but only if the proposed coordinate change is within the outer walls of the map.
                if (keyPressed.Key == ConsoleKey.W)
                {
                    if(playerPositionY > 1)
                    {
                        playerPositionY--;
                    }                   
                }

                else if (keyPressed.Key == ConsoleKey.A)
                {
                    if(playerPositionX > 1)
                    {
                        playerPositionX--;
                    }                                    
                }        

                else if (keyPressed.Key == ConsoleKey.S)
                {
                    if(playerPositionY < mapHeight-2)
                    {
                        playerPositionY++;
                    }                    
                }

                else if (keyPressed.Key == ConsoleKey.D)
                {

                    if(playerPositionX < mapWidth-2)
                    {
                        playerPositionX++;
                    }                                   
                }

                else 
                {                  
                }
            }
        }
      
    }
}