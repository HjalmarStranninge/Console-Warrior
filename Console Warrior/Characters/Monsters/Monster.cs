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
        
        protected int _xpDrop;
        protected string _description;
        protected string[] _deathDescriptions;
        public int XPDrop { get { return _xpDrop; } }
       
        public string Description { get { return _description; } }
        public string DeathDescription
        { 
            get
            {
                Random random = new Random();
                int randomIdex  = random.Next(_deathDescriptions.Length);
                return _deathDescriptions[randomIdex];
            } 
        }

       

        public string GetSymbol()
        {
            return "M";
        }
    }
}
