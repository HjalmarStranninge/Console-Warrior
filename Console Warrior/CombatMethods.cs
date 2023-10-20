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

    // This class will store all the methods related to the combat system.
    internal static class CombatMethods
    {
        // Method for displaying the combat interface and handling gameplay.
        public static void RunCombat(Hero player, Monster enemy)
        {
            
            Console.Clear();

            CombatMethods.EncounterFlash();
            MapMethods.SlowText(enemy.Description);
            Thread.Sleep(1000);

            // While-loop that keeps running the combat until one of the combatants loses all their health.
            while (player.CurrentHP > 0 && enemy.CurrentHP > 0) 
            {
                Console.Clear();

                // Displaying the names and healthbars of the player and enemy.

                Console.WriteLine($"{player.Name} (HP: {player.CurrentHP}/{player.MaxHP}");
                CombatMethods.DrawHealthBar(player.CurrentHP, player.MaxHP);

                Console.WriteLine($"{enemy.Name} (HP: {enemy.CurrentHP}/{enemy.MaxHP}");
                CombatMethods.DrawHealthBar(enemy.CurrentHP, enemy.MaxHP);


                // Simple menu where the player can choose different actions.

                Console.WriteLine("[1]: Attack");
                Console.WriteLine("[2]: Block");
                Console.WriteLine("[3]: Use item");
                Console.WriteLine();
                Thread.Sleep(1000);

                MapMethods.SlowText("What will you do? ");

                Console.CursorVisible = true;
                string userInput = Console.ReadLine();
                Console.CursorVisible = false;

                // Switch case for handling the different combat mechanics. No matter what the player does, the enemy will attack.

                switch (userInput)
                {

                    // Attack.
                    case "1":

                        // A random variable is used to simulate a diceroll. Highest roll gets to attack first.
                        var random = new Random();
                        int playerRoll = random.Next(1, 13);
                        int enemyRoll = random.Next(1, 13);

                        if(playerRoll > enemyRoll)
                        {
                            CombatMethods.Attack(player, enemy);
                            if (enemy.CurrentHP <= 0)
                            {
                                CombatMethods.Death(player, enemy);
                                break;
                            }

                            CombatMethods.Attack(enemy, player);
                            if (player.CurrentHP <= 0)
                            {
                                CombatMethods.Death(player, enemy);
                                break;
                            }
                        }
                        else
                        {
                            CombatMethods.Attack(enemy, player);
                            if (player.CurrentHP <= 0)
                            {
                                CombatMethods.Death(player, enemy);
                                break;
                            }

                            CombatMethods.Attack(player, enemy);
                            if (enemy.CurrentHP <= 0)
                            {
                                CombatMethods.Death(player, enemy);
                                break;
                            }
                        }
                        

                        break;

                    // Block.
                    case "2":

                        // Blocking is always prioritized so no roll is needed here.

                        CombatMethods.Attack(enemy, player, CombatMethods.IsBlocking());
                        if (player.CurrentHP <= 0)
                        {
                            CombatMethods.Death(player, enemy);
                            break;
                        }

                        break;

                    // Use item.
                    case "3":

                        CombatMethods.Attack(enemy, player);
                        if (player.CurrentHP <= 0)
                        {
                            CombatMethods.Death(player, enemy);
                            break;
                        }

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please press 1-3.");
                        Thread.Sleep(1000);
                        break;
                }
            }            
        }

        // Checks if either combatant has lost all their HP and triggers and appropriate response.
        public static void Death(Hero player, Monster enemy)
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

        // Calculates damage based on attack and defence and subtracts it from defenders HP. Checks for block.
        public static void Attack(Character attacker, Character defender, bool isBlocking)
        {
            Console.Clear();
            attacker.AttackDescription();
            if (CombatMethods.AttackHit())
            {                  

                    // Checks if the player is blocking.

                    if (isBlocking)
                    {
                        // Rolls for a succesful block. Chance of success increases with a higher defence stat,
                        // and decreases if the attacker has a high attack stat.

                        Console.Clear();
                        var random = new Random();
                        int randomRoll = random.Next(1, 101);
                        int blockProbability = (int)((defender.DefenceStat / (float)(defender.DefenceStat + attacker.AttackStat))*100);
                        if (randomRoll <= blockProbability)
                        {
                            MapMethods.SlowText($"You blocked the attack!");
                        }

                        // If the block fails, the player takes damage as usual.
                        else
                        {
                            
                            MapMethods.SlowText($"Your attempt to block the incoming attack falls short as your adversary outwits your defenses. " +
                            $"\nThe impact is jarring, and you find yourself absorbing the full force of the strike.");
                            Thread.Sleep(500);

                            // Checks for crit.

                            if (CombatMethods.CriticalHit(attacker))
                            {
                                Console.Clear();
                                int critAttack = (int)Math.Floor((double)attacker.AttackStat * 1.5);
                                int remaindingHP = defender.CurrentHP - critAttack;
                                defender.SetHP(remaindingHP);
                                MapMethods.SlowText($"Caught off guard, the enemy's attack lands with brutal force, finding your vulnerability and dealing a devastating blow, " +
                                $"leaving you reeling from the critical hit. You take {critAttack} points of damage.");
                            }

                            else
                            {
                                Console.Clear();
                                int remaindingHP = defender.CurrentHP - attacker.AttackStat;
                                defender.SetHP(remaindingHP);
                                MapMethods.SlowText($"You take {attacker.AttackStat} points of damage!");
                            }
                        }                       
                    }

                    else
                    {

                        // Checks for crit.

                        if (CombatMethods.CriticalHit(attacker))
                        {
                            int critAttack = (int)Math.Floor((double)attacker.AttackStat * 1.5);
                            int remaindingHP = defender.CurrentHP - critAttack;
                            defender.SetHP(remaindingHP);
                            MapMethods.SlowText($"Caught off guard, the enemy's attack lands with brutal force, finding your vulnerability and dealing a devastating blow, " +
                                $"leaving you reeling from the critical hit. You take {critAttack} points of damage.");
                        }
                        else
                        {
                            int remaindingHP = defender.CurrentHP - attacker.AttackStat;
                            defender.SetHP(remaindingHP);
                            MapMethods.SlowText($"You take {attacker.AttackStat} points of damage!");
                        }                                                            
                    }
            }

            else
            {
                Console.Clear();
                MapMethods.SlowText("But the attack missed!");
            }          
            Thread.Sleep(1000);           
        }


        // Override of Attack(). This one doesnt check for block.
        public static void Attack(Character attacker, Character defender)
        {
            Console.Clear();
            attacker.AttackDescription();
            if (CombatMethods.AttackHit())
            {
                // Checks for crit.
                if (CombatMethods.CriticalHit(attacker))
                {
                    if (attacker is Hero)
                    {
                        int critAttack = (int)Math.Floor((double)attacker.AttackStat * 1.5);
                        int remaindingHP = defender.CurrentHP - critAttack;
                        defender.SetHP(remaindingHP);
                        MapMethods.SlowText($"Your attack lands with surgical precision, dealing devastating damage as it finds the enemy's vulnerable spot." +
                            $"\nThe {defender.Name} takes {critAttack} points of damage!");
                    }
                    else
                    {
                        int critAttack = (int)Math.Floor((double)attacker.AttackStat * 1.5);
                        int remaindingHP = defender.CurrentHP - critAttack;
                        defender.SetHP(remaindingHP);
                        MapMethods.SlowText($"Caught off guard, the enemy's attack lands with brutal force, finding your vulnerability and dealing a devastating blow, " +
                            $"leaving you reeling from the critical hit. You take {critAttack} points of damage.");
                    }
                }

                // If no crit.
                else
                {
                    if (attacker is Hero)
                    {
                        MapMethods.SlowText($"The {defender.Name} takes {attacker.AttackStat} points of damage!");
                        int remaindingHP = defender.CurrentHP - attacker.AttackStat;
                        defender.SetHP(remaindingHP);
                    }
                    else
                    {
                        int remaindingHP = defender.CurrentHP - attacker.AttackStat;
                        defender.SetHP(remaindingHP);
                        MapMethods.SlowText($"You take {attacker.AttackStat} points of damage!");
                    }
                }               
            }

            // Attack missed.

            else
            {
                Console.Clear();
                MapMethods.SlowText("But the attack missed!");
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

        // Draws a visual health bar.
        public static void DrawHealthBar(int currentHealth, int maxHealth)
        {
            int barLength = 25;
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

        // Rolls for accuracy.
        public static bool AttackHit()
        {
            var random = new Random();
            int accuracyRoll = random.Next(1, 101);
            if (accuracyRoll > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // For blocking mechanic.
        public static bool IsBlocking()
        {
            Console.Clear();
            MapMethods.SlowText("Focused and determined, you ready your defenses, adopting a protective stance.");
            Thread.Sleep(500);
            return true;
        }

        public static void CounterAttack()
        {

        }

        public static bool CriticalHit(Character attacker)
        {
            var random = new Random();
            int critRoll = random.Next(1, 101);
            if (critRoll <= attacker.CritChance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
