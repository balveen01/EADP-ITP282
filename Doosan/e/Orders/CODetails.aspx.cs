using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.models;
using Doosan.BLL;

namespace Doosan.e.Orders
{
    public partial class CODetails : System.Web.UI.Page
    {
        CustomerOrder cust = new CustomerOrder();
        Product prod = new Product();
        Product pro = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                // call BindGridView
                BindGridView();

                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString);
                con.Open();
                string q = "Select * from companies where company_name = 'Triangle'";


                SqlCommand query = new SqlCommand(q, con);
                SqlDataReader dr = query.ExecuteReader();
                if (dr.Read())
                {
                    lbl_name.Text = dr["company_name"].ToString();
                    lbl_email.Text = dr["company_email"].ToString();
                    lbl_addr.Text = dr["company_address"].ToString();
                    lbl_cont.Text = dr["company_contact"].ToString();
                    //lbl_TotalPrice.Text = dr["total_price"].ToString();
                }

                con.Close();


                con.Open();
                string q1 = "SELECT* FROM Delivery_Details WHERE order_id = " + id;


                SqlCommand query1 = new SqlCommand(q1, con);
                SqlDataReader dr1 = query1.ExecuteReader();
                string delivered = null;
                if (dr1.Read())
                {
                    delivered = dr1["is_delivered"].ToString();
                }

                con.Close();

                con.Open();
                string q3 = "SELECT* FROM invoices WHERE order_id = " + id;


                SqlCommand query3 = new SqlCommand(q3, con);
                SqlDataReader dr3 = query3.ExecuteReader();
                string received = null;
                if (dr3.Read())
                {
                    received = dr3["is_received"].ToString();
                }

                con.Close();

                if ((delivered == "True" && received == "True"))
                {
                    btn_update.Visible = true;
                    btn_arc.Visible = true;
                }
                else if ((delivered == "False" && received == "False") || (delivered == "True" && received == "False"))
                {
                    btn_update.Visible = false;
                    btn_arc.Visible = false;
                }


                con.Open();
                string q2 = "Select * from customer_order where order_id = " + id;
                SqlCommand query2 = new SqlCommand(q2, con);
                SqlDataReader dr2 = query2.ExecuteReader();
                decimal pricetotal = 0;
                if (dr2.Read())
                {
                    pricetotal = decimal.Parse(dr2["total_price"].ToString());
                }
                con.Close();
                lbl_TotalPrice.Text = pricetotal.ToString("#,##0");


            }
        }
        private void BindGridView()
        {
            List<Product> productlist = new List<Product>();
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            productlist = prod.getProductinfo(id);
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
            Response.Redirect("COUpdate.aspx?id=" + id);
        }

        protected void btn_arc_Click(object sender, EventArgs e)
        {
            int result = 0;
            int result1 = 0;
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            result = cust.coDelete(id);
            result1 = cust.coiDelete(id);

            if (result > 0 && result1 > 0)
            {
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Customer Order has been archived successfully');window.location ='Customer-Orders.aspx';",
                      true);
            }
            else
            {
                //lbl_result.Text = "User removal NOT successfully";
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Customer Order removal NOT successful');",
                      true);
            }
        }
        

        // Dallas
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Orders/Customer-Orders.aspx");
        }
    }
}