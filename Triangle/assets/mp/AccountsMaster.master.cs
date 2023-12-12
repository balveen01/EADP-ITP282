using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle.assets.mp
{
    public partial class AccountsMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Accounts_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Accounts/View.aspx");
        }

        protected void lbtn_Accounts_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Accounts/Add-User.aspx");
        }

        protected void lbtn_Accounts_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Accounts/Archived-Users.aspx");
        }

        protected void lbtn_Accounts_Logs_Click(object sender, EventArgs e)
        {

        }
    }
}