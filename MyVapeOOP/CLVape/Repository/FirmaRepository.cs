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
        public int AddFirmaTilDB(string navn, string email, int mobil)
        {
            try
            {
                //StringBuilder result = new StringBuilder();

                SqlConn.openConnection();

                SqlConn.sql = "dbo.AddFirma";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@Navn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(navn) ? (object)DBNull.Value : navn;
                SqlConn.cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = string.IsNullOrEmpty(email) ? (object)DBNull.Value : email;
                SqlConn.cmd.Parameters.Add("@Teleforn", SqlDbType.Int).Value = Equals(mobil, 0) ? (object)DBNull.Value : mobil;

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
        public void UpdateFirmaDB(int ID, string navn, string email, int mobil)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "dbo.UpdateFirma";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@Navn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(navn) ? (object)DBNull.Value : navn;
                SqlConn.cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = string.IsNullOrEmpty(email) ? (object)DBNull.Value : email;
                SqlConn.cmd.Parameters.Add("@Teleforn", SqlDbType.Int).Value = Equals(mobil, 0) ? (object)DBNull.Value : mobil;
                SqlConn.cmd.Parameters.Add("@FirmaID", SqlDbType.Int).Value = Equals(ID, 0) ? (object)DBNull.Value : ID;

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
