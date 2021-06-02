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
                Console.WriteLine("             2. Oprette Vare");
                Console.WriteLine("             3. Oprette Firma");
                Console.WriteLine("             4. Opret Addresse");
                Console.WriteLine("             5. Opret Order");
                Console.WriteLine("             6. Opret VareOrder");
                Console.WriteLine("             7. Alle Kunder");
                Console.WriteLine("             8. Alle Vare");
                Console.WriteLine("             9. Alle Firma");
                Console.WriteLine("             10. Alle Addresser");
                Console.WriteLine("             11. Alle Order");
                Console.WriteLine("             12. Søge Efter Kunder");
                Console.WriteLine("             13. Søge Efter Vare");
                Console.WriteLine("             14. Søge Efter Firma");
                Console.WriteLine("             15. Søge Efter Kunders Addresser");
                Console.WriteLine("             16. Søge Efter Order");
                Console.WriteLine("             17. Ændre Kunde Oplysinger");
                Console.WriteLine("             18. Ændre Vare Oplysinger");
                Console.WriteLine("             19. Ændre Firma Oplysinger");
                Console.WriteLine("             20. Ændre Addresse Oplysinger");
                Console.WriteLine("             20. Ændre VareOrder Oplysinger");
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
