using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Console_Warrior;

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
        internal static void PrintMap(Objects[,] mapArray, int playerY, int playerX) 
        {
            Console.SetCursorPosition(0, 0);

            int oldPositionY = playerY;
            int oldPositionX = playerX;

            int mapHeight = mapArray.GetLength(0);
            int mapWidth = mapArray.GetLength(1);

            mapArray[playerY, playerX] = Objects.Player;
            

            for (int y = 0; y < mapHeight; y++)
            {
                
                for (int x = 0; x < mapWidth; x++)
                {
                    if (y == playerY && x == playerY)
                    {
                        Console.Write(MapMethods.ToSymbol(mapArray[y, x]));
                    }
                    else
                    {
                        Console.Write($"{MapMethods.ToSymbol(mapArray[y, x])} ");
                    }
                    
                                                                         
                }

                Console.WriteLine();

            }

            mapArray[oldPositionY, oldPositionX] = Objects.None;
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
    }
}
