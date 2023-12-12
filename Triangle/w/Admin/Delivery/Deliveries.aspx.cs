using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.BLL;

namespace Triangle.w.Admin.Delivery
{
    public partial class Deliveries : System.Web.UI.Page
    {
        DeliveryBLL deliveryBll = new DeliveryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindGridView();
            }
        }

        protected void bindGridView()
        {
            gv_Delivery.DataSource = deliveryBll.getDeliveryFullDetailsByCompany(1);
            gv_Delivery.DataBind();
        }

        protected void gv_Staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deliveryID = gv_Delivery.SelectedRow.Cells[0].Text;
            Response.Redirect($"~/w/Admin/Delivery/View.aspx?id={deliveryID}");
        }

        protected void gv_Delivery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Delivery.PageIndex = e.NewPageIndex;
            bindGridView();
        }
    }
}