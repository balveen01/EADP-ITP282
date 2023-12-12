using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Doosan.models;

namespace Doosan.BLL
{
    public class BllPayment
    {
        public DataSet GetPayment()
        {
            PaymentModel dal;
            DataSet paymentlist;

            dal = new PaymentModel();
            paymentlist = dal.GetAPaymet();

            return paymentlist;
        }

        public DataSet GetDetail(int id)
        {

            PaymentModel dal;
            DataSet paymentlist;

            dal = new PaymentModel();
            paymentlist = dal.GetDetail(id);

            return paymentlist;
        }

        public void updateStatus(int id)
        {
            PaymentModel pay;
            pay = new PaymentModel();
            pay.updateStatus(id);
        }

        public void updateStatusDecline(int id)
        {
            PaymentModel pay;
            pay = new PaymentModel();
            pay.updateStatusDecline(id);
        }
    }
}