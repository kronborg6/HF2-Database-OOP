using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLVape;

namespace ConsoleVapeOOP
{
    public class Program
    {
        // lavet et interface med helle navet bare så jeg har et interface med i min opgave??
        static void Main()
        {
            //SqlConn.openConnection(); Test connet til databasen
            //SqlConn.closeConnection(); Test om databasen lukker
            //SqlConn.openConnection();
            List<Kunder> kunders = new List<Kunder>();
            Kunder kunderS = new Kunder();

            List<Vare> vares = new List<Vare>();
            Vare Vares = new Vare();

            vares = Vares.getVare();

            kunders = kunderS.getCustomer();

            foreach (Vare vare in vares)
            {
                Console.WriteLine(vare.ToString());
            }

            Console.WriteLine(" ");

            foreach (Kunder kunder in kunders)
            {
                Console.WriteLine(kunder.ToString());
            }

            Console.ReadKey();
        }
    }
}
