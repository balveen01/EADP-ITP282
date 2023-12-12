using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Triangle.DoosanWS;

namespace Triangle.models
{
    public class DeliveryWS
    {
        DoosanAPIClient DoosanAPI = new DoosanAPIClient();

        public DataSet getDelivery(int id)
        {
            return DoosanAPI.getDelivery(id);
        }

        public DataSet getDeliveryFullDetails(int id)
        {
            return DoosanAPI.getDeliveryFullDetails(id);
        }

        public DataSet getDeliveryFullDetailsByCompany(int id)
        {
            return DoosanAPI.getDeliveryFullDetailsByCompany(id);
        }

        public int changeDeliveryStatusDelivered(string id)
        {
            return DoosanAPI.changeDeliveryStatusDelivered(id);
        }
    }
}