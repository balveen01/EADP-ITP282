using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.assets.mp
{
    public partial class POMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_CO_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Customer-Orders.aspx");
        }

        protected void lbtn_CO_Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Create-Customer-Order.aspx?id=0");
        }

        

        protected void lbtn_Orders_Logs_Click(object sender, EventArgs e)
        {

        }

        protected void lbtn_Orders_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/ArcCo.aspx");
        }
    }
}