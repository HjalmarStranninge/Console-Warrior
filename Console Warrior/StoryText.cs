using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior
{

    // A static class used for printing the story elements of the game,
    // so that the main code doesn't get cluttered with massive walls of text.
    internal static class StoryText
    {
        public static void Intro()
        {
            Console.Clear();

            string introText = "In the land of Eldoria, a realm steeped in magic and mystery, a looming darkness threatens to engulf the kingdom. " +
                "\nAn ancient and malevolent power stirs beneath the surface — the Abyssal Labyrinth. " +
                "\nLegends tell of its immense, shifting corridors, filled with dark, lurking creatures and cursed relics." +
                "\r\n\r\nEldoria's once-thriving cities now stand on the brink of ruin. " +
                "\nThe people cry out for a savior, for the abyssal taint seeps from the depths, corrupting the land, its creatures, " +
                "\nand even the hearts of those who reside above." +
                "\r\n\r\nYou, a valiant adventurer, have heeded the desperate plea for help. " +
                "\nAs the kingdom's last hope, you set forth on a perilous quest into the heart of the labyrinth. " +
                "With sword in hand and courage in your heart, you descend into the inky darkness, " +
                "\ntorches flickering to life as you venture deeper." +
                "\r\n\r\nGlowing mushrooms cast an eerie light, revealing monstrous silhouettes and ominous shadows. " +
                "\nYou are not alone. Foul beasts, born of twisted magic and nightmares, emerge from the abyss to challenge your mettle. " +
                "\r\n\r\nAs you delve deeper into the Abyssal Labyrinth, you'll face ever more daunting challenges, " +
                "\ngather powerful artifacts, and uncover the dark secrets hidden within. " +
                "\nThe fate of the realm awaits your courage and skill. " +
                "\r\n\r\nBut before you continue, adventurer, please tell us your name. " +
                "\r\n\r\nWhat shall we call the hero who will dare to save Eldoria from this encroaching abyss?";

            MapMethods.SlowText(introText);
        }

        public static void Intro(string name)
        {
            Console.Clear();

            string introText = $"{name}! The Abyssal Labyrinth beckons. But beware! " +
                $"\nIn its depths, shadows writhe, and unspeakable horrors await. " +
                $"\r\n\r\nYour journey into the abyss begins now...";

            MapMethods.SlowText(introText);
        }


        public static void Instructions()
        {
            Console.Clear();
            Console.WriteLine("--- INSTRUCTIONS ---");
            Console.WriteLine("Use [W] [A] [S] [D] to move");
            Console.WriteLine("Pick up items and defeat monsters to get stronger");
            Console.WriteLine("Defeat all monsters on a floor to progress deeper");
            Console.WriteLine("If your HP hits 0 - Game over");
            Console.WriteLine("\nGood luck!");

            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }

    }
}
