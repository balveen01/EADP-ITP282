using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Doosan.BLL;
using Doosan.models;

namespace Doosan
{
    public partial class InvoiceDetail : System.Web.UI.Page
    {
        CO co = new CO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindgvInvoice();
            }
        }

        protected void BindgvInvoice()
        {
            // get connection from web.config
            string strConnectionString = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

           
            string strCommandText = "select p.product_image, p.product_name, p.unit_price, co.order_id, co.order_date, i.total_price FROM invoices i INNER JOIN customer_order co on co.order_id = i.order_id INNER JOIN customer_order_item coi on co.order_id = coi.order_id INNER JOIN products p on coi.product_id = p.product_id";

            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            gv_InvoiceView.DataSource = dt;
            gv_InvoiceView.DataBind();

            myConnect.Close();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Invoices.aspx");
        }

        protected void btn_go2invoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvoiceSummary.aspx");
        }
    }
}