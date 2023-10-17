using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior
{
    internal static class PlayerMovement
    {
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
