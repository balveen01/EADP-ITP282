using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;

namespace Triangle.w.Admin.Customer_Orders
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }

        protected void bind()
        {
            BCOrders orderModel = new BCOrders();
            gv_CO.DataSource = orderModel.GetAllBCOrders();
            gv_CO.DataBind();
        }

        protected void gv_CO_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_CO.SelectedRow;

            Response.Redirect("CO_Details.aspx?id=" + gr.Cells[0].Text);
        }

        protected void gv_CO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_CO.PageIndex = newPageIndex;
            bind();
        }
    }
}