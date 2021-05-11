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
    public class Vare
    {
        public int vareID { get; private set; }
        public string navn { get; set; }
        public double prise { get; set; }
        public int antal { get; set; }
        public int firmaID { get; private set; }

        public Vare()
        {

        }
        public List<Vare> getVare() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Vare";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

            List<Vare> vares = new List<Vare>();

            try
            {
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        vares.Add(new Vare
                        {
                            vareID = Convert.ToInt32(sdr["VareID"]),
                            navn = sdr["Navn"].ToString(),
                            prise = Convert.ToDouble(sdr["Prise"]),
                            //antal = Convert.ToInt32(sdr["Antal"]), når jeg laver nye tables i min database
                            firmaID = Convert.ToInt32(sdr["FirmaID"])
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
            return vares;
        }
        public override string ToString()
        {
            return "ID: " + vareID + " Navn: " + navn + " Prise: " + prise + " Antal: " + antal + "\n";
        }
    }
}
