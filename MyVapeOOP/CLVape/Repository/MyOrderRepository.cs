using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape.Repository
{
    public class MyOrderRepository
    {
        public List<MyOrder> GetMyOrdersFraDB()
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM MyOrder";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

            List<MyOrder> myOrders = new List<MyOrder>();

            try
            {
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        myOrders.Add(new MyOrder(Convert.ToInt32(sdr["KundeID"]), Convert.ToInt32(sdr["KundeID"]))
                        {
                            //orderID = Convert.ToInt32(sdr["KundeID"]),
                            //kundeID = Convert.ToInt32(sdr["KundeID"]),
                            AddresseID = Convert.ToInt32(sdr["AddresseID"]),
                            OpretDate = Convert.ToDateTime(sdr["OpretDate"])

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
            return myOrders;
        }
        public int AddVareOrderTilDB(int kundeID, int addresseID)
        {
            try
            {

                SqlConn.openConnection();

                SqlConn.sql = "dbo.AddMyOrder";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@KundeID", SqlDbType.Int).Value = Equals(kundeID, 0) ? (object)DBNull.Value : kundeID;
                SqlConn.cmd.Parameters.Add("@AddresseID", SqlDbType.Int).Value = Equals(addresseID, 0) ? (object)DBNull.Value : addresseID;

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
        public void UpdateVareOrderDB(int ID, int kundeID, int addresseID)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "dbo.UpdateMyOrder";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;

                SqlConn.cmd.Parameters.Add("@MyOrderID", SqlDbType.Int).Value = Equals(ID, 0) ? (object)DBNull.Value : ID;
                SqlConn.cmd.Parameters.Add("@KundeID", SqlDbType.Int).Value = Equals(kundeID, 0) ? (object)DBNull.Value : kundeID;
                SqlConn.cmd.Parameters.Add("@AddresseID", SqlDbType.Int).Value = Equals(addresseID, 0) ? (object)DBNull.Value : addresseID;
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
