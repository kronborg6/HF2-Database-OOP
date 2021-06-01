using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape.Repository
{
    public class VareOrderRepository
    {
        public List<VareOrder> GetVareOrdersFraDB()
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM VareOrder";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

            List<VareOrder> vareOrders = new List<VareOrder>();

            try
            {
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        vareOrders.Add(new VareOrder(VareOrderID: Convert.ToInt32(sdr["KundeID"]), OrderID: Convert.ToInt32(sdr["KundeID"]), VareID: Convert.ToInt32(sdr["KundeID"]))
                        {
                            //vareOrderID = Convert.ToInt32(sdr["KundeID"]),
                            //orderID = Convert.ToInt32(sdr["KundeID"]),
                            //vareID = Convert.ToInt32(sdr["KundeID"]),
                            antal = Convert.ToInt32(sdr["KundeID"]),
                            prise = Convert.ToDouble(sdr["Prise"]),
                            sendtDate = Convert.ToDateTime(sdr["Fornavn"])
                        });
                    }
                }
                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
            return vareOrders;
        }
        public int AddVareOrderTilDB(int orderID, int vareID, int antal, double price)
        {
            try
            {
                //StringBuilder result = new StringBuilder();

                SqlConn.openConnection();

                SqlConn.sql = "dbo.AddVareOrder";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = Equals(orderID, 0) ? (object)DBNull.Value : orderID;
                SqlConn.cmd.Parameters.Add("@VareID", SqlDbType.Int).Value = Equals(vareID, 0) ? (object)DBNull.Value : vareID;
                SqlConn.cmd.Parameters.Add("@Antal", SqlDbType.Int).Value = Equals(antal, 0) ? (object)DBNull.Value : antal;
                SqlConn.cmd.Parameters.Add("@Prise", SqlDbType.Float).Value = Equals(price, 0) ? (object)DBNull.Value : price;

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
        public void UpdateVareOrderDB(int ID, int orderID, int vareID, int antal, double price)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "dbo.AddVareOrder";
                SqlConn.cmd.CommandText = SqlConn.sql;
                SqlConn.cmd.CommandType = CommandType.StoredProcedure;


                SqlConn.cmd.Parameters.Add("@VareOrderID", SqlDbType.Int).Value = Equals(ID, 0) ? (object)DBNull.Value : ID;
                SqlConn.cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = Equals(orderID, 0) ? (object)DBNull.Value : orderID;
                SqlConn.cmd.Parameters.Add("@VareID", SqlDbType.Int).Value = Equals(vareID, 0) ? (object)DBNull.Value : vareID;
                SqlConn.cmd.Parameters.Add("@Antal", SqlDbType.Int).Value = Equals(antal, 0) ? (object)DBNull.Value : antal;
                SqlConn.cmd.Parameters.Add("@Prise", SqlDbType.Float).Value = Equals(price, 0) ? (object)DBNull.Value : price;

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
