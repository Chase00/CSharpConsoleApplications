using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Repository
{
    public class Menu
    {
        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Ingredients { get; set; }

        public Menu() { }

        public Menu(int itemNumber, string name, string desc, string ingredients)
        {
            ItemNumber = itemNumber;
            Name = name;
            Desc = desc;
            Ingredients = ingredients;
        }

    }
}
