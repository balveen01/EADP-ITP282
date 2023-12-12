using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triangle.models;
using Triangle.BLL;
using System.Data;

namespace Triangle.BLL
{
    public class PO
    {
        public DataSet GetPODetails(int id)
        {
            PurchaseOrder po;
            po = new PurchaseOrder();
            return po.WSgetPO(id);
        }

        public DataSet SuppApprove(int id)
        {
            PurchaseOrder po;
            po = new PurchaseOrder();
            return po.WsSuppapprove(id);
        }
        public DataSet SuppDeclined(int id)
        {
            PurchaseOrder po;
            po = new PurchaseOrder();
            return po.WsSuppdeclined(id);
        }

        public DataSet GetPO()
        {
            PurchaseOrder po;

            po = new PurchaseOrder();
            return po.WSGetAllPO();
        }

        public DataSet GetAppPO()
        {
            PurchaseOrder po;

            po = new PurchaseOrder();
            return po.WSGetAppPO();
        }
        public DataSet GetPendPO()
        {
            PurchaseOrder po;

            po = new PurchaseOrder();
            return po.WSGetPendPO();
        }

        public DataSet GetDeclinedPO()
        {
            PurchaseOrder po;

            po = new PurchaseOrder();
            return po.WSGetDecPO();
        }
    }
}