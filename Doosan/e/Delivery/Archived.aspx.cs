using Doosan.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.e.Delivery
{
    public partial class Archived : System.Web.UI.Page
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
            gv_Delivery.DataSource = deliveries.getDeliveryFullDetailsArchived();
            gv_Delivery.DataBind();
        }

        protected void gv_Staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deliveryID = gv_Delivery.SelectedRow.Cells[0].Text;
            Response.Redirect($"~/e/Delivery/Details.aspx?id={deliveryID}");
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            gv_Delivery.DataSource = deliveries.getDeliveryArchivedBySearch(tb_Search.Text);
            gv_Delivery.DataBind();
        }
    }
}