using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Doosan.models;
using System.Data;

namespace Doosan.BLL
{
    public class DeliveryBLL
    {
        DeliveryModel deliveryModel = new DeliveryModel();

        public DataSet getDelivery(int id)
        {
            return deliveryModel.getDelivery(id);
        }

        public DataSet getAllDeliveries()
        {
            return deliveryModel.getAllDeliveries();
        }

        public DataSet getAllDeliveriesArchived()
        {
            return deliveryModel.getAllDeliveriesArchived();
        }

        public DataSet getDeliveryFullDetails()
        {
            return deliveryModel.getDeliveryFullDetails();
        }

        public DataSet getDeliveryFullDetailsArchived()
        {
            return deliveryModel.getDeliveryFullDetailsArchived();
        }

        public DataSet getDeliveryFullDetails(int id)
        {
            return deliveryModel.getDeliveryFullDetails(id);
        }

        public DataSet getDeliveryFullDetailsOrderId(int id)
        {
            return deliveryModel.getDeliveryFullDetails(id);
        }

        public DataSet getDeliveryFullDetailsByCompany(int id)
        {
            return deliveryModel.getDeliveryFullDetailsByCompany(id);
        }

        public int changeDeliveryStatusDelivered(string id)
        {
            return DeliveryStatus.SetIsDelivered(id);
        }

        public DataSet getDeliveryBySearch(string Keyword)
        {
            return deliveryModel.getDeliveriesBySearch(Keyword);
        }

        public DataSet getDeliveryArchivedBySearch(string Keyword)
        {
            return deliveryModel.getDeliveriesArchivedBySearch(Keyword);
        }
    }
}