using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVapeOOP
{
    public class Vare
    {
        public int vareID { get; private set; }
        public string navn { get; set; }
        public float prise { get; set; }
        public int antal { get; set; }
        public int firmaID { get; private set; }
        public Vare()
        {

        }
    }
}
