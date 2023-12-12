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

    public partial class PoUpdate : System.Web.UI.Page
    {
        Product prod = new Product();
        PurchaseOrder po = new PurchaseOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_approve.Visible = false;
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

                if (dr1.Read())
                {
                    capprove = dr1["is_com_approved"].ToString();
                    cdeclined = dr1["is_com_declined"].ToString();
                    lbl_reason.Text = dr1["reason"].ToString();
                    lbl_attempt.Text = dr1["attempt_no"].ToString();
                }
                conn.Close();

                if (capprove == "False" && cdeclined == "False")
                {
                    lbl_rname.Visible = false;
                    lbl_aname.Visible = false;
                    lbl_attempt.Visible = false;
                    btn_approve.Visible = false;
                    btn_update.Visible = true;
                }

                if (cdeclined == "True")
                {
                    lbl_rname.Visible = true;
                    lbl_aname.Visible = true;
                    lbl_attempt.Visible = true;
                    btn_approve.Visible = true;
                    btn_update.Visible = false;
                }

                LoadCart();
                bindListBox();
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
                ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT * from products";

            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            // CommandBehavior.CloseConnection will automatically close connection
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        protected void LoadCart()
        {
            gv_CartView.DataSource = POCart.Instance.Items;
            gv_CartView.DataBind();

            decimal total = 0.00m;
            decimal totalCal = 0.00m;
            foreach (POCartItem item in POCart.Instance.Items)
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
                POCart.Instance.RemoveItem(productId);
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
                            POCart.Instance.SetItemQuantity(productId, quantity);

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
                            POCart.Instance.SetItemQuantity(productId, quantity);

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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //decimal total_price, DateTime order_date, int supplier_id, int update_history_id, int qyt, int product_id,
            int poiinsert = 0;
            int quantity = Convert.ToInt32(tb_qty.Text);
            int orderid = Convert.ToInt32(Request.QueryString["id"].ToString());
            int productid = Convert.ToInt32(ddl_name.Text);
            poiinsert = po.POIInsert(quantity, orderid, productid, "product");
            if (poiinsert == 0)
            {
                Response.Write("<script>Product has been added into purchase order</script>");
            }
            else
            {
                Response.Write("<script>Product has NOT been added into purchase order</script>");
            }
            Product aProd = new Product();
            prod = aProd.getProduct(productid);

            //string ID = gv_CartView.Rows[no].Cells[0].Text;
            string iProductID = prod.product_id.ToString();
            POCart.Instance.AddItem(iProductID, prod);
            POCart.Instance.SetItemQuantity(iProductID, quantity);
            LoadCart();
        }


        protected void btn_close_Click(object sender, EventArgs e)
        {
            pnlPopUp.Visible = false;
        }
        protected void btn_addproduct_Click(object sender, EventArgs e)
        {
            pnlPopUp.Visible = true;
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            //int order_id, int total_price, int update_history_id, int quantity
            //int resultp = 0;
            //int qid = Convert.ToInt32(Request.QueryString["id"].ToString());
            //int total = 0;
            //resultp = po.poUpdate(qid, total, 1);





            PurchaseOrder co = new PurchaseOrder();
            //decimal total_price, int update_history_id, int order_id
            int coupdate = 0;
            int pohistory = 1;
            decimal totalprice = decimal.Parse(lbl_TotalPrice.Text);
            int order_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            coupdate = co.poUpdate(totalprice, pohistory, order_id);



            if (coupdate == 1)
            {
                int no = -1;
                foreach (GridViewRow row in gv_CartView.Rows)
                {
                    no += 1;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        int coiupdate = 0;
                        int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
                        string ID = gv_CartView.Rows[no].Cells[0].Text;
                        //int qty, int order_id, int product_id
                        coiupdate = co.poiUpdate(quantity, order_id, Convert.ToInt32(ID));
                    }
                }
                //Response.Write("<script>alert('Customer order has been updated');</script>");
                POCart.Instance.Items.Clear();
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Purchase order has been updated');window.location ='PoDetails.aspx?id=" + order_id + "';",
                      true);
            }
            else
            {
                Response.Write("<script>alert('Purchase order has NOT been updated');</script>");
            }

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            POCart.Instance.Items.Clear();
            string id = Request.QueryString["id"].ToString();
            Response.Redirect("PoDetails.aspx?id=" + id);
        }





        protected void btn_approve_Click(object sender, EventArgs e)
        {
            PurchaseOrder co = new PurchaseOrder();
            //decimal total_price, int update_history_id, int order_id
            int coupdate = 0;
            int pohistory = 1;
            decimal totalprice = decimal.Parse(lbl_TotalPrice.Text);
            int order_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            coupdate = co.poApprove(totalprice, pohistory, order_id);



            if (coupdate == 1)
            {
                int no = -1;
                foreach (GridViewRow row in gv_CartView.Rows)
                {
                    no += 1;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        int coiupdate = 0;
                        int quantity = int.Parse(((TextBox)row.Cells[2].FindControl("tb_Quantity")).Text);
                        string ID = gv_CartView.Rows[no].Cells[0].Text;
                        //int qty, int order_id, int product_id
                        coiupdate = co.poiUpdate(quantity, order_id, Convert.ToInt32(ID));
                    }
                }
                //Response.Write("<script>alert('Customer order has been updated');</script>");
                POCart.Instance.Items.Clear();
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Purchase order has been sent for approval');window.location ='View.aspx';",
                      true);
            }
            else
            {
                Response.Write("<script>alert('Purchase order has NOT been sent for approval');</script>");
            }
        }







    }
}
