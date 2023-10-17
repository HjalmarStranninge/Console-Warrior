using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior.Items
{
    internal class Sword : Weapon
    {
        public Sword()
        {
            _name = "Steel Sword";
            _damage = 10;
            _level = 1;
            _description = "A sharp, bladed weapon for slashing and thrusting.";
        }
    }
}
