using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Triangle.models
{
    public class Invoice
    {
        public DataSet Getinvoice()
        {
            //DataSet ds = new DataSet();
            //return ds;
            DoosanWS.DoosanAPIClient invoice;
            invoice = new DoosanWS.DoosanAPIClient();
            return invoice.Getallinvoice();
        }
    }
}