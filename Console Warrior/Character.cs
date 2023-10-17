using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior
{
    internal abstract class Character
    {
        protected int _level = 1;
        protected int _hp;
        protected int _attack;
        protected int _defence;

        

        public void Attack(Character attacking, Character defending)
        {
            int attackPower = attacking._attack - defending._defence;
            defending._hp = defending._hp - attackPower;
        }

        
        

    }
    

}
