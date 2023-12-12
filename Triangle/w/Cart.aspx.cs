using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;

namespace Triangle.w
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCart();
            }
        }

        protected void LoadCart()
        {
            gvCart.DataSource = ConsumerShoppingCart.Instance.Items;
            gvCart.DataBind();

            decimal total = 0.0m;
            foreach (ConsumerShoppingCartItems item in ConsumerShoppingCart.Instance.Items)
            {
                total = total + item.Price;
            }
            lbl_TotalPrice.Text = total.ToString();
        }

        protected void btn_Purchase_Click(object sender, EventArgs e)
        {
            int no = -1;
            try
            {
                foreach (GridViewRow row in gvCart.Rows)
                {
                    no += 1;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        //FINDING INFORMATION ABOUT THE PRODUCT
                        string ID = gvCart.Rows[no].Cells[0].Text;
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                        con.Open();
                        string q = "Select * from products where product_id = '" + ID + "'";


                        SqlCommand query = new SqlCommand(q, con);
                        SqlDataReader dr = query.ExecuteReader();

                        int stock_level = 0;
                        int rop = 0;
                        int rop_qty = 0;
                        decimal unitprice = 0;
                        bool check = false;
                        if (dr.Read())
                        {
                            stock_level = Convert.ToInt32(dr["stock_level"].ToString());
                            rop = Convert.ToInt32(dr["rop"].ToString());
                            rop_qty = Convert.ToInt32(dr["rop_qty"].ToString());
                            unitprice = Convert.ToDecimal(dr["unit_price"].ToString());
                            check = bool.Parse(dr["is_reordering"].ToString());

                        }
                        con.Close();

                        //TAKE OUT THE QUANTITY HERE 
                        int quantity = Convert.ToInt32(gvCart.Rows[no].Cells[3].Text);

                        //MINUS THE STOCK LEVEL AND ADD INTO THE DATABASE AGAIN
                        int checkstock = stock_level - quantity;

                        if (checkstock == 0)//UPDATE STOCK LEVEL AND MAKE IS AVALIBLE FALSE - SINCE NO STOCK
                        {

                            string queryStr = "UPDATE products SET " + "stock_level = @stock_level, " + "is_available = 0 WHERE product_id = @product_id";


                            SqlCommand cmd = new SqlCommand(queryStr, con);
                            cmd.Parameters.AddWithValue("@stock_level", checkstock);
                            cmd.Parameters.AddWithValue("@product_id", ID);

                            con.Open();
                            int nofRow = 0;
                            nofRow = cmd.ExecuteNonQuery();

                            con.Close();
                        }
                        if (checkstock > 0) //UPDATE STOCK LEVEL ONLY SINCE THERE IS STOCK
                        {
                            string queryStr = "UPDATE products SET " + "stock_level = @stock_level WHERE product_id = @product_id";


                            SqlCommand cmd = new SqlCommand(queryStr, con);
                            cmd.Parameters.AddWithValue("@stock_level", checkstock);
                            cmd.Parameters.AddWithValue("@product_id", ID);

                            con.Open();
                            int nofRow = 0;
                            nofRow = cmd.ExecuteNonQuery();

                            con.Close();
                        }

                        if (checkstock < rop && check == false) //IF STOCK IS LESSER THAN ROP THEN CREATE PO AND POI
                        {
                            PurchaseOrder po = new PurchaseOrder();
                            int neworderid = 0;
                            int pohistory = 1;
                            decimal totalprice = unitprice * rop_qty;
                            int supplier = 1;
                            neworderid = po.POInsert(totalprice, supplier, pohistory);
                            if (neworderid > 0)
                            {
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
                                int poiinsert = 0;
                                poiinsert = po.POIInsert(rop_qty, orderid, Convert.ToInt32(ID), "auto");

                                //UPDATE REORDERING AS TRUE SINCE IT IS ORDERING
                                string queryStr = "UPDATE products SET is_reordering = 1 WHERE product_id = @product_id";


                                SqlCommand cmd = new SqlCommand(queryStr, con);
                                cmd.Parameters.AddWithValue("@product_id", ID);

                                con.Open();
                                int nofRow = 0;
                                nofRow = cmd.ExecuteNonQuery();

                                con.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;
            int newOrderId = 0;
            // create order header
            SqlConnection conn2 = SQLConnTriangle.GetConnection();
            sql = new StringBuilder();
            sql.AppendLine("insert into business_orders (total_price)");
            sql.AppendLine("VALUES (@total_price)");
            sql.AppendLine("SELECT CAST(scope_identity() AS int)");
            sql.AppendLine(" ");
            sqlCmd = new SqlCommand(sql.ToString(), conn2);
            sqlCmd.Parameters.AddWithValue("@total_price", Convert.ToDecimal(lbl_TotalPrice.Text));
            try
            {
                conn2.Open();
                newOrderId = (Int32)sqlCmd.ExecuteScalar();  // ExecuteScalar return 1st column of the record

                StringBuilder sqlItem;
                int rowNo = 0;
                foreach (GridViewRow row in gvCart.Rows)
                {

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        int prodID = Convert.ToInt32(gvCart.Rows[rowNo].Cells[0].Text);
                        int quantity = Convert.ToInt32(gvCart.Rows[rowNo].Cells[3].Text);


                        sqlItem = new StringBuilder();
                        sqlItem.AppendLine("insert into business_order_Item (quantity, order_id, product_id)");
                        sqlItem.AppendLine("VALUES (@quantity, @order_id, @product_id)");
                        sqlItem.AppendLine(" ");
                        sqlCmd = new SqlCommand(sqlItem.ToString(), conn2);
                        sqlCmd.Parameters.AddWithValue("@quantity", quantity);
                        sqlCmd.Parameters.AddWithValue("@order_id", newOrderId);
                        sqlCmd.Parameters.AddWithValue("@product_id", prodID);
                        result = sqlCmd.ExecuteNonQuery();  // ExecuteNonQuery return number of rows affected
                    }
                    rowNo += 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            finally
            {
                conn2.Close();
                ConsumerShoppingCart.Instance.Items.Clear();
                LoadCart();
                Response.Write("<script>alert('Thank you for purchasing!')</script>");
            }
        }
    }
}