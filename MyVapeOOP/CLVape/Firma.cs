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
    public class Firma
    {
        public int firmaID { get; private set; }
        public string navn { get; set; }
        public int mobil { get; set; }
        public string email { get; set; }
        public Firma() : this(0)
        {
        }
        public Firma(int FirmaID)
        {
            this.firmaID = FirmaID;
        }
        
        public List<Firma> getFirma() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {

            List<Firma> firmas = new List<Firma>();
            FirmaRepository firmaRepository = new FirmaRepository();
            try
            {
                firmas = firmaRepository.GetFirmaFraDB();
            }
            catch (Exception)
            {

                throw;
            }
            return firmas;
        }
        
    }
}
