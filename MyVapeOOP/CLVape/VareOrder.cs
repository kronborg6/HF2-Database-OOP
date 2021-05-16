using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape
{
    public class VareOrder
    {
        public int vareOrderID { get; private set; }
        public int orderID { get; private set; }
        public int vareID { get; private set; }
        public int antal { get; set; }
        public double prise { get; set; }
        public DateTime sendtDate { get; set; }

        public VareOrder()
        {

        }
        
        public List<VareOrder> getVareOrder() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Kunder";
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
                        vareOrders.Add(new VareOrder
                        {
                            vareOrderID = Convert.ToInt32(sdr["KundeID"]),
                            orderID = Convert.ToInt32(sdr["KundeID"]),
                            vareID = Convert.ToInt32(sdr["KundeID"]),
                            antal = Convert.ToInt32(sdr["KundeID"]),
                            prise = Convert.ToDouble(sdr["Prise"]),
                            sendtDate = Convert.ToDateTime(sdr["Fornavn"])
                        });
                        //Console.WriteLine("New Customer Add From DB");
                    }
                }
                SqlConn.cmd.Parameters.Clear();
                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
            return vareOrders;
        }
        
    }
}
