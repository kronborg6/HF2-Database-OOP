using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CLVape.Repository;


namespace CLVape
{
    public class MyOrder
    {
        public int orderID { get; private set; }
        public int kundeID { get; private set; }
        public int AddresseID { get; set; }
        public DateTime OpretDate { get; set; }
        public MyOrder()
        {

        }
        
        public List<MyOrder> getMyOrder() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            List<MyOrder> myOrders = new List<MyOrder>();

            MyOrderRepository myOrderRepository = new MyOrderRepository();

            try
            {
                myOrders = myOrderRepository.GetMyOrdersFraDB();
            }
            catch (Exception)
            {

                throw;
            }

            return myOrders;
        }
        
    }
}
