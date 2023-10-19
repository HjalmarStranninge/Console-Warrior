using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior.MapObjects
{
    internal class Stone : IMapPrintAble
    {

        public string GetSymbol()
        {
            return "#";
        }
    }
}
