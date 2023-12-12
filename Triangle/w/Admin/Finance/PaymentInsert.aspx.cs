using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;
namespace Triangle.w.Admin.Finance
{
    public partial class PaymentInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_makepayment_Click(object sender, EventArgs e)
        {
            int result = 0;
            Payment pay = new Payment(tb_description.Text, decimal.Parse(tb_totalprice.Text), tb_bankname.Text, tb_banknumber.Text, tb_bankbranch.Text, tb_cardname.Text, tb_cardnumber.Text, tb_expirydate.Text, (tb_paymentdate.Text), tb_paymentmethod.Text);
            result = pay.PaymentInsert();
            if (result > 0)
            {
                Response.Write("<script language='javascript'>window.alert('Payment Successful');window.location='ViewPayment.aspx';</script>");
            }
            else
            {
                Response.Write("<sript>alert('Payment not successful');</script>");
            }
        }
    }
}