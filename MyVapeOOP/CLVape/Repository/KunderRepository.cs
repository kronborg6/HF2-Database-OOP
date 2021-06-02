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
        public int AddKunderTilDB(string fornavn, string efternavn, string email, int mobil)
        {
            try
            {
                //StringBuilder result = new StringBuilder();

                SqlConn.openConnection();

                SqlConn.sql = "dbo.AddKunder";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@Fornavn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(fornavn) ? (object)DBNull.Value : fornavn;
                SqlConn.cmd.Parameters.Add("@Efternavn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(efternavn) ? (object)DBNull.Value : efternavn;
                SqlConn.cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = string.IsNullOrEmpty(email) ? (object)DBNull.Value : email;
                SqlConn.cmd.Parameters.Add("@Mobil", SqlDbType.Int).Value = Equals(mobil, 0) ? (object)DBNull.Value : mobil;

                SqlConn.cmd.Parameters.Add(new SqlParameter("@Lid", SqlDbType.Int));
                SqlConn.cmd.Parameters["@Lid"].Direction = ParameterDirection.Output;
                SqlConn.cmd.ExecuteNonQuery();

                int rtnID = (int)SqlConn.cmd.Parameters["@Lid"].Value;

                //Console.WriteLine(rtnID);

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
        public void UpdateKunderDB(int ID, string fornavn, string efternavn, string email, int mobil)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "dbo.UpdateKunder";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@Fornavn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(fornavn) ? (object)DBNull.Value : fornavn;
                SqlConn.cmd.Parameters.Add("@Efternavn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(efternavn) ? (object)DBNull.Value : efternavn;
                SqlConn.cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = string.IsNullOrEmpty(email) ? (object)DBNull.Value : email;
                SqlConn.cmd.Parameters.Add("@Mobil", SqlDbType.Int).Value = Equals(mobil, 0) ? (object)DBNull.Value : mobil;
                SqlConn.cmd.Parameters.Add("@KunderID", SqlDbType.Int).Value = Equals(ID, 0) ? (object)DBNull.Value : ID;
                SqlConn.cmd.ExecuteNonQuery();

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
