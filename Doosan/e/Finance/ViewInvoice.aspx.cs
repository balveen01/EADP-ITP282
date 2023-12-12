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

namespace Doosan.e.Finance
{
    public partial class ViewInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindgvInvoiceList();
            }
        }

        protected void bindgvInvoiceList()
        {
            string strConnectionString = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCOmmandText = "select co.order_id, order_date, total_price, c.company_name, dd.is_delivered ";
            strCOmmandText += " FROM customer_order co";
            strCOmmandText += " INNER JOIN companies c on c.company_id = co.company_id";
            strCOmmandText += " INNER JOIN delivery_details dd on dd.order_id = co.order_id";

            SqlCommand cmd = new SqlCommand(strCOmmandText, myConnect);
            myConnect.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            gv_InvoiceList.DataSource = dt;
            gv_InvoiceList.DataBind();
            myConnect.Close();
        }

        protected void gv_InvoiceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_InvoiceList.PageIndex = newPageIndex;
            bindgvInvoiceList();
        }

        protected void gv_InvoiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_InvoiceList.SelectedRow;
            string coDI = row.Cells[0].Text; // ?id=" + row.Cells[0].Text
            Response.Redirect("CreateInvoice1.aspx?id=" + coDI);
        }
    }
}