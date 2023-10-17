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

namespace Console_Warrior
{

    internal static class MapMethods
    {
        // A method for converting the enums into symbols.
        internal static string ToSymbol(Objects item)
        {
            switch (item)
            {
                case Objects.None:
                    return " ";
                    
                case Objects.Player: 
                    return "웃";

                case Objects.Monster:
                    return "💀";

                case Objects.Wall:
                    return "☖";

                default:
                    return " ";
            }
        }


        // Method for printing the map. Resets the cursor position to overwrite the old map.
        internal static void PrintMap(IMapPrintAble[,] mapArray, int playerY, int playerX) 
        {
            Console.SetCursorPosition(0, 0);

            mapArray[playerY, playerX] = new Hero();

            int oldPositionY = playerY;
            int oldPositionX = playerX;

            int mapHeight = mapArray.GetLength(0);
            int mapWidth = mapArray.GetLength(1);

            for (int y = 0; y < mapHeight; y++)
            {
                
                for (int x = 0; x < mapWidth; x++)
                {
                   
                    if (y == playerY && x == playerY)
                    {
                        Console.Write(mapArray[y, x].GetSymbol());
                    }
                    else
                    {
                        Console.Write($"{mapArray[y, x].GetSymbol()} ");
                    }

                }

                Console.WriteLine();

            }

            mapArray[oldPositionY, oldPositionX] = new Empty_Space();
        }

        // Method for printing text slower, letter by letter.
        internal static void SlowText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }

            Console.WriteLine();
        }

        // Method handling the players movement on the map. It reads the player input and changes the positional coordinates accordingly,
        // but only if the proposed coordinate change is within the outer walls of the map.

        public static void HandlePlayerMovement(IMapPrintAble[,] map, ref int playerPositionY, ref int playerPositionX)
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(intercept: true);

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

        }
    }
}
