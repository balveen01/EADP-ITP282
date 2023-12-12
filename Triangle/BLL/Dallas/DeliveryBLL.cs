using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Triangle.models;

namespace Triangle.BLL
{
    public class DeliveryBLL
    {
        DeliveryWS deliveryBll = new DeliveryWS();

        public DataSet getDelivery(int id)
        {
            return deliveryBll.getDelivery(id);
        }

        public DataSet getDeliveryFullDetails(int id)
        {
            return deliveryBll.getDeliveryFullDetails(id);
        }

        public DataSet getDeliveryFullDetailsByCompany(int id)
        {
            return deliveryBll.getDeliveryFullDetailsByCompany(id);
        }

        public int ChangeDeliveryStatusDelivered(string id)
        {
            return deliveryBll.changeDeliveryStatusDelivered(id);
        }
    }
}