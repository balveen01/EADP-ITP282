using Doosan.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.e.Delivery
{
    public partial class Timeline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CreateDeliveryTable();
            }
        }

        protected void CreateDeliveryTable()
        {
            DeliveryModel deliveryDAL = new DeliveryModel();
            DataTable ApprovalTimes = deliveryDAL.getDeliveryApprovalTimes();
            DataTable PackingTimes = deliveryDAL.getDeliveryPackedTimes();
            DataTable DeliveredTimes = deliveryDAL.getDeliveryDeliverTimes();

            var approvalRows = ApprovalTimes.AsEnumerable().Select(r => string.Format("[{0}]", string.Join(",", r.ItemArray)));
            var approvalArray = string.Format("[{0}]", string.Join(",", approvalRows.ToArray()));
            var packingRows = PackingTimes.AsEnumerable().Select(r => string.Format("[{0}]", string.Join(",", r.ItemArray)));
            var packingArray = string.Format("[{0}]", string.Join(",", packingRows.ToArray()));
            var deliveredRows = DeliveredTimes.AsEnumerable().Select(r => string.Format("[{0}]", string.Join(",", r.ItemArray)));
            var deliveredArray = string.Format("[{0}]", string.Join(",", deliveredRows.ToArray()));

            string javascriptDeliveryDataSets = "";
            javascriptDeliveryDataSets += $"let approvalArray = {approvalArray};";
            javascriptDeliveryDataSets += $"let packingArray = {packingArray};";
            javascriptDeliveryDataSets += $"let deliveredArray = {deliveredArray};";

            Response.Write($"<script>{javascriptDeliveryDataSets}</script>");
            Response.Write($"<script>let deliveriesDataSet = approvalArray.concat(packingArray, deliveredArray);</script>");

        }
    }
}