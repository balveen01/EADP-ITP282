using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Doosan.models;

namespace Doosan.BLL
{
    public class ProductCatalogue
    {
        public DataSet GetProductDetails(int id)
        {
            Product prod;
            prod = new Product();
            return prod.WSgetProduct(id);
        }
        public DataSet GetProducts()
        {
            Product prod;

            prod = new Product();
            return prod.WSGetAll();
        }

        public DataSet Allthree(string tid)
        {
            Product prod;

            prod = new Product();
            return prod.WSgetallthree(tid);
        }
    }
}