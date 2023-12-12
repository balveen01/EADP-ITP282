using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Triangle.BLL;

namespace Triangle
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TriangleAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TriangleAPI.svc or TriangleAPI.svc.cs at the Solution Explorer and start debugging.
    public class TriangleAPI : ITriangleAPI
    {
        public DataSet GetPO()
        {
            PO bizLayerBooks = new PO();
            return bizLayerBooks.GetPO();
        }

        public DataSet GetAppPO()
        {
            PO bizLayerBooks = new PO();
            return bizLayerBooks.GetAppPO();
        }
        public DataSet GetDecPO()
        {
            PO bizLayerBooks = new PO();
            return bizLayerBooks.GetDeclinedPO();
        }
        public DataSet GetPendPO()
        {
            PO bizLayerBooks = new PO();
            return bizLayerBooks.GetPendPO();
        }
        public DataSet GetPODetails(int id)
        {
            PO bizlayerBooks = new PO();
            return bizlayerBooks.GetPODetails(id);
        }
        public DataSet SuppApprove(int id)
        {
            PO bizlayerBooks = new PO();
            return bizlayerBooks.SuppApprove(id);
        }

        public DataSet SuppDeclined(int id)
        {
            PO bizlayerBooks = new PO();
            return bizlayerBooks.SuppDeclined(id);
        }

        public DataSet GetPOProducts(int id)
        {
            ProductCat bizlayerBooks = new ProductCat();
            return bizlayerBooks.GetPOProducts(id);
        }

        public DataSet GetPayment()
        {
            BllPayment bizLayerPayments = new BllPayment();
            return bizLayerPayments.GetPayment();
        }

        public DataSet GetDetails(int id)
        {
            BllPayment bizLayerPayments = new BllPayment();
            return bizLayerPayments.GetDetails(id);
        }

        public void updateStatus(int id)

        {
            BllPayment bizLayerPayments = new BllPayment();
            bizLayerPayments.updateStatus(id);
        }

        public void updateStatusDecline(int id)

        {
            BllPayment bizLayerPayments = new BllPayment();
            bizLayerPayments.updateStatusDecline(id);
        }

        //mika
        public DataSet Getallinvoice()
        {
            Invoicecat bizLayerInvoice = new Invoicecat();
            return bizLayerInvoice.getinvoice();
        }
    }
}