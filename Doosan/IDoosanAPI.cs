using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Doosan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDoosanAPI" in both code and config file together.
    [ServiceContract]
    public interface IDoosanAPI
    {
        [OperationContract]
        DataSet GetProducts();

        [OperationContract]
        DataSet GetProductDetails(int id);

        [OperationContract]
        DataSet Allthree(string tid);

        [OperationContract]
        DataSet GetBundles();

        [OperationContract]
        DataSet GetBundleDetails(int id);

        [OperationContract]
        DataSet GetBundProd(int id);

        // Deliveries
        [OperationContract]
        DataSet getDelivery(int id);

        [OperationContract]
        DataSet getDeliveryFullDetails(int id);

        [OperationContract]
        DataSet getDeliveryFullDetailsByCompany(int id);

        [OperationContract]
        int changeDeliveryStatusDelivered(string id);

        //mika's
        [OperationContract]
        DataSet Getallinvoice();
    }
}
