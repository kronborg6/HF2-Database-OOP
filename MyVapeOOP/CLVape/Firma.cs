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
    public class Firma : EntityBase
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
            if (FirmaID == 0)
            {
                this.firmaID = FirmaID;

                this.IsNew = true;
                this.HasChanges = true;
            }
            else
            {
                this.firmaID = FirmaID;

            }
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

        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(navn)) isValid = false;
            if (string.IsNullOrWhiteSpace(email)) isValid = false;


            return isValid;
        }
        public bool Save(Firma firma)
        {
            var success = true;

            if (firma.HasChanges)
            {
                if (firma.IsValid)
                {
                    if (firma.IsNew)
                    {
                        FirmaRepository firmaRepository = new FirmaRepository();

                        firma.firmaID = firmaRepository.AddFirmaTilDB(firma.navn, firma.email, firma.mobil);

                        firma.IsNew = false;
                        firma.HasChanges = false;
                    }
                    else
                    {
                        FirmaRepository firmaRepository = new FirmaRepository();

                        firmaRepository.UpdateFirmaDB(firma.firmaID, firma.navn, firma.email, firma.mobil);

                        firma.HasChanges = false;
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
