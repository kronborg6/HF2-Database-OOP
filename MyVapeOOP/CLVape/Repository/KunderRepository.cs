using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape.Repository
{
    public class KunderRepository
    {
        public List<Kunder> GetKunderFraDB()
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
                        kunders.Add(new Kunder(Convert.ToInt32(sdr["KundeID"]))
                        {
                            //kundeID = Convert.ToInt32(sdr["KundeID"]),
                            //kundeID = 10,
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
                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
            return kunders;
        }
    }
    
}
