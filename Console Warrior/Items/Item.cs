using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior.Items
{
    internal abstract class Item : IMapPrintAble
    {
        protected string _name;
        protected string _description;

        public string GetSymbol()
        {
            return "I";
        }

        public abstract void ItemInfo<T>(T item);

    }
}
