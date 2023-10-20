using Console_Warrior.Characters.Monsters;
using Console_Warrior.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior
{
    internal static class CombatMethods
    {
        // Method for displaying the combat interface and handling gameplay.
        public static void RunCombat(Hero player, Monster enemy)
        {
            
            Console.Clear();

            CombatMethods.EncounterFlash();
            MapMethods.SlowText(enemy.Description);
            Thread.Sleep(1000);

            while (player.CurrentHP > 0 && enemy.CurrentHP > 0) 
            {
                Console.Clear();

                Console.WriteLine($"{player.Name} (HP: {player.CurrentHP}/{player.MaxHP}");
                CombatMethods.DrawHealthBar(player.CurrentHP, player.MaxHP);


                Console.WriteLine($"{enemy.Name} (HP: {enemy.CurrentHP}/{enemy.MaxHP}");
                CombatMethods.DrawHealthBar(enemy.CurrentHP, enemy.MaxHP);

                Console.WriteLine("[1]: Attack");
                Console.WriteLine("[2]: Block");
                Console.WriteLine("[3]: Use item");
                Console.WriteLine();
                Thread.Sleep(1000);

                MapMethods.SlowText("What will you do? ");

                Console.CursorVisible = true;
                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                switch (userInput)
                {
                    case "1":

                        CombatMethods.Attack(player, enemy);
                        CombatMethods.CheckForDeath(player, enemy);

                        CombatMethods.Attack(enemy, player);
                        CombatMethods.CheckForDeath(player, enemy);

                        break;

                    case "2":

                        CombatMethods.Attack(enemy, player);
                        CombatMethods.CheckForDeath(player, enemy);
                        break;

                    case "3":

                        CombatMethods.Attack(enemy, player);
                        CombatMethods.CheckForDeath(player, enemy);
                        break;

                    default:
                        break;
                }
            }            
        }

        // Checks if either combatant has lost all their HP and triggers and appropriate response.
        public static void CheckForDeath(Hero player, Monster enemy)
        {

            if (player.CurrentHP <= 0)
            {
                Console.Clear();
                StoryText.DeathDescription();
                Thread.Sleep(1000);
            }

            else if (enemy.CurrentHP <= 0)
            {
                Console.Clear();
                MapMethods.SlowText(enemy.DeathDescription);
                Thread.Sleep(1000);
                player.GainXP(enemy.XPDrop, player);
                Thread.Sleep(500);
                              
            }            
        }

        public static void Attack(Character attacker, Character defender)
        {
            Console.Clear();
            attacker.AttackDescription();
            int attackPower = attacker.AttackStat - defender.DefenceStat;
            int remaindingHP = defender.CurrentHP - attackPower;
            defender.SetHP(remaindingHP);

            if (attacker is Hero)
            {
                MapMethods.SlowText($"The {defender.Name} takes {attackPower} points of damage!");
            }
            else
            {
                MapMethods.SlowText($"You take {attackPower} points of damage!");
            }


            
            Thread.Sleep(1000);
            

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

        public static void DrawHealthBar(int currentHealth, int maxHealth)
        {
            int barLength = 20;
            int filledLength = (int)Math.Floor((double)currentHealth / maxHealth * barLength);
            Console.Write("[");
            for (int i = 0; i < filledLength; i++)
            {
                Console.Write("#");
            }
            for (int i = filledLength; i <barLength; i++)
            {
                Console.Write(" ");
            }
            Console.Write("]");
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
