using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.models;

namespace Doosan.assets.mp
{
    public partial class DeliveryMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!RolesClass.checkIsAuthorised(Session["Current_User"].ToString(), "operations"))
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Not Authorised. Please contact the Admin if this was an error.');window.location ='/e/Dashboard.aspx';", true);
        }

        protected void lbtn_Delivery_Logs_Click(object sender, EventArgs e)
        {

        }

        protected void lbtn_Delivery_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Delivery/Archived.aspx");
        }

        protected void lbtn_Delivery_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Delivery/View.aspx");
        }

        protected void lbtn_Delivery_Timeline_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Delivery/Timeline.aspx");
        }
    }
}