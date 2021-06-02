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
    public class VareOrder : EntityBase
    {
        public int vareOrderID { get; private set; }
        public int orderID { get; private set; }
        public int vareID { get; private set; }
        public int antal { get; set; }
        public double prise { get; set; }
        public DateTime sendtDate { get; set; }

        public VareOrder(int VareOrderID, int OrderID, int VareID)
        {
            if (vareOrderID == 0)
            {
                this.vareOrderID = VareOrderID;
                this.orderID = OrderID;
                this.vareID = VareID;

                this.IsNew = true;
                this.HasChanges = true;
            }
            else
            {
                this.vareOrderID = VareOrderID;
                this.orderID = OrderID;
                this.vareID = VareID;
                //this.HasChanges = true;
            }
        }

        public List<VareOrder> getVareOrder() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            List<VareOrder> vareOrders = new List<VareOrder>();
            VareOrderRepository vareOrderRepository = new VareOrderRepository();

            try
            {
                vareOrders = vareOrderRepository.GetVareOrdersFraDB();
            }
            catch (Exception)
            {

                throw;
            }

            return vareOrders;
        }

        public override bool Validate()
        {
            var isValid = true;

            if (vareID <= 0) isValid = false;
            //if (orderID <= 0) isValid = false;
            if (prise <= 0) isValid = false;

            return isValid;
        }

        public bool Save(VareOrder vareOrder)
        {
            var success = true;

            if (vareOrder.HasChanges)
            {
                if (vareOrder.IsValid)
                {
                    if (vareOrder.IsNew)
                    {
                        VareOrderRepository vareOrderRepository = new VareOrderRepository();

                        vareOrder.vareOrderID = vareOrderRepository.AddVareOrderTilDB(vareOrder.orderID, vareOrder.vareID, vareOrder.antal, vareOrder.prise);

                        vareOrder.IsNew = false;
                        vareOrder.HasChanges = false;
                    }
                    else
                    {
                        VareOrderRepository vareOrderRepository = new VareOrderRepository();

                        vareOrderRepository.UpdateVareOrderDB(vareOrder.vareOrderID, vareOrder.orderID, vareOrder.vareID, vareOrder.antal, vareOrder.prise);

                        vareOrder.HasChanges = false;
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
        public override string ToString()
        {
            return "ID: " + vareOrderID + " OrderID: " + orderID + " VareID: " + vareID + " Antal: " + antal + " Prise: " + prise;
        }
    }
}
