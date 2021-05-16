using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CLVape
{
    public class Addresse : EntityBase
    {
        public int addresseID { get; private set; }
        public int postnummer { get; private set; }
        public string vej { get; set; }
        public int kundeID { get; private set; }
        public Addresse()
        {

        }
        public List<Addresse> getAddresse() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Vare";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

            List<Addresse> addresses = new List<Addresse>();

            try
            {
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        addresses.Add(new Addresse
                        {
                            addresseID = Convert.ToInt32(sdr["VareID"]),
                            postnummer = Convert.ToInt32(sdr["Prise"]),
                            vej = sdr["Navn"].ToString(),
                            kundeID = Convert.ToInt32(sdr["FirmaID"])
                        });
                        //Console.WriteLine("New Customer Add From DB");
                    }
                }
                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
