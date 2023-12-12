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
    public partial class RaisePO : System.Web.UI.Page
    {
        Product aprod = new Product();
        Category cat = new Category();
        PurchaseOrder po = new PurchaseOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                LoadCart();
                if (gv_CartView.Rows.Count == 0)
                {
                    btn_approval.Visible = false;
                }
                else
                {
                    btn_approval.Visible = true;
                }
                bindListBox();

            }
        }

        private void bindListBox()
        {

            ddl_supplier.DataSource = getReader();
            // Name will be displayed in the dropdownlist control
            ddl_supplier.DataTextField = "supplier_name";
            // when an item is selected in dropdownlist
            // CategoryID will be returned in ddlCategory.SelectedValue
            ddl_supplier.DataValueField = "supplier_id";
            ddl_supplier.DataBind();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
            con.Open();
            string q = "Select * from suppliers where supplier_id = @id";


            SqlCommand query = new SqlCommand(q, con);
            query.Parameters.AddWithValue("@id", Convert.ToInt32(ddl_supplier.Text));
            SqlDataReader dr = query.ExecuteReader();


            if (dr.Read())
            {
                lbl_name.Text = dr["supplier_name"].ToString();
                lbl_addr.Text = dr["supplier_address"].ToString();
                lbl_email.Text = dr["supplier_email"].ToString();
                lbl_cont.Text = dr["supplier_contact"].ToString();

            }
            con.Close();

        }

        protected void LoadCart()
        {
            gv_CartView.DataSource = ShoppingCart.Instance.Items;
            gv_CartView.DataBind();

            decimal total = 0.00m;
            decimal totalCal = 0.00m;
            foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
            {
                total = total + item.TotalPrice;

            }

            lbl_ShippingFee.Text = "200.00";
            totalCal = total + 200;
            lbl_TotalPrice.Text = totalCal.ToString("#,##0");

            lbl_TotalItem.Text = total.ToString("#,##0");

        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                lbl_Error.Text = "Message: Item " + e.CommandArgument.ToString() + " has been removed.";
                string productId = e.CommandArgument.ToString();
                ShoppingCart.Instance.RemoveItem(productId);
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
                            ShoppingCart.Instance.SetItemQuantity(productId, quantity);

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
                            ShoppingCart.Instance.SetItemQuantity(productId, quantity);

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

        private SqlDataReader getReader()
        {
            //get connection string from web.config
            string strConnectionString =
                ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT supplier_name, supplier_id from suppliers";

            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            // CommandBehavior.CloseConnection will automatically close connection
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        protected void ddl_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
            con.Open();
            string q = "Select * from suppliers where supplier_id = @id";


            SqlCommand query = new SqlCommand(q, con);
            query.Parameters.AddWithValue("@id", Convert.ToInt32(ddl_supplier.Text));
            SqlDataReader dr = query.ExecuteReader();


            if (dr.Read())
            {
                lbl_name.Text = dr["supplier_name"].ToString();
                lbl_addr.Text = dr["supplier_address"].ToString();
                lbl_email.Text = dr["supplier_email"].ToString();
                lbl_cont.Text = dr["supplier_contact"].ToString();

            }
            con.Close();
        }
       /* public bool IsHighestDivision(object DivisionSortKey)
        {
            if (DivisionSortKey.ToString() == "product")
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
        protected void btn_approval_Click(object sender, EventArgs e)
        {

            int cresult = 0;
            int poresult = 0;


            PurchaseOrder po = new PurchaseOrder();
            //decimal total_price, DateTime order_date, int supplier_id, int update_history_id, int qyt, int product_id,
            int neworderid = 0;
            int pohistory = 1;
            neworderid = po.POInsert(decimal.Parse(lbl_TotalItem.Text), Convert.ToInt32(ddl_supplier.Text), pohistory);
            if (neworderid > 0)
            {
                int no = -1;
                foreach (GridViewRow row in gv_CartView.Rows)
                {
                    no += 1;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
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


                            result = prod.ProductInsert(pname, desc, price, img, update_history_id, typeid, 0, rop, rop_qty, 1, false);
                            if (result > 0)
                            {
                                //string saveimg = Server.MapPath(" ") + "\\" + image;
                                //lbl_Result.Text = saveimg.ToString();
                                //FileUpload.SaveAs(saveimg);
                                Response.Write("<script language='javascript'>window.alert('Product Insert Successful');window.location='View.aspx';</script>");
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
                        string wtype = gv_CartView.Rows[no].Cells[1].Text;
                        poiinsert = po.POIInsert(quantity, orderid, pid, wtype);
                        //send to product details and show them if any product or category is inserted using session
                        /*string SID = gv_CartView.Rows[no].Cells[0].Text;
                        string wtype = gv_CartView.Rows[no].Cells[1].Text;
                        if (wtype == "bundle")
                        {
                            BundleCat bund = new BundleCat();
                            DataSet ds;
                            string ID = gv_CartView.Rows[no].Cells[0].Text;
                            ds = bund.getBundleDetails(Convert.ToInt32(ID));
                            int count = Convert.ToInt32(ds.Tables[0].Rows[0]["row_no"].ToString());

                             
                            string pname = ds.Tables[0].Rows[0]["product_name"].ToString();
                            

                            //TO CHECK IF PRODUCT EXSIST IN TRINGLE
                            List<Product> checkproduct = new List<Product>();
                            checkproduct = aprod.checkproduct(pname);
                            if (checkproduct.Count == 0) //IF PRODUCT DONT EXSITS CHECK CATEGORY
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

                                //FIND THE CATEGORY ID USING THE NAME
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

                                //ADD PRODUCT INTO DATABASE
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
                                int update_history_id = 1;
                                Product prod = new Product();
                                result = prod.ProductInsert(pname, desc, price, img, update_history_id, typeid, 0, rop, rop_qty, 1);
                                if (result > 0)
                                {
                                    Response.Write("<script language='javascript'>window.alert('Product Insert Successful')</script>");
                                }
                                else
                                {
                                    Response.Write("<sript>alert('Product Insert not successful');</script>");
                                }
                            }

                            //FIND FOR THE POID
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

                            //FIND THE PRODUCT ID
                            SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                            connn.Open();
                            string q3 = "Select product_id from products where product_name = @productname";
                            //connn.Open();
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
                            int poiinsert = 0;
                            int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
                            poiinsert = po.POIInsert(quantity, orderid, pid);
                        }
                        else if (wtype == "product")
                        {
                            //string ID = (gv_CartView.Rows[0].FindControl("lbl_pname")).ToString();
                            ProductCat myCat = new ProductCat();
                            DataSet ds;
                            string ID = gv_CartView.Rows[no].Cells[0].Text;
                            ds = myCat.getProductDetails(Convert.ToInt32(ID));
                            string pname = ds.Tables[0].Rows[0]["product_name"].ToString();

                            //TO CHECK IF PRODUCT EXSIST IN TRINGLE
                            List<Product> checkproduct = new List<Product>();
                            checkproduct = aprod.checkproduct(pname);
                            if (checkproduct.Count == 0) //IF PRODUCT DONT EXSITS CHECK CATEGORY
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

                                //FIND THE CATEGORY ID USING THE NAME
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

                                //ADD PRODUCT INTO DATABASE
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
                                int update_history_id = 1;
                                Product prod = new Product();
                                result = prod.ProductInsert(pname, desc, price, img, update_history_id, typeid, 0, rop, rop_qty, 1);
                                if (result > 0)
                                {
                                    Response.Write("<script language='javascript'>window.alert('Product Insert Successful')</script>");
                                }
                                else
                                {
                                    Response.Write("<sript>alert('Product Insert not successful');</script>");
                                }
                            }

                            //FIND FOR THE POID
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

                            //FIND THE PRODUCT ID
                            SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                            connn.Open();
                            string q3 = "Select product_id from products where product_name = @productname";
                            //connn.Open();
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
                            int poiinsert = 0;
                            int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
                            poiinsert = po.POIInsert(quantity, orderid, pid);
                        }*/
                    }
                }
            }
            else
            {
                Response.Write("<sript>alert('Purchase order insert not successful');</script>");
            }
            ShoppingCart.Instance.Items.Clear();
            Response.Write("<script language='javascript'>window.alert('Purchase order has been raised');window.location='View.aspx';</script>");
            ScriptManager.RegisterStartupScript
                (this, this.GetType(),
                "alert",
                "alert('Purchase order has been raised');window.location ='View.aspx';",
                true);
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/Products.aspx");
        }

    }
}
