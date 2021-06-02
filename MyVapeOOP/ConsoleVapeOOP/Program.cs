using System;
using System.Collections.Generic;
using System.Globalization;
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
            List<Kunder> kunders = new List<Kunder>();
            Kunder kunderS = new Kunder();

            kunders = kunderS.getKunder();

            List<Vare> vares = new List<Vare>();
            Vare Vares = new Vare();

            vares = Vares.getVare();

            List<Postnummer> postnummers = new List<Postnummer>();
            Postnummer postnummer = new Postnummer();

            postnummers = postnummer.getPostnummer();


            List<Addresse> addresses = new List<Addresse>();
            Addresse addresse = new Addresse();

            addresses = addresse.getAddresse();

            List<Firma> firmas = new List<Firma>();
            Firma firma = new Firma();

            firmas = firma.getFirma();

            List<MyOrder> myOrders = new List<MyOrder>();
            MyOrder myOrder = new MyOrder(0, 0);

            myOrders = myOrder.getMyOrder();

            List<VareOrder> vareOrders = new List<VareOrder>();
            VareOrder vareOrder = new VareOrder(0, 0, 0);

            vareOrders = vareOrder.getVareOrder();







            //foreach (Postnummer post in postnummers)
            //{
            //    Console.WriteLine(post.ToString());
            //}

            //kunders.Add(new Kunder() { fornavn = "Tina", efternavn = "Kronborg", email = "t.kronborg6@gmail.com", mobil = 27811707, aktiv = 1, opretDate = localDate });
            //postnummers.Add(new Postnummer(postnummerID: 5051) { byNavn = "Mikkel Kronborg" });


            //foreach (Vare vare in vares)
            //{
            //    Console.WriteLine(vare.ToString());
            //}
            //foreach (MyOrder myOrder1 in myOrders)
            //{
            //    Console.WriteLine(myOrder1.ToString());
            //}
            DateTime localDate = DateTime.Now;
            Menu m = new Menu();
            m.ListMenu();
            while (true)
            {
                try
                {
                    //foreach (Kunder kunder in kunders)
                    //{
                    //    kunderS.Save(kunder);
                    //}
                    //foreach (Addresse addresse1 in addresses)
                    //{
                    //    addresse.Save(addresse1);
                    //}
                    //foreach (Vare vare in vares)
                    //{
                    //    Vares.Save(vare);
                    //}
                    //foreach (Firma firma1 in firmas)
                    //{
                    //    firma.Save(firma1);
                    //}
                    //foreach (MyOrder my in myOrders)
                    //{
                    //    myOrder.Save(my);
                    //}
                    //foreach (VareOrder vareOrder1 in vareOrders)
                    //{
                    //    vareOrder.Save(vareOrder1);
                    //}
                }
                catch (Exception)
                {

                    throw;
                }
                try
                {
                    Console.WriteLine("For at Se Menu Igen Pick Nummer: 0");
                    Console.Write("Number: ");
                    string indd = Console.ReadLine();
                    switch (int.Parse(indd))
                    {
                        case 1: // Opret kunder
                            Console.Clear();
                            Console.Write("Fornavn: ");
                            string Fornavn = Console.ReadLine();
                            Console.Write("Efternavn: ");
                            string Efternavn = Console.ReadLine();
                            Console.Write("Email: ");
                            string Email = Console.ReadLine();
                            Console.Write("Mobil: ");
                            int Mobil = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                kunders.Add(new Kunder(0) { fornavn = Fornavn, efternavn = Efternavn, email = Email, mobil = Mobil, opretDate = localDate, HasChanges = true, IsNew = true, aktiv = 1 });
                                foreach (Kunder kunder in kunders)
                                {
                                    kunderS.Save(kunder);
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 2: // Opret Vare
                            Console.Clear();
                            Console.Write("Navn: ");
                            string Navn = Console.ReadLine();
                            Console.Write("Prise: ");
                            double prise = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Antal: ");
                            int Antal = Convert.ToInt32(Console.ReadLine());
                            Console.Write("FirmaID: ");
                            int FirmaID = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                vares.Add(new Vare(0) { navn = Navn, prise = prise, antal = Antal, firmaID = FirmaID, IsNew = true, HasChanges = true });
                                foreach (Vare vare in vares)
                                {
                                    Vares.Save(vare);
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 3: // Opret Firma
                            Console.Clear();
                            Console.Write("Navn: ");
                            string FirmaNavn = Console.ReadLine();
                            Console.Write("Email: ");
                            string FirmaEmail = Console.ReadLine();
                            Console.Write("Mobil: ");
                            int FirmaMobil = Convert.ToInt32(Console.ReadLine());

                            try
                            {
                                firmas.Add(new Firma(0) { navn = FirmaNavn, email = FirmaEmail, mobil = FirmaMobil, IsNew = true, HasChanges = true });
                                foreach (Firma firma1 in firmas)
                                {
                                    firma.Save(firma1);
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 4: // Opret Addresse
                            Console.Clear();
                            Console.Write("Postnummer: ");
                            int Postnummer = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Vej: ");
                            string Vej = Console.ReadLine();
                            Console.Write("KundeID: ");
                            int KundeID = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                addresses.Add(new Addresse(0) { postnummer = Postnummer, vej = Vej, kundeID = KundeID, HasChanges = true, IsNew = true });
                                foreach (Addresse addresse1 in addresses)
                                {
                                    addresse.Save(addresse1);
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 5: // Opret Order
                            Console.Clear();
                            Console.WriteLine("Opret Order: ");
                            Console.Write("KundeID: ");
                            int OrderKundeID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("AddresseID: ");
                            int OrderAddresseID = Convert.ToInt32(Console.ReadLine());

                            try
                            {
                                myOrders.Add(new MyOrder(0, OrderKundeID) { AddresseID = OrderAddresseID, OpretDate = localDate, IsNew = true, HasChanges = true });
                                foreach (MyOrder my in myOrders)
                                {
                                    myOrder.Save(my);
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 6: // Tilføre vare til Order
                            Console.Clear();
                            Console.WriteLine("Tilføre Vare til Order");
                            Console.Write("OrderID: ");
                            int vareOrderID = Convert.ToInt32(Console.ReadLine());
                            bool on = true;
                            while (on)
                            {

                                Console.WriteLine("Skive 0 vis du er don ");
                                Console.Write("VareID: ");
                                int VareID = Convert.ToInt32(Console.ReadLine());
                                if (VareID > 0)
                                {
                                    if (vares.Exists(x => x.vareID == VareID))
                                    {
                                        double xPrise;
                                        foreach (Vare vare in vares)
                                        {
                                            if (vare.vareID == VareID)
                                            {
                                                xPrise = vare.prise;
                                                Console.Write("Antal: ");
                                                int VareOrderAntal = Convert.ToInt32(Console.ReadLine());
                                                double FPrise = xPrise * VareOrderAntal;

                                                try
                                                {
                                                    for (int i = 0; i < VareOrderAntal; i++)
                                                    {
                                                        vareOrders.Add(new VareOrder(0, vareOrderID, VareID) { antal = VareOrderAntal, prise = FPrise });
                                                        foreach (VareOrder vareOrder1 in vareOrders)
                                                        {
                                                            vareOrder.Save(vareOrder1);
                                                        }

                                                    }
                                                }
                                                catch (Exception)
                                                {

                                                    throw;
                                                }

                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Den vare findes ikke");
                                    }
                                }
                                else
                                {
                                    break;
                                }


                                try
                                {

                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                            break;
                        case 7: // Vis Alle Kunder
                            Console.Clear();
                            Console.WriteLine("Alle Kunder: \n");
                            foreach (Kunder kunder in kunders)
                            {
                                Console.WriteLine("ID: {0}", kunder.kundeID);
                                Console.WriteLine("Navn: {0} {1}", kunder.fornavn, kunder.efternavn);
                                Console.WriteLine("Mobil: {0}", kunder.mobil);
                                Console.WriteLine("Email: {0}", kunder.email);
                                if (kunder.aktiv == 1)
                                {
                                    Console.WriteLine("{0} {1} er Aktiv", kunder.fornavn, kunder.efternavn);
                                }
                                else
                                {
                                    Console.WriteLine("{0} {1} er ikke Aktiv", kunder.fornavn, kunder.efternavn);
                                }
                                Console.WriteLine("Opretelese Dato: {0}", kunder.opretDate); // der er en fejl her
                                Console.WriteLine("\n");
                            }
                            break;
                        case 8: // Vis alle Vare
                            Console.Clear();
                            Console.WriteLine("Alle Vare: \n");
                            foreach (Vare vare in vares)
                            {
                                Console.WriteLine("VareID: {0}", vare.vareID);
                                Console.WriteLine("Navn: {0}", vare.navn);
                                Console.WriteLine("Antal på Lager: {0}", vare.antal);
                                Console.WriteLine("Prise: {0}", vare.prise);
                                foreach (Firma firma1 in firmas)
                                {
                                    //Console.WriteLine("Vare.FirmaID: {0} Firma.FirmaID: {1}", vare.firmaID, firma1.firmaID);
                                    if (vare.firmaID == firma1.firmaID)
                                    {
                                        Console.WriteLine("Firma: {0}", firma1.navn);
                                    }
                                    //Console.WriteLine(firma1.navn);
                                }
                                Console.WriteLine("\n");
                            }
                            break;
                        case 9: // Vis alle Firma
                            Console.Clear();
                            Console.WriteLine("Alle Firma: \n");
                            foreach (Firma firma1 in firmas)
                            {
                                Console.WriteLine("FirmaID: {0}", firma1.firmaID);
                                Console.WriteLine("Navn: {0}", firma1.navn);
                                Console.WriteLine("Telforn: {0}", firma1.mobil);
                                Console.WriteLine("Email: {0}", firma1.email);
                            }
                            break;
                        case 10: // Vis alle Addresser
                            Console.Clear();
                            Console.WriteLine("Addresser: \n");
                            foreach (Addresse addresse1 in addresses)
                            {
                                Console.WriteLine("AddresseID: {0}", addresse1.addresseID);
                                foreach (Postnummer postnummer1 in postnummers)
                                {
                                    if (addresse1.postnummer == postnummer1.postnummer)
                                    {
                                        Console.WriteLine("Postnummer: {0}", addresse1.postnummer);
                                        Console.WriteLine("By: {0}", postnummer1.byNavn);
                                    }
                                }
                                Console.WriteLine("Vej: {0}", addresse1.vej);
                                foreach (Kunder kunder in kunders)
                                {
                                    if (addresse1.kundeID == kunder.kundeID)
                                    {
                                        Console.WriteLine("Kunde: {0} {1}", kunder.fornavn, kunder.efternavn);
                                    }

                                }
                                Console.WriteLine("\n");
                            }
                            break;
                        //case 12:
                            //foreach (MyOrder order in myOrders)
                            //{
                            //    Console.WriteLine("OrderID: {0}", order.orderID);
                            //    foreach (VareOrder vareOrder1 in vareOrders)
                            //    {
                            //        if (vareOrder1.orderID == order.orderID)
                            //        {
                            //            Console.WriteLine("VareOrderID: {0}", vareOrder1.vareOrderID);
                            //            foreach (Vare vare in vares)
                            //            {
                            //                if (vareOrder1.vareID == vare.vareID)
                            //                {
                            //                    Console.WriteLine("VareNavn: {0}", vare.navn);
                            //                    Console.WriteLine("Antal: {0}", vareOrder1.antal);
                            //                    Console.WriteLine("Prise: {0}", vareOrder1.prise);
                            //                }
                            //            }
                            //        }
                            //    }
                            //    foreach (Kunder kunder in kunders)
                            //    {
                            //        if (order.kundeID == kunder.kundeID)
                            //        {
                            //            Console.WriteLine("Koeber: {0} {1}", kunder.fornavn, kunder.efternavn);
                            //        }
                            //    }
                            //    Console.WriteLine("\n");

                            //}
                            //Console.WriteLine("\n");

                            //break;
                        case 11: // Vis alle Order Med Vare
                            Console.Clear();
                            foreach (VareOrder vareOrder1 in vareOrders)
                            {
                                foreach (Vare vare in vares)
                                {
                                    if (vareOrder1.vareID == vare.vareID)
                                    {
                                        Console.WriteLine("OrderID: {0}", vareOrder1.orderID);
                                        Console.WriteLine("VareOrderID: {0}", vareOrder1.vareOrderID);
                                        Console.WriteLine("VareNavn: {0}", vare.navn);
                                        Console.WriteLine("Antal: {0}", vareOrder1.antal);
                                        Console.WriteLine("Prise: {0}", vareOrder1.prise);
                                    }
                                }
                                Console.WriteLine("\n");
                            }
                            break;
                        case 12: // Søge efter en Kunde
                            Console.Clear();
                            Console.WriteLine("Søge efter en kunde: ");
                            Console.Write("KundeID: ");
                            int SKundeID = Convert.ToInt32(Console.ReadLine());
                            if (kunders.Exists(x => x.kundeID == SKundeID))
                            {
                                foreach (Kunder kunder in kunders)
                                {
                                    if (kunder.kundeID == SKundeID)
                                    {
                                        Console.WriteLine("ID: {0}", kunder.kundeID);
                                        Console.WriteLine("Navn: {0} {1}", kunder.fornavn, kunder.efternavn);
                                        Console.WriteLine("Mobil: {0}", kunder.mobil);
                                        Console.WriteLine("Email: {0}", kunder.email);
                                        if (kunder.aktiv == 1)
                                        {
                                            Console.WriteLine("{0} {1} er Aktiv", kunder.fornavn, kunder.efternavn);
                                        }
                                        else
                                        {
                                            Console.WriteLine("{0} {1} er ikke Aktiv", kunder.fornavn, kunder.efternavn);
                                        }
                                        Console.WriteLine("Opretelese Dato: {0}", kunder.opretDate); // der er en fejl her
                                        Console.WriteLine("\n");
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("Kunde med ID: {0} Findes ikke", SKundeID);
                            }
                            break;
                        case 13: // Søge efter en Vare
                            Console.Clear();
                            Console.WriteLine("Søge efter en Vare: ");
                            Console.Write("VareID: ");
                            int SVareID = Convert.ToInt32(Console.ReadLine());
                            if (vares.Exists(x => x.vareID == SVareID))
                            {
                                foreach (Vare vare in vares)
                                {
                                    if (vare.vareID == SVareID)
                                    {
                                        Console.WriteLine("VareID: {0}", vare.vareID);
                                        Console.WriteLine("Navn: {0}", vare.navn);
                                        Console.WriteLine("Antal på Lager: {0}", vare.antal);
                                        Console.WriteLine("Prise: {0}", vare.prise);
                                        foreach (Firma firma1 in firmas)
                                        {
                                            //Console.WriteLine("Vare.FirmaID: {0} Firma.FirmaID: {1}", vare.firmaID, firma1.firmaID);
                                            if (vare.firmaID == firma1.firmaID)
                                            {
                                                Console.WriteLine("Firma: {0}", firma1.navn);
                                            }
                                            //Console.WriteLine(firma1.navn);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Vare med ID: {0} finde ikke", SVareID);
                            }
                            break;
                        case 14:
                            Console.Clear();
                            Console.WriteLine("Søge efter et Firma: ");
                            Console.Write("FirmaID: ");
                            int SFirmaID = Convert.ToInt32(Console.ReadLine());
                            if (firmas.Exists(x => x.firmaID == SFirmaID))
                            {
                                foreach (Firma firma1 in firmas)
                                {
                                    if (SFirmaID == firma1.firmaID)
                                    {
                                        Console.WriteLine("FirmaID: {0}", firma1.firmaID);
                                        Console.WriteLine("Navn: {0}", firma1.navn);
                                        Console.WriteLine("Telforn: {0}", firma1.mobil);
                                        Console.WriteLine("Email: {0}", firma1.email);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Firma med ID: {0} findes ikke", SFirmaID);
                            }
                            break;
                        case 15:
                            Console.Clear();
                            Console.WriteLine("Søge efter en Addresse Med KundeID: ");
                            Console.Write("KundeID: ");
                            int SAddresseID = Convert.ToInt32(Console.ReadLine());
                            if (kunders.Exists(x => x.kundeID == SAddresseID))
                            {
                                foreach (Addresse addresse1 in addresses)
                                {
                                    if (addresse1.kundeID == SAddresseID)
                                    {
                                        Console.WriteLine("AddresseID: {0}", addresse1.addresseID);
                                        foreach (Postnummer postnummer1 in postnummers)
                                        {
                                            if (addresse1.postnummer == postnummer1.postnummer)
                                            {
                                                Console.WriteLine("Postnummer: {0}", addresse1.postnummer);
                                                Console.WriteLine("By: {0}", postnummer1.byNavn);
                                            }
                                        }
                                        Console.WriteLine("Vej: {0}", addresse1.vej);
                                        foreach (Kunder kunder in kunders)
                                        {
                                            if (addresse1.kundeID == kunder.kundeID)
                                            {
                                                Console.WriteLine("Kunde: {0} {1}", kunder.fornavn, kunder.efternavn);
                                            }

                                        }
                                    }
                                }
                            }
                            else
                            {

                            }
                            break;
                        case 16:
                            Console.Clear();
                            Console.WriteLine("Order's");
                            Console.Write("OrderID: ");
                            int SSVareOrderID = Convert.ToInt32(Console.ReadLine());
                            if (vareOrders.Exists(x => x.orderID == SSVareOrderID))
                            {
                                foreach (VareOrder vareOrder1 in vareOrders)
                                {
                                    if (vareOrder1.orderID == SSVareOrderID)
                                    {
                                        Console.WriteLine("VareOrderID: {0}", vareOrder1.vareOrderID);
                                        Console.WriteLine("OrderID: {0}", vareOrder1.orderID);
                                        foreach (Vare vare in vares)
                                        {
                                            if (vare.vareID == vareOrder1.vareID)
                                            {
                                                Console.WriteLine("VareID: {0}", vare.vareID);
                                                Console.WriteLine("VareNavn: {0}", vare.navn);
                                            }
                                        }
                                        Console.WriteLine("Antal: {0}", vareOrder1.antal);
                                        Console.WriteLine("Prise: {0}", vareOrder1.prise);
                                    }
                                    //Console.WriteLine(vareOrder1.ToString());
                                }
                                Console.WriteLine("\n");
                            }
                            break;
                        case 17:
                            Console.Clear();
                            Console.WriteLine("Ændre Kunde Oplysinger: ");
                            Console.Write("KundeID: ");
                            int CKunderID = Convert.ToInt32(Console.ReadLine());
                            foreach (Kunder kunder in kunders)
                            {
                                if (kunder.kundeID == CKunderID)
                                {
                                    Console.WriteLine("Vis du lader fælt være tomet bliver det ikke ændre");
                                    Console.Write("Fornavn: ");
                                    string CFornavn = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CFornavn)))
                                    {
                                        kunder.fornavn = CFornavn;
                                        kunder.HasChanges = true;
                                    }
                                    Console.Write("Efternavn: ");
                                    string CEfternavn = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CEfternavn)))
                                    {
                                        kunder.efternavn = CEfternavn;
                                        kunder.HasChanges = true;
                                    }
                                    Console.Write("Email: ");
                                    string CEmail = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CEmail)))
                                    {
                                        kunder.email = CEmail;
                                        kunder.HasChanges = true;
                                    }
                                    Console.Write("Mobil: ");
                                    string CMobil = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CMobil)))
                                    {
                                        int ICMobil = Convert.ToInt32(CMobil);
                                        if (ICMobil != kunder.mobil && ICMobil > 0)
                                        {
                                            kunder.mobil = ICMobil;
                                            kunder.HasChanges = true;
                                        }
                                    }
                                    //kunderS.Save(kunder);

                                    if (kunder.HasChanges)
                                    {
                                        kunderS.Save(kunder);
                                    }


                                    //Console.WriteLine(kunder.ToString());
                                    //Console.WriteLine("\n");
                                    //kunder.fornavn = "Allan";
                                    //Console.WriteLine("\n");
                                    //Console.WriteLine(kunder.ToString());

                                }
                            }
                            break;
                        case 18:
                            Console.Clear();
                            Console.WriteLine("Ændre Vare Oplysinger: ");
                            Console.Write("VareID: ");
                            int CVareID = Convert.ToInt32(Console.ReadLine());
                            foreach (Vare vare in vares)
                            {
                                if (vare.vareID == CVareID)
                                {
                                    Console.WriteLine("Vis du lader fælt være tomet bliver det ikke ændre");
                                    Console.Write("Navn: ");
                                    string CNavn = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CNavn)))
                                    {
                                        vare.navn = CNavn;
                                        vare.HasChanges = true;
                                    }
                                    Console.Write("Prise: ");
                                    string CMobil = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CMobil)))
                                    {
                                        float ICMobil = float.Parse(CMobil, CultureInfo.InvariantCulture.NumberFormat);
                                        if (ICMobil != vare.prise && ICMobil > 0)
                                        {
                                            vare.prise = ICMobil;
                                            vare.HasChanges = true;
                                        }
                                    }
                                    Console.Write("Antal: ");
                                    string CAntal = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CMobil)))
                                    {
                                        int ICAntal = Convert.ToInt32(CAntal);
                                        if (ICAntal != vare.antal && ICAntal > 0)
                                        {
                                            vare.antal = ICAntal;
                                            vare.HasChanges = true;
                                        }
                                    }
                                    if (vare.HasChanges)
                                    {
                                        Vares.Save(vare);
                                    }
                                }
                            }
                            break;
                        case 19:
                            Console.Clear();
                            Console.WriteLine("Ændre Firma Oplysinger: ");
                            Console.Write("VareID: ");
                            int CFirmaID = Convert.ToInt32(Console.ReadLine());
                            foreach (Firma firma1 in firmas)
                            {
                                if (firma1.firmaID == CFirmaID)
                                {
                                    Console.WriteLine("Vis du lader fælt være tomet bliver det ikke ændre");
                                    Console.Write("Navn: ");
                                    string CFNavn = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CFNavn)))
                                    {
                                        firma1.navn = CFNavn;
                                        firma1.HasChanges = true;
                                    }
                                    Console.Write("Mobil: ");
                                    string CFMobil = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CFMobil)))
                                    {
                                        int ICFMobil = Convert.ToInt32(CFMobil);
                                        if (ICFMobil != firma1.mobil && ICFMobil > 0)
                                        {
                                            firma1.mobil = ICFMobil;
                                            firma1.HasChanges = true;
                                        }
                                    }
                                    Console.Write("Email: ");
                                    string CFEmail = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CFEmail)))
                                    {
                                        firma1.email = CFEmail;
                                        firma1.HasChanges = true;
                                    }
                                    if (firma1.HasChanges)
                                    {
                                        firma.Save(firma1);
                                    }


                                }
                            }
                            break;
                        case 20:
                            Console.Clear();
                            Console.WriteLine("Ændre Addresse Oplysinger: ");
                            Console.Write("AddresseID: ");
                            int CAddresseID = Convert.ToInt32(Console.ReadLine());
                            foreach (Addresse addresse1 in addresses)
                            {
                                if (addresse1.addresseID == CAddresseID)
                                {
                                    Console.WriteLine("Vis du lader fælt være tomet bliver det ikke ændre");
                                    Console.Write("Postnummer: ");
                                    string CAPostnummer = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CAPostnummer)))
                                    {
                                        int ICAPostnummer = Convert.ToInt32(CAPostnummer);
                                        if (ICAPostnummer != addresse1.postnummer && ICAPostnummer > 0)
                                        {
                                            addresse1.postnummer = ICAPostnummer;
                                            addresse1.HasChanges = true;
                                        }
                                    }
                                    Console.Write("Vej: ");
                                    string CANavn = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CANavn)))
                                    {
                                        addresse1.vej = CANavn;
                                        addresse1.HasChanges = true;
                                    }
                                }
                                if (addresse1.HasChanges)
                                {
                                    addresse.Save(addresse1);
                                }
                            }
                            break;
                        case 21:
                            Console.Clear();
                            Console.WriteLine("Ændre VareOrder Oplysinger: ");
                            Console.WriteLine("Vis du lader fælt være tomet bliver det ikke ændre");
                            Console.Write("VareOrderID: ");
                            int CVareOrderID = Convert.ToInt32(Console.ReadLine());
                            foreach (VareOrder vareOrder1 in vareOrders)
                            {
                                if (vareOrder1.vareOrderID == CVareOrderID)
                                {
                                    //Console.Write("VareID: ");
                                    //string CVareID = Console.ReadLine();
                                    //if (!(string.IsNullOrWhiteSpace(CVareID)))
                                    //{
                                    //    int ICVareID = Convert.ToInt32(CVareID);
                                    //    if (ICVareID != vareOrder1.vareID && ICVareID > 0)
                                    //    {
                                    //        vareOrder1.vareID = ICVareID;
                                    //        vareOrder1.HasChanges = true;
                                    //    }
                                    //}
                                    Console.Write("Prise: ");
                                    string CPrise = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CPrise)))
                                    {
                                        float ICPrise = float.Parse(CPrise, CultureInfo.InvariantCulture.NumberFormat);
                                        if (ICPrise != vareOrder1.prise && ICPrise > 0)
                                        {
                                            vareOrder1.prise = ICPrise;
                                            vareOrder1.HasChanges = true;
                                        }
                                    }
                                    Console.Write("Antal: ");
                                    string CAntal = Console.ReadLine();
                                    if (!(string.IsNullOrWhiteSpace(CAntal)))
                                    {
                                        int ICAntal = Convert.ToInt32(CAntal);
                                        if (ICAntal != vareOrder1.antal && ICAntal > 0)
                                        {
                                            vareOrder1.antal = ICAntal;
                                            vareOrder1.HasChanges = true;
                                        }
                                    }
                                    if (vareOrder1.HasChanges)
                                    {
                                        vareOrder.Save(vareOrder1);

                                    }
                                }
                            }
                            break;
                        case 0:
                            m.ListMenu();
                            break;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }



            //Console.ReadKey();
        }
    }
}
