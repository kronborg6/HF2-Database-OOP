using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVapeOOP
{
    public class Menu
    {
        public void ListMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("*******************************************");
                Console.WriteLine("\n             Hvad vil du");
                Console.WriteLine("\n             1. Oprette Kunder");
                Console.WriteLine("             2. Oprette Item");
                Console.WriteLine("             3. Oprette Ordre");
                Console.WriteLine("             4. Slette Customer");
                Console.WriteLine("             5. Slette Item");
                Console.WriteLine("             6. Slette Order");
                Console.WriteLine("             7. Alle Customer");
                Console.WriteLine("             8. Alle Items");
                Console.WriteLine("             9. Alle Order");
                Console.WriteLine("             10. Finde Customer");
                Console.WriteLine("             11. Finde Item");
                Console.WriteLine("             12. Finde Order");
                Console.WriteLine("\n*******************************************");
            }
            catch (Exception e)
            {
                Console.WriteLine("Den kunne ikke vise Menuen {0}", e);
                throw;
            }

        }
    }
}
