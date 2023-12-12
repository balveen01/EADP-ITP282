using Doosan.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.w.Accounts
{
    public partial class View : System.Web.UI.Page
    {
        StaffBLL staff = new StaffBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindGridView();
            }
        }

        protected void bindGridView()
        {
            gv_Staff.DataSource = staff.getAllStaff();
            gv_Staff.DataBind();
        }

        protected void gv_Staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            string staffID = gv_Staff.SelectedRow.Cells[0].Text;
            Response.Redirect($"~/e/Accounts/Staff.aspx?id={staffID}");
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            gv_Staff.DataSource = staff.getAllStaff(tb_Search.Text);
            gv_Staff.DataBind();
        }

        protected void lbtn_Operations_Click(object sender, EventArgs e)
        {
            gv_Staff.DataSource = staff.getAllStaffByDepartment("operations");
            gv_Staff.DataBind();
        }

        protected void lbtn_Delivery_Click(object sender, EventArgs e)
        {
            gv_Staff.DataSource = staff.getAllStaffByDepartment("delivery");
            gv_Staff.DataBind();
        }

        protected void lbtn_Finance_Click(object sender, EventArgs e)
        {
            gv_Staff.DataSource = staff.getAllStaffByDepartment("finance");
            gv_Staff.DataBind();
        }

        protected void gv_Staff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_Staff.PageIndex = newPageIndex;
            bindGridView();
        }
    }
}