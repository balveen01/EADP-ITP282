using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Doosan.TriangleWS;
using Doosan.BLL;
using System.Data;
using Doosan.models;
namespace Doosan.e.Finance
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
           
                lbl_paymentid.Text = Request.QueryString["id"].ToString();
    
            BllPayment payment = new BllPayment();
                DataSet ds = new DataSet();
                ds = payment.GetDetail(Convert.ToInt32(lbl_paymentid.Text));
 
            lbl_paymentid.Text = ds.Tables[0].Rows[0]["payment_id"].ToString();
                lbl_description.Text  = ds.Tables[0].Rows[0]["description"].ToString();
                lbl_total.Text  = ds.Tables[0].Rows[0]["total_price"].ToString();
                lbl_expiry.Text = ds.Tables[0].Rows[0]["expiry_date"].ToString();
                lbl_status.Text = ds.Tables[0].Rows[0]["is_received"].ToString();
                lbl_decline.Text = ds.Tables[0].Rows[0]["is_declined"].ToString();


        }

        protected void btn_approve_Click(object sender, EventArgs e)
        {
            BllPayment update = new BllPayment();
            int id = int.Parse(Request.QueryString["id"].ToString());
            update.updateStatus(id);

            Response.Redirect("ViewPayment.aspx");
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPayment.aspx");
           
        }

        protected void btn_decline_Click(object sender, EventArgs e)
        {
            BllPayment update = new BllPayment();
            int id = int.Parse(Request.QueryString["id"].ToString());
            update.updateStatusDecline(id);

            Response.Redirect("ViewPayment.aspx");
        }
    }
}