using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CLVape
{
    public class Kunder
    {
        public int kundeID { get; private set; }
        public string fornavn { get; set; }
        public string efternavn { get; set; }
        public string email { get; set; }
        public int mobil { get; set; }
        public int aktiv { get; set; }
        public DateTime opretDate { get; set; }
        public Kunder()
        {

        }
        public List<Kunder> getCustomer() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Kunder";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

            List<Kunder> kunders = new List<Kunder>();

            try
            {
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        kunders.Add(new Kunder
                        {
                            kundeID = Convert.ToInt32(sdr["KundeID"]),
                            fornavn = sdr["Fornavn"].ToString(),
                            efternavn = sdr["Efternavn"].ToString(),
                            mobil = Convert.ToInt32(sdr["Mobil"]),
                            email = sdr["Email"].ToString(),
                            aktiv = Convert.ToInt32(sdr["Aktiv"]),
                        });
                        //Console.WriteLine("New Customer Add From DB");
                    }
                }
                SqlConn.cmd.Parameters.Clear();
                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
            return kunders;
        }
        public override string ToString()
        {
            return "ID: " + kundeID + " Fornavn: " + fornavn + " Efternavn: " + efternavn + " Mobil: " + mobil + " Email: " + email;
        }
    }
}
