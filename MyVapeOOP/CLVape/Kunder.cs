using System;
using System.Collections.Generic;
using CLVape.Repository;

namespace CLVape
{
    public class Kunder : EntityBase
    {
        public int kundeID { get; private set; }
        public string fornavn { get; set; }
        public string efternavn { get; set; }
        public string email { get; set; }
        public int mobil { get; set; }
        public int aktiv { get; set; }
        public DateTime opretDate { get; set; }
        public Kunder() : this(0)
        {
        }
        public Kunder(int KundID)
        {
            this.kundeID = KundID;
            this.IsNew = true;
        }
        public List<Kunder> getKunder() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            try
            {
                List<Kunder> kunders = new List<Kunder>();

                KunderRepository kunderRepository = new KunderRepository();

                kunders = kunderRepository.GetKunderFraDB();

                return kunders;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(fornavn)) isValid = false;
            if (string.IsNullOrWhiteSpace(efternavn)) isValid = false;

            return isValid;
        }
        public bool Save(Kunder kunder)
        {
            var success = true;

            if (kunder.HasChanges)
            {
                if (kunder.IsValid)
                {
                    if (kunder.IsNew)
                    {
                        Console.WriteLine("Test1");
                    }
                    else
                    {
                        Console.WriteLine("Test2");
                    }
                }
                else
                {
                    Console.WriteLine("Test3");
                    success = false;
                }
            }
            Console.WriteLine("Test4");
            return success;
        }
        public override string ToString()
        {
            return "ID: " + kundeID + " Fornavn: " + fornavn + " Efternavn: " + efternavn + " Mobil: " + mobil + " Email: " + email;
        }
    }
}
