using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.assets.mp
{
    public partial class POrdersMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_PO_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Purchase-Orders.aspx");
        }

        protected void lbtn_PO_Approved_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Approve-PO.aspx");
        }
        protected void lbtn_PO_Pending_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Pending-PO.aspx");
        }

        protected void lbtn_Orders_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Declined-PO.aspx");
        }

        protected void lbtn_Orders_Logs_Click(object sender, EventArgs e)
        {

        }
    }
}