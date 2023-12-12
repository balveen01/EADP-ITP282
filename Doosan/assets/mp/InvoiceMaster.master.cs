using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.assets.mp
{
    public partial class InvoiceMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Payments_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Finance/ViewPayment.aspx");
        }

        protected void lbtn_Invoices_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Finance/Invoices.aspx");
        }
    }
}