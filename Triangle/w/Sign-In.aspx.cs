using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle.w
{
    public partial class Sign_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Session["Current_User"] = tb_Username.Text;
            if (tb_Username.Text == "admin")
            {
                Response.Redirect("~/w/Admin/Dashboard.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}