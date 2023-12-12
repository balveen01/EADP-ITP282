using Doosan.BLL;
using Doosan.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.e.Accounts
{
    public partial class Staff : System.Web.UI.Page
    {
        StaffBLL staff = new StaffBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindStaff();
            }
        }

        protected void bindStaff()
        {
            StaffModel staff = new StaffModel();

            string staffID = Request.QueryString["id"].ToString();
            lbl_StaffID.Text = staffID;


            staff.getStaff(staffID);
            tb_Username.Text = staff.Username;
            tb_Name.Text = staff.Name;
            tb_Email.Text = staff.Email;
            ddl_Dept.SelectedItem.Text = staff.Department;

            if (staff.checkIsActivated(staffID))
            {
                btn_Activate.Visible = false;
            }
            else
            {
                btn_Deactivate.Visible = false;
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Accounts/View.aspx");
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string staffID = Request.QueryString["id"].ToString();

            int result = staff.updateStaff(staffID, tb_Name.Text, ddl_Dept.SelectedItem.Text);
            if (result > 0)
            {
                Response.Write("<script>alert('Staff successfully updated.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Error: Something went wrong.');</script>");
            }
        }

        protected void btn_Deactivate_Click(object sender, EventArgs e)
        {
            string staffID = Request.QueryString["id"].ToString();
            staff.deactivateStaff(staffID);
            Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btn_Activate_Click(object sender, EventArgs e)
        {
            string staffID = Request.QueryString["id"].ToString();
            staff.reactivateStaff(staffID);
            Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}