using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.e.Finance
{
    public partial class Invoices : System.Web.UI.Page
    {
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

            string strCommandText = "SELECT invoice_id, invoiced_date, payment_type, credit_terms, total_price from invoices";


            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            gvInvoice.DataSource = dt;
            gvInvoice.DataBind();

            myConnect.Close();
        }

        protected void gvInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRow = gvInvoice.SelectedIndex; // get selected row
            //GridViewRow row = gvInvoice.Rows[selectedRow]; // get GridViewRow info of selected row
            //int selectedRowIndex = gvInvoice.SelectedIndex; // get current row selected
            //int invoice_id = Convert.ToInt32(gvInvoice.DataKeys[selectedRowIndex].Value); // get data key
            GridViewRow grid = gvInvoice.SelectedRow;

            Response.Redirect("InvoiceDetail.aspx");
        }

        protected void gvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gvInvoice.PageIndex = newPageIndex;
            BindgvInvoice();
        }

        protected void gvInvoice_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvInvoice_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        //protected void gvInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    CO myCat = new CO();
        //    DataSet DS;
        //    int no = -1;
        //    foreach(GridViewRow row in gvInvoice.Rows)
        //    {
        //        no += 1;
        //        if(row.RowType == DataControlRowType.DataRow)
        //        {
        //            DS = myCat.getPODetails(Convert.ToInt32(gvInvoice.Rows[no].Cells[0].Text));
        //            string a
        //        }
        //    }
        //}
    }
}