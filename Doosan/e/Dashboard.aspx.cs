using Doosan.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.w
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        protected void CreateProductCharts()
        {
            ProductsModel prod = new ProductsModel();
            DataTable SalesPerMonthDataTable = prod.GetSalesPerMonth();
            // FORMAT: YEAR, MONTH, SALES AMOUNT
            var SalesPerMonthDataTableRows = SalesPerMonthDataTable.AsEnumerable().Reverse().Take(12).Select(r => string.Format("[{0}]", string.Join(",", r.ItemArray))).Reverse();
            var SalesPerMonthDataTableArray = string.Format("[{0}]", string.Join(",", SalesPerMonthDataTableRows.ToArray()));

            DataTable topProductSalesDataSet = prod.GetProductsSortedByPurchases();
            var topProductSalesDataSetRows = topProductSalesDataSet.AsEnumerable().Take(5).Select(r => string.Format("[{0}]", string.Join(",", r.ItemArray)));
            var topProductSalesDataSetArray = string.Format("[{0}]", string.Join(",", topProductSalesDataSetRows.ToArray()));

            var bottomProductsSalesRows = topProductSalesDataSet.AsEnumerable().Reverse().Take(5).Select(r => string.Format("[{0}]", string.Join(",", r.ItemArray)));
            var bottomProductsSalesArray = string.Format("[{0}]", string.Join(",", bottomProductsSalesRows.ToArray()));


            string javascriptDataSets = "";
            javascriptDataSets += $"let productShippedDataSet = {SalesPerMonthDataTableArray};";
            javascriptDataSets += $"let topProductsSalesDataSet = {topProductSalesDataSetArray};";
            javascriptDataSets += $"let bottomProductsSalesDataSet = {bottomProductsSalesArray};";

            Response.Write($"<script>{javascriptDataSets}</script>");
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

            Response.Write($"<script>{javascriptDeliveryDataSets}let deliveriesDataSet = approvalArray.concat(packingArray, deliveredArray)</script>");
        }

        protected void LoadData()
        {
            CreateProductCharts();
            CreateDeliveryTable();
        }
    }
}