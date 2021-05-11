using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLVape
{
    class MyOrder
    {
        public int orderID { get; private set; }
        public int kundeID { get; private set; }
        public int AddresseID { get; set; }
        public DateTime OpretDate { get; set; }
        public MyOrder()
        {

        }
    }
}
