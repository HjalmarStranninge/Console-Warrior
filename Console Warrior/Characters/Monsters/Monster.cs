using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Warrior.NewFolder;

namespace Console_Warrior.Characters.Monsters
{
    internal abstract class Monster : Character, IMapPrintAble
    {
        protected string _name;
        protected int _xpDrop;
        protected string _description;
        public abstract void AttackDescription();

        public string GetSymbol()
        {
            return "💀";
        }
    }
}
