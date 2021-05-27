using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape.Repository
{
    public class VareRepository
    {
        public List<Vare> GetVareFraDB()
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
                        vares.Add(new Vare(Convert.ToInt32(sdr["VareID"]))
                        {
                            //vareID = Convert.ToInt32(sdr["VareID"]),
                            navn = sdr["Navn"].ToString(),
                            prise = Convert.ToDouble(sdr["Prise"]),
                            antal = Convert.ToInt32(sdr["Antal"]),
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
    }
}
