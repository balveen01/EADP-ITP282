using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle.assets.mp._settings
{
    public partial class Navigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_name.Text = Session["Current_User"].ToString();
            }
            catch
            {
                lbl_name.Text = "Admin";
            }
        }

        protected void lbtn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Dashboard.aspx");
        }

        protected void lbtn_Accounts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Accounts/View.aspx");
        }

        protected void lbtn_BCOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Customer-Orders/View.aspx");
        }

        protected void lbtn_POrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Purchase-Orders/View.aspx");
        }

        protected void lbtn_Finance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Finance/Invoices.aspx");
        }

        protected void lbtn_Catalogue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/Products.aspx");
        }

        protected void lbtn_LogOut_Click(object sender, EventArgs e)
        {
            Session["Current_User"] = "";
            Response.Redirect("~/w/Sign-In.aspx");
        }
    }
}