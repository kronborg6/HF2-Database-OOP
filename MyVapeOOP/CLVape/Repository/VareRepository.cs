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
        public static int GetNextVareID()
        {
            int ID = 0;

            try
            {
                SqlConn.openConnection();
                SqlConn.sql = "SELECT VareID FROM Vare";
                SqlConn.cmd.CommandType = CommandType.Text;
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["VareID"]) + 1;
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

            return ID;
        }
        public List<Vare> GetVareFraDB()
        {
            SqlConn.openConnection();
            //SqlConn.sql = "SELECT * FROM Vare";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = "SELECT * FROM Vare";
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

            List<Vare> vares = new List<Vare>();

            try
            {
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
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
                            //Console.WriteLine("New Customer Add From DB {0}", iid);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data");
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
        public int AddVareTilDB(string navn, double price, int antal, int firmaID)
        {
            try
            {
                //StringBuilder result = new StringBuilder();

                SqlConn.openConnection();

                SqlConn.sql = "dbo.AddVare";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@Navn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(navn) ? (object)DBNull.Value : navn;
                SqlConn.cmd.Parameters.Add("@Prise", SqlDbType.Float).Value = Equals(price, 0) ? (object)DBNull.Value : price;
                SqlConn.cmd.Parameters.Add("@Antal", SqlDbType.Int).Value = Equals(antal, 0) ? (object)DBNull.Value : antal;
                SqlConn.cmd.Parameters.Add("@FirmaID", SqlDbType.Int).Value = Equals(firmaID, 0) ? (object)DBNull.Value : firmaID;

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
        public void UpdateVareDB(int ID, string navn, double price, int antal, int firmaID)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "dbo.AddVare";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@Navn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(navn) ? (object)DBNull.Value : navn;
                SqlConn.cmd.Parameters.Add("@Prise", SqlDbType.Float).Value = Equals(price, 0) ? (object)DBNull.Value : price;
                SqlConn.cmd.Parameters.Add("@Antal", SqlDbType.Int).Value = Equals(antal, 0) ? (object)DBNull.Value : antal;
                SqlConn.cmd.Parameters.Add("@FirmaID", SqlDbType.Int).Value = Equals(firmaID, 0) ? (object)DBNull.Value : firmaID;
                SqlConn.cmd.Parameters.Add("@VareID", SqlDbType.Int).Value = Equals(ID, 0) ? (object)DBNull.Value : ID;

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
