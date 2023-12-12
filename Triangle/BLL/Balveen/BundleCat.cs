using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Triangle.models;

namespace Triangle.BLL
{
    public class BundleCat
    {
        public DataSet getBundleDetails(int id)
        {
            Bundle dal;
            DataSet dataSetproductList;

            dal = new Bundle();
            dataSetproductList = dal.GetBundleDetails(id);


            return dataSetproductList;
        }

        public DataSet getBundleList()
        {
            Bundle dal;
            DataSet dataSetproductList;

            dal = new Bundle();
            dataSetproductList = dal.GetBundles();


            return dataSetproductList;
        }

        public DataSet getBundProd(int id)
        {
            Bundle dal;
            DataSet dataSetproductList;

            dal = new Bundle();
            dataSetproductList = dal.GetBundleProd(id);


            return dataSetproductList;
        }
    }
}