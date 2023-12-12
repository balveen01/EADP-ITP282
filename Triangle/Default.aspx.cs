using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle
{
    public partial class Default : System.Web.UI.Page
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
                    NotSignedInContainer.Visible = true;
                    SignedInContainer.Visible = false;
                }
                else
                {
                    NotSignedInContainer.Visible = false;
                    SignedInContainer.Visible = true;
                }
            }
        }
    }
}