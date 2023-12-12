using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Doosan.models;

namespace Doosan.BLL
{
    public class BundleCat
    {
        public DataSet GetBundleDetails(int id)
        {
            Bundle prod;
            prod = new Bundle();
            return prod.WSgetBundle(id);
        }
        public DataSet GetBundles()
        {
            Bundle prod;

            prod = new Bundle();
            return prod.WSGetAllBundle();
        }

        public DataSet GetBundProd(int id)
        {
            Product prod;

            prod = new Product();
            return prod.WsGetBundProd(id);
        }

    }
}