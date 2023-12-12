using Doosan.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Doosan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DoosanAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DoosanAPI.svc or DoosanAPI.svc.cs at the Solution Explorer and start debugging.
    public class DoosanAPI : IDoosanAPI
    {
        public DataSet GetProducts()
        {
            ProductCatalogue bizLayerBooks = new ProductCatalogue();
            return bizLayerBooks.GetProducts();
        }
        public DataSet GetProductDetails(int id)
        {
            ProductCatalogue bizlayerBooks = new ProductCatalogue();
            return bizlayerBooks.GetProductDetails(id);
        }

        public DataSet Allthree(string tid)
        {
            ProductCatalogue bizlayerbooks = new ProductCatalogue();
            return bizlayerbooks.Allthree(tid);
        }

        public DataSet GetBundles()
        {
            BundleCat bizLayerBooks = new BundleCat();
            return bizLayerBooks.GetBundles();
        }
        public DataSet GetBundleDetails(int id)
        {
            BundleCat bizlayerBooks = new BundleCat();
            return bizlayerBooks.GetBundleDetails(id);
        }

        public DataSet GetBundProd(int id)
        {
            BundleCat bizlayerBooks = new BundleCat();
            return bizlayerBooks.GetBundProd(id);
        }


        // Delivery
        public DataSet getDelivery(int id)
        {
            DeliveryBLL deliveryModel = new DeliveryBLL();
            return deliveryModel.getDelivery(id);
        }

        public DataSet getDeliveryFullDetails(int id)
        {
            DeliveryBLL deliveryModel = new DeliveryBLL();
            return deliveryModel.getDeliveryFullDetails(id);
        }

        public DataSet getDeliveryFullDetailsByCompany(int id)
        {
            DeliveryBLL deliveryModel = new DeliveryBLL();
            return deliveryModel.getDeliveryFullDetailsByCompany(id);
        }

        public int changeDeliveryStatusDelivered(string id)
        {
            DeliveryBLL deliveryModel = new DeliveryBLL();
            return deliveryModel.changeDeliveryStatusDelivered(id);
        }
        
        // mika's 
        public DataSet Getallinvoice()
        {
            InvoiceCatalogue invoice = new InvoiceCatalogue();
            return invoice.GetInvoices();
        }
    }
}
