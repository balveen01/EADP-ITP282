using Doosan.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.w.Accounts
{
    public partial class Add_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void clearInputs()
        {
            lbl_Username.Text = lbl_Name.Text = lbl_Email.Text = lbl_Dept.Text = "";
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            StaffBLL staff = new StaffBLL();

            int result = staff.createStaff(tb_Username.Text, tb_Email.Text, tb_Name.Text, ddl_Dept.SelectedItem.Text);

            if (result > 0)
            {
                clearInputs();
            }
            else
            {
                Response.Write("<script>alert('Error: Something went wrong.');</script>");
            }
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_Username.Text = tb_Name.Text = tb_Email.Text = ddl_Dept.SelectedValue = "";
        }
    }
}