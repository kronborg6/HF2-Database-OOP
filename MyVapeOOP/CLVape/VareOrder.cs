using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLVape
{
    class VareOrder
    {
        public int vareOrderID { get; private set; }
        public int orderID { get; private set; }
        public int vareID { get; private set; }
        public int antal { get; set; }
        public float Prise { get; set; }
        public DateTime sendtDate { get; set; }

        public VareOrder()
        {

        }
    }
}
