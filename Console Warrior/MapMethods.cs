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
        internal static char ToSymbol(Objects item)
        {
            switch (item)
            {
                case Objects.None:
                    return ' ';
                    
                case Objects.Player: 
                    return 'P';

                case Objects.Monster:
                    return 'M';

                case Objects.Wall:
                    return '#';

                default:
                    return ' ';
            }
        }

        internal static void PrintMap(Objects[,] mapArray) 
        {

            int mapHeight = mapArray.GetLength(0);
            int mapWidth = mapArray.GetLength(1);

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    Console.Write(MapMethods.ToSymbol(mapArray[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
