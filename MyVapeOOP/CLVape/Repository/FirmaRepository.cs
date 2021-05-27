using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape.Repository
{
    public class FirmaRepository
    {
        public List<Firma> GetFirmaFraDB()
        {

            List<Firma> firmas = new List<Firma>();

            try
            {
                SqlConn.openConnection();
                SqlConn.sql = "SELECT * FROM Firma";
                SqlConn.cmd.CommandType = CommandType.Text;
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        firmas.Add(new Firma(FirmaID: Convert.ToInt32(sdr["KundeID"]))
                        {
                            //firmaID = Convert.ToInt32(sdr["KundeID"]),
                            navn = sdr["Fornavn"].ToString(),
                            mobil = Convert.ToInt32(sdr["Mobil"]),
                            email = sdr["Email"].ToString()
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
            return firmas;

        }
    }
}
