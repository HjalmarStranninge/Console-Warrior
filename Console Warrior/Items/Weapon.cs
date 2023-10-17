using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior.Items
{
    internal class Weapon : Item
    {
        protected int _damage;
        protected int _level;

    


        public override void ItemInfo<Weapon>(Weapon weapon)
        {
            Console.WriteLine($"{_name}(Level {_level})" +
                $"\nDamage: {_damage}" +
                $"\n{_description}");
        }
    }
}
