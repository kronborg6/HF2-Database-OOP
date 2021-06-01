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
                        myOrders.Add(new MyOrder
                        {
                            //orderID = Convert.ToInt32(sdr["KundeID"]),
                            //kundeID = Convert.ToInt32(sdr["KundeID"]),
                            AddresseID = Convert.ToInt32(sdr["KundeID"]),
                            OpretDate = Convert.ToDateTime(sdr["Fornavn"]),

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
    }
}
