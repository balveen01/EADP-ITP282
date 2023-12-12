using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;

namespace Triangle.w.Admin.Purchase_Orders
{
    public partial class PoReject : System.Web.UI.Page
    {
        PurchaseOrder po = new PurchaseOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                // call BindGridView
                BindGridView();
            }
        }

        private void BindGridView()
        {
            List<PurchaseOrder> productlist = new List<PurchaseOrder>();
            productlist = po.getRPOall();
            gv_po.DataSource = productlist;
            gv_po.DataBind();
        }

        protected void gv_po_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_po.SelectedRow;

            Response.Redirect("PoDetails.aspx?id=" + gr.Cells[0].Text);
        }

        protected void gv_po_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_po.PageIndex = newPageIndex;
            BindGridView();
        }
    }
}