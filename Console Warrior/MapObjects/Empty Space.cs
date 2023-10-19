using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior.MapObjects
{
    internal class Empty_Space : IMapPrintAble
    {
        public string GetSymbol()
        {
            return " ";
        }
    }
}
