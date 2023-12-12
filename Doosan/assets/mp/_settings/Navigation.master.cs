using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.models;

namespace Doosan.assets.mp
{
    public partial class Navigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string department = RolesClass.getDepartment(Session["Current_User"].ToString());

                if (department != "")
                {
                    lbl_name.Text = Session["Current_User"].ToString();
                }

                if (department == "operations")
                {
                    lbl_department.Text = "Operations";
                    list_Accounts.Visible = false;
                    list_Finance.Visible = false;
                }
                else if (department == "finance")
                {
                    lbl_department.Text = "Finance";
                    list_Accounts.Visible = false;
                    list_Delivery.Visible = false;
                    list_Category.Visible = false;
                }
                else
                {
                    lbl_name.Text = "Master";
                    lbl_department.Text = "Admin";
                    //list_Accounts.Visible = false;
                    //list_Delivery.Visible = false;
                    //list_Category.Visible = false;
                    //list_Finance.Visible = false;
                    //list_Company.Visible = false;
                    //list_Orders.Visible = false;
                }
            }
            catch
            {

            }


        }

        protected void lbtn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Dashboard.aspx");
        }


        protected void lbtn_Accounts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Accounts/View.aspx");
        }

        protected void lbtn_PO_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Purchase-Orders.aspx");
        }

        protected void lbtn_CO_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Customer-Orders.aspx");
        }

        protected void lbtn_Delivery_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Delivery/View.aspx");
        }

        protected void lbtn_Catalogue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/Products.aspx");
        }

        protected void lbtn_Finance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Finance/Invoices.aspx");
        }

        protected void lbtn_Company_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Company/Dashboard.aspx");
        }

        protected void lbtn_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}