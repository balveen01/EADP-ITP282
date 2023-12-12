using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Triangle.models;

namespace Triangle.BLL
{
    public class BllPayment
    {
        public DataSet GetPayment()
        {
            Pay dataLayerPayment;

            dataLayerPayment = new Pay();
            return dataLayerPayment.GetAll();
        }

        public DataSet GetDetails(int id)
        {
            Pay dataLayerPayment;
            dataLayerPayment = new Pay();
            return dataLayerPayment.GetPaymentDetail(id);
        }

        public void updateStatus(int id)
        {
            Pay update;

            update = new Pay();
            update.updateStatus(id);
        }

        public void updateStatusDecline(int id)
        {
            Pay update;

            update = new Pay();
            update.updateStatusDecline(id);

        }
    }
}