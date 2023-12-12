using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.models;
using System.IO;

namespace Doosan.e.Catalogue
{
    public partial class Add_Bundle : System.Web.UI.Page
    {
        Product aProd = new Product();
        Product prod = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //lbl_total.Text = "$0.00";
                pnlcart.Visible = false;
                bindListBox();
                LoadCart();
            }
        }


        private void bindListBox()
        {

            ddl_name.DataSource = getReader();
            // Name will be displayed in the dropdownlist control
            ddl_name.DataTextField = "product_name";
            // when an item is selected in dropdownlist
            // CategoryID will be returned in ddlCategory.SelectedValue
            ddl_name.DataValueField = "product_id";
            ddl_name.DataBind();

        }

        private SqlDataReader getReader()
        {
            //get connection string from web.config
            string strConnectionString =
                ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT product_name, product_id  from products";

            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            // CommandBehavior.CloseConnection will automatically close connection
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //ProductCat myCat = new ProductCat();
            //DataSet ds;
            //ds = myCat.getProductDetails(Convert.ToInt32(ddl_name.Text));

            //string iProductID = prod.Product_ID.ToString();
            prod = aProd.getProduct(Convert.ToInt32(ddl_name.Text));
            int quantity = Convert.ToInt32(tb_quant.Text);
            CustOrderCart.Instance.AddItem(ddl_name.Text, prod);
            CustOrderCart.Instance.SetItemQuantity(ddl_name.Text, quantity);
            
            //Response.Write("<script language='javascript'>window.alert('Product added');</script>");
            pnlcart.Visible = true;
            LoadCart();
        }

        protected void LoadCart()
        {
            gv_CartView.DataSource = CustOrderCart.Instance.Items;
            gv_CartView.DataBind();

            decimal total = 0.00m;
            decimal totalCal = 0.00m;
            foreach (CustOrderCartItem item in CustOrderCart.Instance.Items)
            {
                total = total + item.TotalPrice;

            }

            //lbl_ShippingFee.Text = "200.00";
            //totalCal = total + 200;
            //lbl_TotalPrice.Text = totalCal.ToString();

            lbl_TotalItem.Text = total.ToString("#,##0");

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                lbl_Error.Text = "Message: Item " + e.CommandArgument.ToString() + " has been removed.";
                string productId = e.CommandArgument.ToString();
                CustOrderCart.Instance.RemoveItem(productId);
                LoadCart();
            }
            if (e.CommandName == "Plus")
            {
                lbl_Error.Text = "Message: Item " + e.CommandArgument.ToString() + " quantity added.";
                foreach (GridViewRow row in gv_CartView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        try
                        {
                            string productId = gv_CartView.DataKeys[row.RowIndex].Value.ToString();
                            int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
                            if (productId == e.CommandArgument.ToString())
                            {
                                quantity += 1;
                            }
                            CustOrderCart.Instance.SetItemQuantity(productId, quantity);

                        }
                        catch (FormatException e1)
                        {
                            lbl_Error.Text = e1.Message.ToString();
                        }
                    }
                }
                LoadCart();
                /*
                string productId = e.CommandArgument.ToString();
                ShoppingCart.Instance.AddQuantity(productId);
                LoadCart();*/
            }
            if (e.CommandName == "Minus")
            {
                lbl_Error.Text = "Message: Item " + e.CommandArgument.ToString() + " quantity reduce.";
                foreach (GridViewRow row in gv_CartView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        try
                        {
                            string productId = gv_CartView.DataKeys[row.RowIndex].Value.ToString();
                            int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
                            if (productId == e.CommandArgument.ToString())
                            {
                                quantity -= 1;
                            }
                            CustOrderCart.Instance.SetItemQuantity(productId, quantity);

                        }
                        catch (FormatException e1)
                        {
                            lbl_Error.Text = e1.Message.ToString();
                        }
                    }
                }
                LoadCart();
            }

        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            CustOrderCart.Instance.Items.Clear();
            LoadCart();
            //lbl_ShippingFee.Text = "0.00";
            lbl_TotalPrice.Text = "0.00";
            lbl_Error.Text = " cart is cleared ";

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            lbl_Error.Text = "Cart is Updated";
            foreach (GridViewRow row in gv_CartView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        string productId = gv_CartView.DataKeys[row.RowIndex].Value.ToString();
                        int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
                        CustOrderCart.Instance.SetItemQuantity(productId, quantity);

                    }
                    catch (FormatException e1)
                    {
                        lbl_Error.Text = e1.Message.ToString();
                    }
                }
            }
            LoadCart();
        }

        protected void tb_dist_TextChanged(object sender, EventArgs e)
        {
            double rate = Convert.ToDouble(tb_dist.Text) / 100;
            double discount = Convert.ToDouble(lbl_TotalItem.Text) * rate;
            double price = Convert.ToDouble(lbl_TotalItem.Text) - discount;
            //double price = Convert.ToDouble(lbl_TotalItem) - (Convert.ToDouble(lbl_TotalItem) * Convert.ToDouble(tb_dist));
            lbl_TotalPrice.Text = price.ToString("#,##0");
        }


        protected void btn_payment_Click(object sender, EventArgs e)
        {
            int result = 0;
            //int id = Convert.ToInt32(lbl_oid.ToString());
            //int id = Convert.ToInt32(Request.QueryString["id"].ToString());

            int cresult = 0;
            int poresult = 0;


            Bundle co = new Bundle();
            //decimal total_price, DateTime order_date, int supplier_id, int update_history_id, int qyt, int product_id,
            int neworderid = 0;
            int pohistory = 1;

            //CREATE CUSTOEMR ORDER
            neworderid = co.BundleInsert(tb_desc.Text, decimal.Parse(lbl_TotalPrice.Text), Convert.ToInt32(tb_dist.Text), pohistory);
            if (neworderid > 0)
            {
                int no = -1;
                foreach (GridViewRow row in gv_CartView.Rows)
                {
                    no += 1;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
                        string ID = gv_CartView.Rows[no].Cells[1].Text;

                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString);
                        conn.Open();
                        string q2 = "Select max(Bundle_id) max_bundleid from bundle";


                        SqlCommand query2 = new SqlCommand(q2, conn);
                        //query1.Parameters.AddWithValue("@id", type);
                        SqlDataReader dr2 = query2.ExecuteReader();

                        int orderid = 0;
                        if (dr2.Read())
                        {
                            orderid = Convert.ToInt32(dr2["max_bundleid"].ToString());
                        }
                        conn.Close();
                        /*
                        conn.Open();
                        string q1 = "Select product_id from products where product_name = @productname";

                        SqlCommand query1 = new SqlCommand(q1, conn);
                        query1.Parameters.AddWithValue("@productname", ID);
                        //query1.Parameters.AddWithValue("@id", type);
                        SqlDataReader dr1 = query1.ExecuteReader();

                        int product_ID = 0;
                        if (dr1.Read())
                        {
                            product_ID = Convert.ToInt32(dr1["product_id"].ToString());
                        }
                        conn.Close();
                        */
                        //CREATE CUSTOMER ORDER ITEM
                        int poiinsert = 0;
                        int id = Convert.ToInt32(gv_CartView.Rows[no].Cells[0].Text);
                        poiinsert = co.ItemInsert(quantity, orderid, id);
                    }
                }
            }
            Response.Redirect("Bundles.aspx");
        }
    }
}