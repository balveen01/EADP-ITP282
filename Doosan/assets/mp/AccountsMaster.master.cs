using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.assets.mp
{
    public partial class Accounts : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Accounts_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Accounts/View.aspx");
        }

        protected void lbtn_Accounts_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Accounts/Add-Staff.aspx");
        }

        protected void lbtn_Accounts_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Accounts/View-Deactivated.aspx");
        }
    }
}