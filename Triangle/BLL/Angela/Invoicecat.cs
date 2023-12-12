using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Triangle.models;

namespace Triangle.BLL
{
    public class Invoicecat
    {
        public DataSet getinvoice()
        {
            Invoice dal;
            DataSet invoicelist;

            dal = new Invoice();
            invoicelist = dal.Getinvoice();

            return invoicelist;
        }
    }
}