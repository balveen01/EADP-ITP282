using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;

namespace Triangle.assets.mp
{
    public partial class TemplateMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["Current_User"].ToString();
            }
            catch
            {
                //BodyPlaceHolder.Visible = false;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Session Timed Out, please login again.');window.location ='/w/Sign-In.aspx';", true);
            }
            finally
            {
                if (Session["Current_User"] == null || Session["Current_User"].ToString() == "")
                {
                    lbtn_SignOut.Visible = false;
                    lbtn_SignIn.Visible = true;
                    lbtn_Cart.Visible = false;
                }
                else
                {
                    lbtn_SignOut.Visible = true;
                    lbtn_SignIn.Visible = false;
                    lbtn_Cart.Visible = true;
                }
            }
        }

        protected void lbtn_SignOut_Click(object sender, EventArgs e)
        {
            Session["Current_User"] = null;
            lbtn_SignOut.Visible = false;
            lbtn_SignIn.Visible = true;
            lbtn_Cart.Visible = false;
            ConsumerShoppingCart.Instance.Items.Clear();
            Response.Redirect("~/w/Sign-In.aspx");
        }

        protected void lbtn_SignIn_Click(object sender, EventArgs e)
        {
            lbtn_SignOut.Visible = true;
            lbtn_SignIn.Visible = false;
            Response.Redirect("~/w/Sign-In.aspx");
        }

        protected void lbtn_Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Cart.aspx");
        }
    }
}