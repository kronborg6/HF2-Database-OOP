using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape
{
    public class Postnummer
    {
        public int postnummer 
        { 
            get
            {
                return postnummer;
            } 
            private set 
            {
                if (value > 999 & value < 10000) 
                {
                    postnummer = value;
                }
            }
        }

        public string byNavn { get; set; }
        public Postnummer()
        {

        }
        public List<Postnummer> getPostnummer() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Kunder";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

            List<Postnummer> postnummers = new List<Postnummer>();

            try
            {
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        postnummers.Add(new Postnummer
                        {
                            postnummer = Convert.ToInt32(sdr["Postnummer"]),
                            byNavn = sdr["Bynavn"].ToString()
                        });
                        //Console.WriteLine("New Customer Add From DB");
                    }
                }
                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
            return postnummers;
        }
    }
}
