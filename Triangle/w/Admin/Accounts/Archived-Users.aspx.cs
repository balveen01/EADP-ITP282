using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.BLL;
using Triangle.models;

namespace Triangle.w.Admin.Accounts
{
    public partial class Archived_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAccounts();
            }
        }

        protected void LoadAccounts()
        {
            try
            {
                AccountModel Accounts = new AccountModel();
                string query = Request.QueryString["q"].ToString();
                if (query == "a")
                {
                    ddl_Filter.SelectedValue = "admin";
                    gv_Accounts.DataSource = Accounts.GetAllArchivedUsers("admin");
                }
                else
                {
                    ddl_Filter.SelectedValue = "customer";
                    gv_Accounts.DataSource = Accounts.GetAllArchivedUsers("customer");
                }
            }
            catch
            {
                Response.Redirect("Archived-Users.aspx?q=c");
            }
            gv_Accounts.DataBind();
        }

        protected void gv_Accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect($"~/w/Admin/Accounts/Details.aspx?id={gv_Accounts.SelectedValue}");
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            AccountBLL Accounts = new AccountBLL();
            gv_Accounts.DataSource = Accounts.GetUsersBySearch(tb_Search.Text, false);
            gv_Accounts.DataBind();
        }

        protected void ddl_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Filter.SelectedValue == "customer")
            {
                Response.Redirect("Archived-Users.aspx?q=c");
            }
            else
            {
                Response.Redirect("Archived-Users.aspx?q=a");
            }

        }

        protected void gv_Accounts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Accounts.PageIndex = e.NewPageIndex;
            LoadAccounts();
        }
    }
}