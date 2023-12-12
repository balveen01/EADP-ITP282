using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;
namespace Triangle.w.Admin.Finance
{
    
    public partial class PaymentArchived : System.Web.UI.Page
    {
        Payment aPay = new Payment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<Payment> payList = new List<Payment>();
            payList = aPay.getAllArchivedPayment();
            gv_payments.DataSource = payList;
            gv_payments.DataBind();
        }
    }

}