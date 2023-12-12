using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Triangle.models;

namespace Triangle.w.Admin.Finance
{
    public partial class PaymentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_paymentid.Text = Request.QueryString["id"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                con.Open();
                string q = "Select description, total_price, expiry_date, is_received, is_declined from [payments] where payment_id = '" + lbl_paymentid.Text + "'";

                SqlCommand query = new SqlCommand(q, con);
                SqlDataReader dr = query.ExecuteReader();

                if (dr.Read())
                {
                    tb_description.Text = dr["description"].ToString();
                    tb_totalprice.Text = dr["total_price"].ToString();
                    tb_expirydate.Text = dr["expiry_date"].ToString();
                    tb_isreceived.Text = dr["is_received"].ToString();
                    tb_isdeclined.Text = dr["is_declined"].ToString();
                }
                con.Close();
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPayment.aspx");
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            int result = 0;
            Payment pay = new Payment();


            result = pay.PaymentUpdate(lbl_paymentid.Text, tb_description.Text, decimal.Parse(tb_totalprice.Text), tb_expirydate.Text, tb_isreceived.Text, tb_isdeclined.Text);
            if (result > 0)
            {
                ScriptManager.RegisterStartupScript
                       (this, this.GetType(),
                       "alert",
                       "alert('Payment Edited!');window.location ='ViewPayment.aspx';",
                       true);
                //Response.Redirect("Staff(Admin).aspx");
            }
            else
            {
                //lbl_result.Text = "User update not successful";
                Response.Write("<script>alert('Payment update NOT successful');</script>");
            }
        }

        protected void btn_archive_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            int result = 0;
            int id = int.Parse(lbl_paymentid.Text);
            result = pay.PaymentArchive(id);

            if (result > 0)
            {
                ScriptManager.RegisterStartupScript
                    (this, this.GetType(),
                    "alert",
                    "alert('Product has been successfully archived');window.location = 'ViewPayment.aspx';",
                    true);
            }

            else
            {
                ScriptManager.RegisterStartupScript
                    (this, this.GetType(),
                    "alert",
                    "alert('Product has NOT been successfully archived');window.location = 'ViewPayment.aspx';",
                    true);
            }
        }
    }
}