using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console_Warrior.NewFolder
{
    // The playable class.
    internal class Hero : Character, IMapPrintAble
    {
        
        private int _xp = 0;
        public Hero()
        {

            _maxHP = 100;
            _attack = 15;
            _defence = 10;
            _currentHP = _maxHP;
        }

        // Method for handling experience gain.
        public void GainXP(int xpGain, Hero player)
        {
            Console.Clear();
            MapMethods.SlowText($"You gained {xpGain} XP!");
            _xp = _xp + xpGain;

            if (_xp >= 100)
            {
                player.LevelUp();
            }
        }


        public void GetCharacterInfo()
        {
            Console.Clear();
            Console.WriteLine($"\t{_name}");
            Console.WriteLine($"Level {_level} Hero");
            Console.WriteLine($"XP until next level: {_xp}/100");
            Console.WriteLine($"HP: {CurrentHP}/100");
            Console.WriteLine($"Attack: {_attack}");
            Console.WriteLine($"Defence: {_defence}");
            Console.WriteLine();

            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }

        // Sets the name.
        public void SetName(string name)
        {
            _name = name;
        }

        // Increases level.
        public void LevelUp()
        {
            _level++;
            Console.Clear();
            MapMethods.SlowText($"DING! You leveled up to lvl.{_level}!");
           
        }

        string IMapPrintAble.GetSymbol()
        {
            return "P";
        }

        // There are a couple different attack descriptions to create variation.
        public override void AttackDescription()
        {
            var attackDescriptions = new string[]
            {
                "You summon all your strength, delivering a mighty swing that cuts through the air with a resounding whoosh.",
                "With unwavering determination, you ready your weapon, launching into a swift, precise strike.",
                "Gathering energy, you strike with a thunderous impact, shaking the ground beneath you. "
            };

            var Random = new Random();
            int randomIndex  = Random.Next(attackDescriptions.Length);
            MapMethods.SlowText(attackDescriptions[randomIndex]);
        }

        
    }
}
