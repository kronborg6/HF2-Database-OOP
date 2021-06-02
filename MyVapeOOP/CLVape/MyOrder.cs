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
    public class MyOrder : EntityBase
    {
        public int orderID { get; private set; }
        public int kundeID { get; private set; }
        public int AddresseID { get; set; }
        public DateTime OpretDate { get; set; }

        public MyOrder(int OrderID, int KundeID)
        {
            if (OrderID == 0)
            {
                this.orderID = OrderID;
                this.kundeID = KundeID;
                this.IsNew = true;
                this.HasChanges = true;
            }
            else
            {
                this.orderID = OrderID;
                this.kundeID = KundeID;
                //this.HasChanges = true;
            }
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
        public override string ToString()
        {
            return "ID: " + orderID + " Navn: " + kundeID + " Prise: " + AddresseID + "\n";
        }

        public override bool Validate()
        {
            var isValid = true;

            if (AddresseID <= 0) isValid = false;
            if (kundeID <= 0) isValid = false;

            return isValid;
        }
        public bool Save(MyOrder myOrder)
        {
            var success = true;

            if (myOrder.HasChanges)
            {
                if (myOrder.IsValid)
                {
                    if (myOrder.IsNew)
                    {
                        MyOrderRepository myOrderRepository = new MyOrderRepository();

                        myOrder.orderID = myOrderRepository.AddVareOrderTilDB(myOrder.kundeID, myOrder.AddresseID);

                        myOrder.IsNew = false;
                        myOrder.HasChanges = false;
                    }
                    else
                    {
                        MyOrderRepository myOrderRepository = new MyOrderRepository();

                        myOrderRepository.UpdateVareOrderDB(myOrder.orderID, myOrder.kundeID, myOrder.AddresseID);

                        myOrder.HasChanges = false;
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
