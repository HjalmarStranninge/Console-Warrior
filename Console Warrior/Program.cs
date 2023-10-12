namespace Console_Warrior
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // Setting text code to UTF8.

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Creating variables for the players position on the X and Y axis and initializing their values to 0,
            // as well as a string variable containing the player character and a bool for controlling the game loop.

            int playerPositionX = 0;
            int playerPositionY = 0;
            string playerChar = "🯅";
            bool isRunning = true;

            // Initial printing of the player character to the console.

            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(playerChar);

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