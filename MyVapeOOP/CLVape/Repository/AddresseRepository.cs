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
        public int AddAddresseDB(string vej, int postnummer, int kundeID)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "dbo.AddAddresse";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@Vej", SqlDbType.VarChar).Value = string.IsNullOrEmpty(vej) ? (object)DBNull.Value : vej;
                SqlConn.cmd.Parameters.Add("@Postnummer", SqlDbType.Int).Value = Equals(postnummer, 0) ? (object)DBNull.Value : postnummer;
                SqlConn.cmd.Parameters.Add("@KundeID", SqlDbType.Int).Value = Equals(kundeID, 0) ? (object)DBNull.Value : kundeID;

                SqlConn.cmd.Parameters.Add(new SqlParameter("@Lid", SqlDbType.Int));
                SqlConn.cmd.Parameters["@Lid"].Direction = ParameterDirection.Output;
                SqlConn.cmd.ExecuteNonQuery();

                int rtnID = (int)SqlConn.cmd.Parameters["@Lid"].Value;


                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();


                return rtnID;
            }
            catch (Exception er)
            {
                Console.WriteLine("VareRep der er sket en fjel: {0}", er);
                throw;
            }
        }
        public void UpdateAddresseDB(int ID, string vej, int postnummer, int kundeID)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "dbo.UpdateAddresse";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;

                SqlConn.cmd.Parameters.Add("@Vej", SqlDbType.VarChar).Value = string.IsNullOrEmpty(vej) ? (object)DBNull.Value : vej;
                SqlConn.cmd.Parameters.Add("@Postnummer", SqlDbType.Int).Value = Equals(postnummer, 0) ? (object)DBNull.Value : postnummer;
                SqlConn.cmd.Parameters.Add("@KundeID", SqlDbType.Int).Value = Equals(kundeID, 0) ? (object)DBNull.Value : kundeID;
                SqlConn.cmd.Parameters.Add("@AddresseID", SqlDbType.Int).Value = Equals(ID, 0) ? (object)DBNull.Value : ID;

                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
