using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Triangle.models
{
    public class Bundle
    {
        public DataSet GetBundles()
        {
            DoosanWS.DoosanAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new DoosanWS.DoosanAPIClient();
            return betterBookSupplierClient.GetBundles();
        }


        public DataSet GetBundleDetails(int id)
        {
            //Product betterBookSupplierClient;
            //betterBookSupplierClient = new Product();
            //return betterBookSupplierClient.GetProductDetails(id);
            DoosanWS.DoosanAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new DoosanWS.DoosanAPIClient();
            return betterBookSupplierClient.GetBundleDetails(id);
        }

        public DataSet GetBundleProd(int id)
        {
            //Product betterBookSupplierClient;
            //betterBookSupplierClient = new Product();
            //return betterBookSupplierClient.GetProductDetails(id);
            DoosanWS.DoosanAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new DoosanWS.DoosanAPIClient();
            return betterBookSupplierClient.GetBundProd(id);
        }
    }
}