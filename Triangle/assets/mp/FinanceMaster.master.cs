using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle.assets.mp
{
    public partial class FinanceMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Invoices_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Finance/Invoices.aspx");
        }

        protected void lbtn_Payments_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Finance/ViewPayment.aspx");
        }

        protected void lbtn_Payments_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Finance/PaymentArchived.aspx");
        }

        protected void lbtn_Invoice_Archived_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/w/Admin/Finance/Payments.aspx");
        }

        protected void lbtn_Payment_Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Finance/PaymentInsert.aspx");
        }
    }
}