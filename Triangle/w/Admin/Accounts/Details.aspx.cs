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
    public partial class Details : System.Web.UI.Page
    {
        AccountBLL BLL = new AccountBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetUser();
        }

        protected void GetUser()
        {
            AccountModel Account = new AccountModel();

            string id = Request.QueryString["id"];

            Account = BLL.GetUser(id);

            lbl_StaffID.Text = id;
            tb_Username.Text = Account.Email;
            tb_Name.Text = Account.Name;
            tb_Email.Text = Account.Email;
            tb_Role.Text = Account.Role;

            if (!Account.GetArchivedStatus(id))
            {
                btn_change_to_not_archived.Visible = false;
                p_Deactivated.Visible = false;
            }
            else
            {
                btn_change_to_archived.Visible = false;
                p_Activated.Visible = false;
                
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Accounts/View.aspx");
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            int result = BLL.UpdateAccount(id, tb_Email.Text, tb_Name.Text, tb_Role.Text);
            if (result > 0)
            {
                Response.Write("<script>alert('Successfully Updated');</script>");
            }
            else
            {
                Response.Write("<script>alert('Error: Not Updated');</script>");
            }
        }

        protected void btn_change_to_archived_Click(object sender, EventArgs e)
        {
            AccountBLL BLL = new AccountBLL();
            BLL.ArchiveAccount(Request.QueryString["id"]);
            Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btn_change_to_not_archived_Click(object sender, EventArgs e)
        {
            AccountBLL BLL = new AccountBLL();
            BLL.UnarchiveAccount(Request.QueryString["id"]);
            Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}