using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape.Repository
{
    public class AddresseRepository
    {
        public List<Addresse> GetAddresseDB()
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Addresse";
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
                        addresses.Add(new Addresse(AddressID: Convert.ToInt32(sdr["VareID"]))
                        {
                            //addresseID = Convert.ToInt32(sdr["VareID"]),
                            postnummer = Convert.ToInt32(sdr["Postnummer"]),
                            vej = sdr["Vej"].ToString(),
                            kundeID = Convert.ToInt32(sdr["KundeID"])
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
    }
}
