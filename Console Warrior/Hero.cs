using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior
{
    internal class Hero : Character
    {
        private string _name;
        public string Name { get { return _name; } }
        private int _xp = 0;
        public Hero()
        {
            
            _hp = 100;
            _attack = 10;
            _defence = 0;
        }

        public void GetCharacterInfo()
        {
            Console.Clear();
            Console.WriteLine($"\t{_name}");
            Console.WriteLine($"Level {_level} Hero");
            Console.WriteLine($"XP until next level: {_xp}/100");
            Console.WriteLine($"HP: {_hp}/100");
            Console.WriteLine($"Attack: {_attack}");
            Console.WriteLine($"Defence: {_defence}");
            Console.WriteLine();

            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }

        public void SetName(string name)
        {
           _name = name;
        }

        public void LevelUp()
        {
            _level++;
        }


    }
}
