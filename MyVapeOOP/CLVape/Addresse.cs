using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CLVape.Repository;


namespace CLVape
{
    public class Addresse : EntityBase
    {
        public int addresseID { get; private set; }
        public int postnummer { get; set; }
        public string vej { get; set; }
        public int kundeID { get; set; }
        //public List<Kunder> kundeID { get; set; }
        public Addresse() : this(0)
        {

        }
        public Addresse(int AddressID)
        {
            this.addresseID = AddressID;
        }
        public List<Addresse> getAddresse() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            List<Addresse> addresses = new List<Addresse>();
            AddresseRepository addresseRepository = new AddresseRepository();
            try
            {
                addresses = addresseRepository.GetAddresseDB();
            }
            catch (Exception)
            {

                throw;
            }
            return addresses;
        }
        public override bool Validate()
        {
            var isValid = true;

            if (postnummer > 999 & postnummer < 10000) isValid = false;
            if (string.IsNullOrWhiteSpace(vej)) isValid = false;

            return isValid;
        }
    }
}
