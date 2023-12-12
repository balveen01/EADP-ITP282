using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Triangle.models;
using Triangle.BLL;

namespace Triangle.w.Admin.Purchase_Orders
{
    public partial class ApprovePO : System.Web.UI.Page
    {
        Product prod = new Product();
        PurchaseOrder po = new PurchaseOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_reason.Visible = false;
            BindGridView();



            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            lbl_rname.Visible = false;
            lbl_aname.Visible = false;
            lbl_attempt.Visible = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
            conn.Open();
            string q1 = "SELECT * from purchase_orders p where p.is_archived = 'False' and supplier_id = 1 and order_id = " + id + " order by p.order_id";


            SqlCommand query1 = new SqlCommand(q1, conn);
            SqlDataReader dr1 = query1.ExecuteReader();
            string approve = null;
            string declined = null;
            string cdeclined = null;
            string capprove = null;
            int attempt = 0;
            

            if (dr1.Read())
            {
                capprove = dr1["is_com_approved"].ToString();
                cdeclined = dr1["is_com_declined"].ToString();
                lbl_reason.Text = dr1["reason"].ToString();
                attempt = Convert.ToInt32(dr1["attempt_no"].ToString());
                //lbl_type.Text = dr1["type"].ToString();
            }
            lbl_attempt.Text = attempt.ToString();
            conn.Close();
            

            if (attempt >= 1)
            {
                lbl_rname.Visible = true;
                lbl_aname.Visible = true;
                lbl_attempt.Visible = true;
            }



            //int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
            con.Open();
            string q = "Select * from suppliers s inner join purchase_orders o on o.supplier_id = s.supplier_id where o.order_id = " + id.ToString();


            SqlCommand query = new SqlCommand(q, con);
            SqlDataReader dr = query.ExecuteReader();

            decimal pricetotal = 0;
            if (dr.Read())
            {
                lbl_name.Text = dr["supplier_name"].ToString();
                lbl_email.Text = dr["supplier_email"].ToString();
                lbl_addr.Text = dr["supplier_address"].ToString();
                lbl_cont.Text = dr["supplier_contact"].ToString();
                pricetotal = decimal.Parse(dr["total_price"].ToString());
            }
            con.Close();

            lbl_TotalPrice.Text = pricetotal.ToString("#,##0");
        }
        private void BindGridView()
        {
            List<Product> productlist = new List<Product>();
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            productlist = prod.getProductinfo(id);
            gv_CartView.DataSource = productlist;
            gv_CartView.DataBind();
        }


        protected void btn_approve_Click(object sender, EventArgs e)
        {
            int result = 0;
            //int id = Convert.ToInt32(lbl_oid.ToString());
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            result = po.pocomapprove(id);

            if (result > 0)
            {
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert(Purchase order have been approved');window.location ='ViewApprovePO.aspx';",
                      true);

                Response.Write("<script language='javascript'>window.alert('Purchase order have been approved');window.location='ViewApprovePO.aspx';</script>");
            }
            else
            {
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Purchse order not approved');window.location ='ViewApprovePO.aspx';",
                      true);
                Response.Write("<script language='javascript'>window.alert('Purchse order not approved');window.location='ViewApprovePO.aspx';</script>");
            }
        }

        protected void btn_decline_Click(object sender, EventArgs e)
        {
            pnl_reason.Visible = true;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int result = 0;
            //int id = Convert.ToInt32(lbl_oid.ToString());
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            result = po.pocomdecline(id, tb_reason.Text);

            //int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
            con.Open();
            string q = "Select * from purchase_orders where order_id = " + id.ToString();


            SqlCommand query = new SqlCommand(q, con);
            SqlDataReader dr = query.ExecuteReader();

            string total = null;
            if (dr.Read())
            {
                total = dr["attempt_no"].ToString();

            }
            con.Close();
            int attempt = Convert.ToInt32(total);
            if (attempt == 3)
            {
                int result2 = 0;
                int result1 = 0;
                //int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                result = po.poDelete(id);
                result1 = po.poiDelete(id);

                if (result2 > 0 && result1 > 0)
                {
                    ScriptManager.RegisterStartupScript
                          (this, this.GetType(),
                          "alert",
                          "alert('This purhcase order has been archived because of the number of attempts');window.location ='ViewApprovePO.aspx';",
                          true);
                }
                else
                {
                    //lbl_result.Text = "User removal NOT successfully";
                    ScriptManager.RegisterStartupScript
                          (this, this.GetType(),
                          "alert",
                          "alert('Purchase Order removal NOT successful');window.location ='ViewApprovePO.aspx';",
                          true);
                }
            }
            //need to create two new attrivtes (reason and attempt)
            //need to update reason and attempt numnber (+1)
            //rest would be at new web page

            if (result > 0)
            {
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert(Purchase order have been declined');window.location ='ViewApprovePO.aspx';",
                      true);
                Response.Write("<script language='javascript'>window.alert('Purchase order have been declined');window.location='ViewApprovePO.aspx';</script>");
            }
            else
            {
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Purchse order not declined');window.location ='ViewApprovePO.aspx';",
                      true);
                Response.Write("<script language='javascript'>window.alert('Purchase order have NOT been declined');window.location='ViewApprovePO.aspx';</script>");
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Purchase-Orders/ViewApprovePO.aspx");
        }
    }
}