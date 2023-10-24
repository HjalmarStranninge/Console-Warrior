using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Console_Warrior;
using Console_Warrior.NewFolder;
using Console_Warrior.Characters;
using Console_Warrior.Items;
using Console_Warrior.MapObjects;
using System.Security.Cryptography.X509Certificates;

namespace Console_Warrior
{

    // Class with different methods related to handling the map which the game is played on.
    internal static class MapMethods
    {
        
        // Method for initially printing the map.
        internal static void PrintMap(IMapPrintAble[,] mapArray) 
        {

            Console.SetCursorPosition(0, 0);

            int mapHeight = mapArray.GetLength(0);
            int mapWidth = mapArray.GetLength(1);

            for (int y = 0; y < mapHeight; y++)
            {               
                for (int x = 0; x < mapWidth; x++)
                {                   
                    Console.Write(mapArray[y, x].GetSymbol());
                }
                Console.WriteLine();
            }           
        }     

        // Method for printing text slower, letter by letter.
        internal static void SlowText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }

            Console.WriteLine();

        }

        // Method handling the players movement on the map. It reads the player input and changes the positional coordinates accordingly,
        // but only if the proposed coordinate change is within the outer walls of the map.

        public static void HandlePlayerMovement(IMapPrintAble[,] map, ref int playerPositionY, ref int playerPositionX)
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(intercept: true);

            int oldY = playerPositionY;
            int oldX = playerPositionX;

            if (keyPressed.Key == ConsoleKey.W)
            {
                if (playerPositionY > 1)
                {
                    playerPositionY--;
                }
            }

            else if (keyPressed.Key == ConsoleKey.A)
            {
                if (playerPositionX > 1)
                {
                    playerPositionX--;
                }
            }

            else if (keyPressed.Key == ConsoleKey.S)
            {
                if (playerPositionY < map.GetLength(0) - 2)
                {
                    playerPositionY++;
                }
            }

            else if (keyPressed.Key == ConsoleKey.D)
            {

                if (playerPositionX < map.GetLength(1) - 2)
                {
                    playerPositionX++;
                }
            }

            else
            {
            }

            if (oldY != playerPositionY || oldX != playerPositionX)
            {
                map[playerPositionY, playerPositionX] = map[oldY, oldX];
                map[oldY, oldX] = new Empty_Space();
            }          
        }

        // Method for updating map after each movement. It compares the newest instance of the map to the older one
        // and prints everything that has changed.
        public static void UpdateMap(IMapPrintAble[,] map, IMapPrintAble[,] oldMap)
        {
            int mapHeight = map.GetLength(0);
            int mapWidth = map.GetLength(1);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if (map[y,x]  != oldMap[y, x])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(map[y, x].GetSymbol());
                    }
                }
                
            }
        }       
    }
}
