using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Triangle
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITriangleAPI" in both code and config file together.
    [ServiceContract]
    public interface ITriangleAPI
    {
        [OperationContract]
        DataSet GetPO();

        [OperationContract]
        DataSet GetAppPO();

        [OperationContract]
        DataSet GetDecPO();

        [OperationContract]
        DataSet GetPendPO();

        [OperationContract]
        DataSet GetPODetails(int id);

        [OperationContract]
        DataSet SuppApprove(int id);

        [OperationContract]
        DataSet SuppDeclined(int id);

        [OperationContract]
        DataSet GetPOProducts(int id);

        [OperationContract]
        DataSet GetPayment();

        [OperationContract]
        DataSet GetDetails(int id);

        [OperationContract]
        void updateStatus(int id);

        [OperationContract]
        void updateStatusDecline(int id);

        [OperationContract]
        DataSet Getallinvoice();
    }
}
