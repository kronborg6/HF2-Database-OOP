using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape.Repository
{
    public class PostnummerRepository
    {
        public List<Postnummer> GetPostnummerDB()
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Postnummer";
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
                        postnummers.Add(new Postnummer(Convert.ToInt32(sdr["Postnummer"]))
                        {
                            //postnummer = Convert.ToInt32(sdr["Postnummer"]),
                            byNavn = sdr["Bynavn"].ToString()
                        });
                        //Console.WriteLine("New Customer Add From DB");
                    }

                }
                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();
                return postnummers;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
