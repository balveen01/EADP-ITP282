using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle.assets.mp
{
    public partial class BCOrdersMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_CO_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Customer-Orders/View.aspx");
        }
    }
}