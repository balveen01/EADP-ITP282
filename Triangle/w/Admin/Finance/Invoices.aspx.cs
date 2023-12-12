using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.BLL;

namespace Triangle.w.Admin.Finance
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            DataSet ds;
            Invoicecat myList = new Invoicecat();
            ds = myList.getinvoice();
            gvInvoice.DataSource = ds;
            gvInvoice.DataBind();

            //string strConnectionString = ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;
            //SqlConnection myConnect = new SqlConnection(strConnectionString);
            //string strCommandText = "SELECT * FROM invoices";
            //SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            //myConnect.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //DataTable DT = new DataTable();
            //DT.Load(reader);
            //gvInvoice.DataSource = DT;
            //gvInvoice.DataBind();
            //myConnect.Close();
        }

        protected void gvInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedRow = gvInvoice.SelectedIndex;
            int invID = Convert.ToInt32(gvInvoice.DataKeys[selectedRow].Value);
            bindInvList();
            //GridViewRow grid = gvInvoice.SelectedRow;

            //Response.Redirect("INvoiceDetail");
        }

        private void bindInvList()
        {
            Invoicecat bll = new Invoicecat();
            DataSet dsList;
            dsList = bll.getinvoice();
            gvInvoice.DataSource = dsList;
            gvInvoice.DataBind();
        }
    }
}