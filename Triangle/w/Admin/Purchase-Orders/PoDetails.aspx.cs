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
    public partial class PoDetails : System.Web.UI.Page
    {
        Product prod = new Product();
        PurchaseOrder po = new PurchaseOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                lbl_rname.Visible = false;
                lbl_aname.Visible = false;
                lbl_attempt.Visible = false;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                conn.Open();
                string q1 = "SELECT * from purchase_orders p where p.is_archived = 'False' and supplier_id = 1 and order_id = " + id ;


                SqlCommand query1 = new SqlCommand(q1, conn);
                SqlDataReader dr1 = query1.ExecuteReader();
                string approve = null;
                string declined = null;
                string cdeclined = null;
                string capprove = null;
                string type = null;

                if (dr1.Read())
                {
                    capprove = dr1["is_com_approved"].ToString();
                    cdeclined = dr1["is_com_declined"].ToString();
                    lbl_reason.Text = dr1["reason"].ToString();
                    lbl_attempt.Text = dr1["attempt_no"].ToString();
                    //type = dr1["type"].ToString();
                }
                conn.Close();

                if (capprove == "True")
                {
                    btn_update.Visible = false;
                    btn_arc.Visible = false;
                    lbl_rname.Visible = false;
                    lbl_aname.Visible = false;
                    lbl_attempt.Visible = false;
                }

                else if (capprove == "False" || cdeclined == "True")//not approved or declined 
                {
                    btn_update.Visible = true;
                    btn_arc.Visible = true;
                }
                if (cdeclined == "True")
                {
                    lbl_rname.Visible = true;
                    lbl_aname.Visible = true;
                    lbl_attempt.Visible = true;
                }
                if (type == "bundle")
                {
                    btn_update.Visible = false;
                }

                // call BindGridView
                BindGridView();


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
            int bno = -1;
            int bundlerow = 0;
            decimal bundleprice = 0;
            foreach (GridViewRow row in gv_CartView.Rows)
            {
                bno += 1;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string wtype = gv_CartView.Rows[bno].Cells[1].Text;
                    string strContent = gv_CartView.Rows[bno].Cells[5].Text;
                    strContent = strContent.Replace("$", string.Empty);
                    strContent = strContent.Replace(",", string.Empty);
                    decimal bundle = decimal.Parse(strContent);
                    if (wtype == "bundle")
                    {
                        bundleprice += bundle;
                        bundlerow += 1;
                    }
                }
            }

            foreach (GridViewRow row in gv_CartView.Rows)
            {
                no += 1;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string wtype = gv_CartView.Rows[no].Cells[1].Text;
                    if (wtype == "product" || wtype=="auto")
                    {
                        //Product aProd = new Product();
                        // Get Product ID from querystring
                        int ID = Convert.ToInt32(gv_CartView.Rows[no].Cells[0].Text);
                        int quantity = Convert.ToInt32(gv_CartView.Rows[no].Cells[4].Text);
                        prod = prod.getProduct(ID);

                        //string ID = gv_CartView.Rows[no].Cells[0].Text;
                        string iProductID = prod.product_id.ToString();
                        POCart.Instance.AddItem(iProductID, prod);
                        POCart.Instance.SetItemQuantity(iProductID, quantity);
                    }
                    if (wtype == "bundle")
                    {
                        int ID = Convert.ToInt32(gv_CartView.Rows[no].Cells[0].Text);
                        int quantity = Convert.ToInt32(gv_CartView.Rows[no].Cells[4].Text);
                        prod = prod.getProduct(ID);
                        /*BundleCat bund = new BundleCat();
                        DataSet ds;
                        int bid = Convert.ToInt32(Request.QueryString["id"]);
                        ds = bund.getBundleDetails(Convert.ToInt32(bid));*/
                        decimal totalprice = 0;
                        if (bundlerow == 1)
                        {
                            totalprice = bundleprice;
                        }
                        if (bundlerow > 1)
                        {
                            totalprice = bundleprice / bundlerow;
                        }
                        int bunquantity = Convert.ToInt32(gv_CartView.Rows[no].Cells[4].Text);
                        decimal finalprice = 0;
                        finalprice = totalprice / Convert.ToInt32(gv_CartView.Rows[no].Cells[4].Text);
                        //string ID = gv_CartView.Rows[no].Cells[0].Text;
                        string iProductID = prod.product_id.ToString();
                        POCart.Instance.AddBundle(iProductID, prod, finalprice);
                        POCart.Instance.SetItemQuantity(iProductID, quantity);
                    }
                }
            }
            Response.Redirect("PoUpdate.aspx?id=" + id);
        }

        protected void btn_arc_Click(object sender, EventArgs e)
        {
            int result = 0;
            int result1 = 0;
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            result = po.poDelete(id);
            result1 = po.poiDelete(id);

            if (result > 0 && result1 > 0)
            {
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Purchase Order has been archived successfully');window.location ='View.aspx';",
                      true);
            }
            else
            {
                //lbl_result.Text = "User removal NOT successfully";
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Purchase Order removal NOT successful');window.location ='View.aspx';",
                      true);
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("View.aspx");
        }
    }
}