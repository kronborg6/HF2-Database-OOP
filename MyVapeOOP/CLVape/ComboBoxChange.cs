using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLVape
{
    public class ComboBoxChange
    {
        public string name { get; set; }
        public int number { get; set; }
        public ComboBoxChange(string Name, int Number)
        {
            name = Name;
            number = Number;
        }
    }
}
