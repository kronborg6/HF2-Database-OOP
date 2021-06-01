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

            List<Postnummer> postnummers = new List<Postnummer>();
            Postnummer postnummer = new Postnummer();

            postnummers = postnummer.getPostnummer();

            vares = Vares.getVare();

            kunders = kunderS.getKunder();

            //Vares.testAddVare();

            DateTime localDate = DateTime.Now;


            //foreach (Postnummer post in postnummers)
            //{
            //    Console.WriteLine(post.ToString());
            //}

            //kunders.Add(new Kunder() { fornavn = "Tina", efternavn = "Kronborg", email = "t.kronborg6@gmail.com", mobil = 27811707, aktiv = 1, opretDate = localDate });
            //postnummers.Add(new Postnummer(postnummerID: 5051) { byNavn = "Mikkel Kronborg" });
            vares.Add(new Vare(0) { navn = "Mandag", prise = 69, antal = 213, firmaID = 1 });
            vares.Add(new Vare(0) { navn = "Tirsdag", prise = 699, antal = 212, firmaID = 1 });

            /*


            Console.WriteLine(" ");

            foreach (Kunder kunder in kunders)
            {
                Console.WriteLine(kunder.ToString()); 
            }
            */
            //foreach (Kunder kunder in kunders)
            //{
            //    kunderS.Save(kunder);
            //    Console.WriteLine(kunder.ToString());
            //}
            //kunderS.Save(kunderS);
            //foreach (Vare vare in vares)
            //{
            //    //Console.WriteLine(vare.ToString());

            //    Vares.Save(vare);
            //}
            //Console.WriteLine("\n");
            foreach (Vare vare in vares)
            {
                //Console.WriteLine(vare.ToString());
                Vares.Save(vare);
            }
            foreach (Vare vare in vares)
            {
                Console.WriteLine(vare.ToString());
            }
            //vares = Vares.getVare();

            //Console.WriteLine("\n");
            //Console.WriteLine("Efter remove alle med 0");
            //foreach (Vare vare in vares)
            //{
            //    Console.WriteLine(vare.ToString());

            //}
            Console.ReadKey();
        }
    }
}
