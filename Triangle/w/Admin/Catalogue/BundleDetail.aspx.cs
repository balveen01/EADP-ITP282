using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Triangle.BLL;
using Triangle.models;

namespace Triangle.w.Admin.Catalogue
{
    public partial class BundleDetail : System.Web.UI.Page
    {
        Product aprod = new Product();
        Category cat = new Category();
        PurchaseOrder po = new PurchaseOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {


                // call BindGridView
                BindGridView();

                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                con.Open();
                string q = "Select * from suppliers where supplier_name = 'Doosan'";


                SqlCommand query = new SqlCommand(q, con);
                SqlDataReader dr = query.ExecuteReader();

                string sid = null;
                if (dr.Read())
                {
                    sid = dr["supplier_name"].ToString();
                    lbl_name.Text = dr["supplier_name"].ToString();
                    lbl_email.Text = dr["supplier_email"].ToString();
                    lbl_addr.Text = dr["supplier_address"].ToString();
                    lbl_cont.Text = dr["supplier_contact"].ToString();
                    //lbl_TotalPrice.Text = dr["total_price"].ToString();
                }
                con.Close();

                BundleCat myCat = new BundleCat();
                DataSet ds1;
                ds1 = myCat.getBundProd(Convert.ToInt32(id));
                decimal pricetotal = 0;
                pricetotal = decimal.Parse(ds1.Tables[0].Rows[0]["total_price"].ToString());
                lbl_totalPrice.Text = pricetotal.ToString("#,##0");

            }
        }

        private void BindGridView()
        {
            BundleCat myCat = new BundleCat();
            DataSet ds;
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            ds = myCat.getBundProd(id);
            gv_CartView.DataSource = ds;
            gv_CartView.DataBind();
        }

        /*  protected void btn_createco_Click(object sender, EventArgs e)
          {
              SqlConnection con4 = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
              con4.Open();
              string q4 = "Select * from suppliers where supplier_name = 'Doosan'";


              SqlCommand query4 = new SqlCommand(q4, con4);
              SqlDataReader dr4 = query4.ExecuteReader();

              int sid = 0;
              if (dr4.Read())
              {
                  sid = Convert.ToInt32(dr4["supplier_id"].ToString());
              }
              con4.Close();
              int cresult = 0;
              int poresult = 0;


              PurchaseOrder po = new PurchaseOrder();
              //decimal total_price, DateTime order_date, int supplier_id, int update_history_id, int qyt, int product_id,
              int neworderid = 0;
              int pohistory = 1;
              neworderid = po.POInsert(decimal.Parse(lbl_totalPrice.Text), sid, pohistory);
              if (neworderid > 0)
              {
                  int no = -1;
                  foreach (GridViewRow row in gv_CartView.Rows)
                  {
                      no += 1;
                      if (row.RowType == DataControlRowType.DataRow)
                      {

                          int quantity = Convert.ToInt32(gv_CartView.Rows[no].Cells[3].Text);
                          //string ID = (gv_CartView.Rows[0].FindControl("lbl_pname")).ToString();
                          ProductCat myCat = new ProductCat();
                          DataSet ds;
                          string ID = gv_CartView.Rows[no].Cells[0].Text;
                          ds = myCat.getProductDetails(Convert.ToInt32(ID));

                          string pname = ds.Tables[0].Rows[0]["product_name"].ToString();

                          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                          con.Open();
                          string q1 = "Select product_id from products where product_name = @productname";


                          SqlCommand query1 = new SqlCommand(q1, con);
                          query1.Parameters.AddWithValue("@productname", pname);
                          //query1.Parameters.AddWithValue("@id", type);
                          SqlDataReader dr1 = query1.ExecuteReader();

                          int product_ID = 0;
                          if (dr1.Read())
                          {
                              product_ID = Convert.ToInt32(dr1["product_id"].ToString());
                          }
                          con.Close();




                          //int RowNo = Convert.ToInt32(hdnValue.Value);

                          //Label lbl_pname = (Label)gv_CartView.Rows[RowNo].FindControl("lbl_pname");

                          List<Product> checkproduct = new List<Product>();
                          checkproduct = aprod.checkproduct(pname);
                          if (checkproduct.Count == 0)
                          {

                              string type = ds.Tables[0].Rows[0]["type_name"].ToString();

                              List<Category> checkcat = new List<Category>();
                              checkcat = cat.checkcat(type);

                              if (checkcat.Count == 0)
                              {
                                  string tdesc = ds.Tables[0].Rows[0]["type_desc"].ToString();
                                  int history = 1;
                                  cresult = cat.CategoryInsert(type, tdesc, history);
                                  if (cresult > 0)
                                  {
                                      Session["cinseted"] = 1;
                                  }
                                  else
                                  {
                                      Response.Write("<sript>alert('Category Insert not successful');</script>");
                                  }
                              }

                              SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                              con1.Open();
                              string q = "Select * from product_type where type_name = @id";


                              SqlCommand query = new SqlCommand(q, con1);
                              query.Parameters.AddWithValue("@id", type);
                              SqlDataReader dr = query.ExecuteReader();

                              int typeid = 0;
                              if (dr.Read())
                              {
                                  typeid = Convert.ToInt32(dr["type_id"].ToString());
                              }
                              con1.Close();


                              decimal price;
                              string desc;
                              byte[] img;
                              int rop, rop_qty;
                              price = decimal.Parse(ds.Tables[0].Rows[0]["unit_price"].ToString());
                              desc = ds.Tables[0].Rows[0]["product_desc"].ToString();
                              img = (byte[])ds.Tables[0].Rows[0]["product_image"];

                              //img = ds.Tables[0].Rows[0]["product_image"].ToString();
                              rop = 400;
                              rop_qty = 300;


                              int result = 0;
                              string image = "";
                              //if (FileUpload.HasFile == true)
                              //{
                              //image = "assets\\imag\\" + FileUpload.FileName;
                              //}
                              //  Product prod = new Product(tb_ProductID.Text, tb_ProductName.Text, tb_ProductDesc.Text, decimal.Parse(tb_UnitPrice.Text), FileUpload1.FileName, int.Parse(tb_StockLevel.Text));
                              int update_history_id = 1;

                              Product prod = new Product();


                              result = prod.ProductInsert(pname, desc, price, img, update_history_id, typeid, 0, rop, rop_qty, 1);
                              if (result > 0)
                              {
                                  //string saveimg = Server.MapPath(" ") + "\\" + image;
                                  //lbl_Result.Text = saveimg.ToString();
                                  //FileUpload.SaveAs(saveimg);
                                  Response.Write("<script language='javascript'>window.alert('Product Insert Successful');window.location='ViewBundle.aspx';</script>");
                                  // Response.Write("<sript>alert('Insert successful');</script>");
                              }

                              else
                              {
                                  Response.Write("<sript>alert('Product Insert not successful');</script>");
                              }
                          }


                          SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                          conn.Open();
                          string q2 = "Select max(order_id) max_orderid from purchase_orders";


                          SqlCommand query2 = new SqlCommand(q2, conn);
                          //query1.Parameters.AddWithValue("@id", type);
                          SqlDataReader dr2 = query2.ExecuteReader();
                          int orderid = 0;
                          if (dr2.Read())
                          {
                              orderid = Convert.ToInt32(dr2["max_orderid"].ToString());
                          }
                          conn.Close();

                          SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                          con.Open();
                          string q3 = "Select product_id from products where product_name = @productname";

                          connn.Open();
                          SqlCommand query3 = new SqlCommand(q3, connn);
                          query3.Parameters.AddWithValue("@productname", pname);
                          //query1.Parameters.AddWithValue("@id", type);
                          SqlDataReader dr3 = query3.ExecuteReader();

                          int pid = 0;
                          if (dr3.Read())
                          {
                              pid = Convert.ToInt32(dr3["product_id"].ToString());
                          }
                          connn.Close();
                          //int qty, int order_id, int product_id
                          int poiinsert = 0;
                          poiinsert = po.POIInsert(quantity, orderid, pid, "");
                          //send to product details and show them if any product or category is inserted using session
                      }
                  }
              }
              else
              {
                  Response.Write("<sript>alert('Purchase order insert not successful');</script>");

              }
              ShoppingCart.Instance.Items.Clear();
              Response.Write("<script language='javascript'>window.alert('Purchase order has been raised');window.location='ViewBundle.aspx';</script>");
              ScriptManager.RegisterStartupScript
  (this, this.GetType(),
  "alert",
  "alert('Purchase order has been raised');window.location ='\\/w/Admin/Purchase-Orders/RaisePOView.aspx';",
  true);
          }*/

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBundle.aspx");
        }

        /*protected void btn_add_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            int no = -1;
            /* foreach (GridViewRow row in gv_CartView.Rows)
             {
                 no += 1;
                 if (row.RowType == DataControlRowType.DataRow)
                 {
            //Product aProd = new Product();
            // Get Product ID from querystring

            int quantity = 1;
            BundleCat bund = new BundleCat();
            DataSet ds;
            int bid = Convert.ToInt32(Request.QueryString["id"]);
            ds = bund.getBundleDetails(Convert.ToInt32(bid));
            Bundle bunds = null;
            string ID = Request.QueryString["id"];
            //string ID = gv_CartView.Rows[no].Cells[0].Text;
            ShoppingCart.Instance.AddBundle(ID, bunds);
            ShoppingCart.Instance.SetItemQuantity(ID, quantity);
            Response.Write("<script language='javascript'>window.alert('Product added');</script>");
        }*/


        protected void btn_adda_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            int no = -1;
            foreach (GridViewRow row in gv_CartView.Rows)
            {
                no += 1;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    //Product aProd = new Product();
                    // Get Product ID from querystring
                    BundleCat bund = new BundleCat();
                    DataSet ds;
                    //the id is prod not bund
                    int bid = Convert.ToInt32(Request.QueryString["id"]);
                    ds = bund.getBundleDetails(Convert.ToInt32(bid));
                    Product bunds = null;
                    int count = gv_CartView.Rows.Count;
                    decimal totalprice = 0;
                    decimal finalprice = 0;
                    if (count == 1)
                    {
                        totalprice = decimal.Parse(lbl_totalPrice.Text);
                    }
                    if (count > 1)
                    {
                        decimal price = decimal.Parse(lbl_totalPrice.Text);
                        totalprice = price / count;
                    }
                    int quantity = Convert.ToInt32(gv_CartView.Rows[no].Cells[3].Text);

                    finalprice = totalprice / Convert.ToInt32(gv_CartView.Rows[no].Cells[3].Text);
                    string ID = gv_CartView.Rows[no].Cells[0].Text;
                    //string ID = gv_CartView.Rows[no].Cells[0].Text;
                    ShoppingCart.Instance.AddBundle(ID, bunds, finalprice);
                    ShoppingCart.Instance.SetItemQuantity(ID, quantity);
                }
            }
            Response.Write("<script language='javascript'>window.alert('Product added');</script>");
        }
    }
}