using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior.Items
{
    internal abstract class Item
    {
        protected string _name;
        protected string _description;

        public abstract void ItemInfo<T>(T item);

    }
}
