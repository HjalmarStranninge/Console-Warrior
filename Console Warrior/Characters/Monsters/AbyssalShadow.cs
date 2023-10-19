using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior.Characters.Monsters
{
    internal class Abyssal_Shadow : Monster
    {
        public Abyssal_Shadow()
        {
            _name = "Abyssal Shadow";
            _level = 1;
            _hp = 25;
            _defence = 10;
            _xpDrop = 20;
            _description = $"A nightmarish entity emerges from the inky blackness of the labyrinth's depths, " +
                $"\nits form shrouded in the deepest darkness. It stares at you with blood-red eyes.";

        }
        public override void AttackDescription()
        {
            string attack = $"The {_name} lunges at you, its razor-sharp slashing through the air.";
            MapMethods.SlowText(attack);
        }
    }
}
