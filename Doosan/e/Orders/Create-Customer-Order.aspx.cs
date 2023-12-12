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

namespace Doosan.w.Orders
{
    public partial class Create_Customer_Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                if (Convert.ToInt32(Request.QueryString["id"].ToString()) == 0)
                {
                    CO co = new CO();
                    DataSet ds1;
                    ds1 = co.getPendPOList();
                    gv_po.DataSource = ds1.Tables[0].DefaultView;
                    gv_po.DataBind();
                    btn_back.Visible = false;
                    btn_co.Visible = false;
                    btn_decline.Visible = false;
                    gv_CartView.Visible = false;
                    supplierdetails.Visible = false;
                    div_order_total.Visible = false;
                }
                else
                {
                    // call BindGridView
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    CO myCat = new CO();
                    DataSet ds;
                    ds = myCat.getPODetails(Convert.ToInt32(id));
                    decimal pricetotal = 0;
                    pricetotal = decimal.Parse(ds.Tables[0].Rows[0]["total_price"].ToString());
                    lbl_TotalPrice.Text = pricetotal.ToString("#,##0");
                    BindGridView();




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
                    gv_po.Visible = false;
                }

            }
        }

        protected void gv_po_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_po.PageIndex = newPageIndex;
            BindGridView();
        }
        protected void gv_po_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_po.SelectedRow;

            Response.Redirect("Create-Customer-Order.aspx?id=" + gr.Cells[0].Text);
        }



        protected void gv_po_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow gr = gv_po.SelectedRow;

            Response.Redirect("PoDetail.aspx?id=" + gv_po.DataKeys[e.RowIndex].Value);
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

        protected void btn_co_Click(object sender, EventArgs e)
        {
            int result = 0;
            int orderid = 0;
            //int id = Convert.ToInt32(lbl_oid.ToString());
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            CO myCat = new CO();
            DataSet ds;
            ds = myCat.SuppApprove(id);

            int cresult = 0;
            int poresult = 0;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString);
            con.Open();
            string q = "Select * from companies where company_name = 'Triangle'";


            SqlCommand query = new SqlCommand(q, con);
            SqlDataReader dr = query.ExecuteReader();
            int cid = 0;
            if (dr.Read())
            {
                cid = Convert.ToInt32(dr["company_id"].ToString()); ;
            }

            con.Close();
            CustomerOrder co = new CustomerOrder();
            //decimal total_price, DateTime order_date, int supplier_id, int update_history_id, int qyt, int product_id,
            int neworderid = 0;
            int pohistory = 1;
            //CREATE CUSTOEMR ORDER
            int poid = Convert.ToInt32(Request.QueryString["id"].ToString());
            neworderid = co.COInsert(decimal.Parse(lbl_TotalPrice.Text), cid, pohistory, true, poid);
            if (neworderid > 0)
            {
                int no = -1;
                foreach (GridViewRow row in gv_CartView.Rows)
                {
                    no += 1;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        int quantity = Convert.ToInt32(gv_CartView.Rows[no].Cells[3].Text);
                        string ID = gv_CartView.Rows[no].Cells[1].Text;

                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString);
                        conn.Open();
                        string q2 = "Select max(order_id) max_orderid from customer_order";


                        SqlCommand query2 = new SqlCommand(q2, conn);
                        //query1.Parameters.AddWithValue("@id", type);
                        SqlDataReader dr2 = query2.ExecuteReader();

                        
                        if (dr2.Read())
                        {
                            orderid = Convert.ToInt32(dr2["max_orderid"].ToString());
                        }


                        con.Open();
                        string q1 = "Select product_id from products where product_name = @productname";

                        SqlCommand query1 = new SqlCommand(q1, con);
                        query1.Parameters.AddWithValue("@productname", ID);
                        //query1.Parameters.AddWithValue("@id", type);
                        SqlDataReader dr1 = query1.ExecuteReader();

                        int product_ID = 0;
                        if (dr1.Read())
                        {
                            product_ID = Convert.ToInt32(dr1["product_id"].ToString());
                        }
                        con.Close();

                        conn.Close();
                        //CREATE CUSTOMER ORDER ITEM
                        int poiinsert = 0;
                        poiinsert = co.COIInsert(quantity, orderid, product_ID);
                    }
                }
            }

            // Dallas
            DeliveryModel.createDelivery(lbl_addr.Text, orderid.ToString());

            Response.Redirect("Approve-PO.aspx");
        }
        protected void btn_declined_Click(object sender, EventArgs e)
        {
            int result = 0;
            //int id = Convert.ToInt32(lbl_oid.ToString());
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            CO myCat = new CO();
            DataSet ds;
            ds = myCat.SuppDeclined(id);

            ScriptManager.RegisterStartupScript
      (this, this.GetType(),
      "alert",
      "alert('Purchase order has been declined');window.location ='Declined-PO.aspx';",
      true);
            Response.Write("<script language='javascript'>window.alert('Customer order has been declined');window.location='Declined-PO.aspx';</script>");
            //Response.Redirect("Declined-PO.aspx");
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase-Orders.aspx");
        }
        protected void gv_po_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CO myCat = new CO();
            DataSet ds1;
            //ds1 = myCat.getPOList();
            //string approve = ds1.Tables[0].Rows[0]["is_supp_approved"].ToString();
            //string declined = ds1.Tables[0].Rows[0]["is_supp_declined"].ToString();
            int no = -1;
            foreach (GridViewRow row in gv_po.Rows)
            {
                no += 1;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    ds1 = myCat.getPODetails(Convert.ToInt32(gv_po.Rows[no].Cells[0].Text));
                    string approve = ds1.Tables[0].Rows[0]["is_supp_approved"].ToString();
                    string declined = ds1.Tables[0].Rows[0]["is_supp_declined"].ToString();
                    if (approve == "True" && declined == "False")
                    {
                        gv_po.Rows[no].Cells[3].Text = "Approved";
                    }
                    else if (approve == "False" && declined == "True")
                    {
                        gv_po.Rows[no].Cells[3].Text = "Declined";
                    }
                    else if (approve == "False" && declined == "False")
                    {
                        gv_po.Rows[no].Cells[3].Text = "Pending";
                    }
                }
            }

        }
    }


}