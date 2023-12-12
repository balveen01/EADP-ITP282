using Doosan.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.w.Delivery
{
    public partial class View : System.Web.UI.Page
    {
        DeliveryBLL deliveries = new DeliveryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindGridView();
            }
        }

        protected void bindGridView()
        {
            gv_Delivery.DataSource = deliveries.getDeliveryFullDetails();
            gv_Delivery.DataBind();
        }

        protected void gv_Staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deliveryID = gv_Delivery.SelectedRow.Cells[0].Text;
            Response.Redirect($"~/e/Delivery/Details.aspx?id={deliveryID}");
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            gv_Delivery.DataSource = deliveries.getDeliveryBySearch(tb_Search.Text);
            gv_Delivery.DataBind();
        }

        protected void gv_Delivery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_Delivery.PageIndex = newPageIndex;
            bindGridView();
        }
    }
}