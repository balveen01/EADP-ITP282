using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Doosan.BLL;
using Doosan.models;

namespace Doosan.e.Orders
{
    public partial class PoDetails : System.Web.UI.Page
    {
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

                CO myCat = new CO();
                DataSet ds1;
                decimal pricetotal = 0;
                ds1 = myCat.getPODetails(Convert.ToInt32(id));
                pricetotal = decimal.Parse(ds1.Tables[0].Rows[0]["total_price"].ToString());
                //dv_price.DataSource = ds1;
                //dv_price.DataBind();
                lbl_TotalPrice.Text = pricetotal.ToString();
                string approve = ds1.Tables[0].Rows[0]["is_supp_approved"].ToString();
                string declined = ds1.Tables[0].Rows[0]["is_supp_declined"].ToString();
                if (declined == "True")
                {
                    btn_createco.Visible = false;
                }
                else if (approve == "True")
                {
                    btn_createco.Visible = false;
                }

                if (approve == "True" && declined == "False")
                {
                    lbl_status.Text = "Status: Approved";
                }
                else if (approve == "False" && declined == "True")
                {
                    lbl_status.Text = "Status: Declined";
                }
                else if (approve == "False" && declined =="False")
                {
                    lbl_status.Text = "Status: Pending";
                }

                //lbl_totalPrice.Text = pricetotal.ToString("#,##0");
            }
        }

        private void BindGridView()
        {
            CO myCat = new CO();
            DataSet ds;
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            ds = myCat.ProdInfo(id);
            gv_CartView.DataSource = ds;
            gv_CartView.DataBind();
        }

        protected void btn_createco_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("Create-Customer-Order.aspx?id=" + id);
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase-Orders.aspx");
        }
    }
}