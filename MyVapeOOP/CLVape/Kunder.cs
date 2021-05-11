using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLVape
{
    class Kunder
    {
        public int kundeID { get; private set; }
        public string fornavn { get; set; }
        public string efternavn { get; set; }
        public string email { get; set; }
        public int mobil { get; set; }
        public bool aktiv { get; set; }
        public DateTime opretDate { get; set; }
        public Kunder()
        {

        }
    }
}
