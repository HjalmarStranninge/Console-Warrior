using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Console_Warrior.NewFolder
{
    internal abstract class Character
    {
        protected int _level = 1;
        protected int _maxHP;
        protected int _attack;
        protected int _defence;
        protected string _name;
        protected int _currentHP;
        public string Name { get { return _name; } }
        public int MaxHP { get { return _maxHP; } }
        public int AttackStat { get { return _attack; } }
        public int DefenceStat { get { return _defence; } }

        public int CurrentHP { get { return _currentHP; } } 

        public abstract void AttackDescription();

        

        public void SetHP(int hp)
        {
            _currentHP= hp;
        }




    }


}
