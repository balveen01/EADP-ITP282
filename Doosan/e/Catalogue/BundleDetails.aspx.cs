using Doosan.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.e.Catalogue
{
    public partial class BundleDetails : System.Web.UI.Page
    {
        Bundle bund = new Bundle();
        Product prod = new Product();
        Product pro = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindGridView();

                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString);
                conn.Open();
                string q1 = "Select * from bundle where bundle_id = " + id;


                SqlCommand query1 = new SqlCommand(q1, conn);
                SqlDataReader dr1 = query1.ExecuteReader();

                decimal pricetotal = 0;
                if (dr1.Read())
                {
                    pricetotal= decimal.Parse(dr1["total_price"].ToString());
                    lbl_desc.Text = dr1["bundle_desc"].ToString();
                }

                conn.Close();
                lbl_TotalPrice.Text = pricetotal.ToString("#,##0");
            }
        }
        private void BindGridView()
        {
            List<Product> productlist = new List<Product>();
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            productlist = prod.getBundleinfo(id);
            gv_CartView.DataSource = productlist;
            gv_CartView.DataBind();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {



            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            int no = -1;
            foreach (GridViewRow row in gv_CartView.Rows)
            {
                no += 1;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Product aProd = new Product();
                    // Get Product ID from querystring
                    int ID = Convert.ToInt32(gv_CartView.Rows[no].Cells[0].Text);
                    int quantity = Convert.ToInt32(gv_CartView.Rows[no].Cells[3].Text);
                    prod = aProd.getProduct(ID);

                    //string ID = gv_CartView.Rows[no].Cells[0].Text;
                    string iProductID = prod.product_id.ToString();
                    CustOrderCart.Instance.AddItem(iProductID, prod);
                    CustOrderCart.Instance.SetItemQuantity(iProductID, quantity);
                }
            }
            Response.Redirect("BundleUpdate.aspx?id=" + id);
        }

        protected void btn_arc_Click(object sender, EventArgs e)
        {
            int result = 0;
            int result1 = 0;
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            result = bund.BundleDelete(id);
            result1 = bund.ItemDelete(id);

            if (result > 0 && result1 > 0)
            {
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Bundle has been archived successfully');window.location ='Bundles.aspx';",
                      true);
            }
            else
            {
                //lbl_result.Text = "User removal NOT successfully";
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Bundle removal NOT successful');",
                      true);
            }
        }
    }
}