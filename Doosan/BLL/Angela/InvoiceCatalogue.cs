using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Doosan.DAL;

namespace Doosan.BLL
{
    public class InvoiceCatalogue
    {
        public DataSet GetInvoices()
        {
            dalInvoice dataLayerInvoices;

            dataLayerInvoices = new dalInvoice();
            return dataLayerInvoices.GetAllInvoice();
        }
    }
}