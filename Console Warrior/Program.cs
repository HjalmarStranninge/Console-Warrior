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

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Creating variables for the players position on the X and Y axis and initializing their values to 0,
            

            int playerPositionX = 0;
            int playerPositionY = 0;

            // Using the ToSymbol() method to create printable variables for each object I need.

            var playerChar = MapMethods.ToSymbol(Objects.Player);
            var monster = MapMethods.ToSymbol(Objects.Monster);
            var openSpace = MapMethods.ToSymbol(Objects.None);
            var wall = MapMethods.ToSymbol(Objects.Wall);

            // Creating 2 int variables for storing the map size, and using them in a 2d array that will be the game map.
                    
            int mapHeight = 30;
            int mapWidth = 100;

            Objects[,] map = new Objects [mapHeight, mapWidth];

            // Iterating through the array and assigns the outmost layer the 'Wall'-enum.

            for (int y = 0; y < mapHeight; y++)
            {
                map[y, 0] = Objects.Wall;
            }

            for (int y = 0; y < mapHeight; y++)
            {
                map[y, mapWidth-1] = Objects.Wall;
            }

            for (int x = 0; x < mapWidth; x++)
            {
                map[0, x] = Objects.Wall;
            }

            for (int x = 0; x < mapWidth; x++)
            {
                map[mapHeight-1, x] = Objects.Wall;
            }

            // Using the PrintMap() method to print the map onto the console.

            MapMethods.PrintMap(map);

            bool isRunning = true;

            // Initial printing of the player character to the console.

            //Console.SetCursorPosition(playerPositionX, playerPositionY);
            //Console.Write(playerChar);

            while (isRunning)
            {

                // Reads the players key input and clears the console so that the character doesnt get a "tail".

                ConsoleKeyInfo keyPressed = Console.ReadKey();
                Console.Clear();

                // Reads the player input and changes the positional coordinates accordingly,
                // but only if the proposed coordinate change is within the buffer size of the console.

                if (keyPressed.Key == ConsoleKey.W)
                {
                    if(playerPositionY > 0)
                    {
                        playerPositionY--;
                    }                   
                }

                else if (keyPressed.Key == ConsoleKey.A)
                {
                    if(playerPositionX > 0)
                    {
                        playerPositionX--;
                    }                                    
                }        

                else if (keyPressed.Key == ConsoleKey.S)
                {
                    if(playerPositionY < Console.BufferHeight-1)
                    {
                        playerPositionY++;
                    }                    
                }

                else if (keyPressed.Key == ConsoleKey.D)
                {

                    if(playerPositionX < Console.BufferWidth-1)
                    {
                        playerPositionX++;
                    }                                   
                }

                else 
                {                  
                }

                // Prints the player character in the updated location on the console.
                          
                Console.SetCursorPosition(playerPositionX, playerPositionY);
                Console.Write(playerChar);
                
              



            }
        }
      
    }
}