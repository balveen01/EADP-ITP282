using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triangle.models;
using System.Data;

namespace Triangle.BLL
{
    public class ProductCat
    {

        public DataSet getProductDetails(int id)
        {
            Product dal;
            DataSet dataSetproductList;

            dal = new Product();
            dataSetproductList = dal.GetProductDetails(id);


            return dataSetproductList;
        }

        public DataSet getProductList()
        {
            Product dal;
            DataSet dataSetproductList;

            dal = new Product();
            dataSetproductList = dal.GetProducts();


            return dataSetproductList;
        }

        public DataSet GetPOProducts(int id)
        {
            Product prod;

            prod = new Product();
            return prod.WsGetPOProd(id);
        }

        public DataSet allthree(string id)
        {
            Product prod;

            prod = new Product();
            return prod.Alltheree(id);
        }
    }
}