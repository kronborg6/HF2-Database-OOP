using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CLVape.Repository;
using System.Data;
using System.Data.SqlClient;

namespace CLVape
{
    public class Postnummer
    {
        //public int postnummer
        //{
        //    get
        //    {
        //        return postnummer;
        //    }
        //    private set
        //    {
        //        if (value <= 999 || value >= 10000)
        //        {
        //            return;
        //        }
        //        postnummer = value;
        //    }
        //}
        private int _postnummer;

        public int postnummer
        {
            get { return _postnummer; }

            set
            {
                if (value > 999 && value < 10000)
                {
                    _postnummer = value;

                }
            }
        }

        //public int postnummer { get; set; }
        public string byNavn { get; set; }
        public Postnummer() : this(0)
        {

        }
        public Postnummer(int postnummerID)
        {
            this.postnummer = postnummerID;
        }
        public List<Postnummer> getPostnummer() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            try
            {
                List<Postnummer> postnummers = new List<Postnummer>();

                PostnummerRepository postnummerRepository = new PostnummerRepository();

                postnummers = postnummerRepository.GetPostnummerDB();

                return postnummers;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public override string ToString()
        {
            return "Postnummer: " + postnummer + " Bynavn: " + byNavn;
        }
    }
}
