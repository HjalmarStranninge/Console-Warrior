using Console_Warrior.Characters.Monsters;
using Console_Warrior.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior
{
    internal static class CombatMethods
    {
        public static void RunCombat(Hero player, Monster enemy)
        {
            
            Console.Clear();

            CombatMethods.EncounterFlash();
            MapMethods.SlowText(enemy.Description);
            Thread.Sleep(1000);

            Console.Clear();
            Console.WriteLine("[1]: Attack");
            Console.WriteLine("[2]: Block");
            Console.WriteLine("[3]: Use item");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.CursorVisible = true;
            MapMethods.SlowText("What will you do? ");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    break;

                case "2":
                    break;

                case "3":
                    break;

                default:
                    break;
            }
                
        }

        // Creates a flashing effect when encountering an enemy.
        public static void EncounterFlash()
        {           
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Thread.Sleep(37);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Thread.Sleep(37);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Thread.Sleep(125);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Thread.Sleep(37);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Thread.Sleep(37);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Thread.Sleep(125);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Thread.Sleep(37);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Thread.Sleep(37);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Thread.Sleep(125);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Thread.Sleep(37);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Thread.Sleep(37);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Thread.Sleep(500);

        }
    }
}
