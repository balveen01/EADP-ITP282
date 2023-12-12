﻿using Doosan.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.e.Catalogue
{
    public partial class BundleUpdate : System.Web.UI.Page
    {
        Bundle bund = new Bundle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString);
                con.Open();
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                string q = "Select * from bundle where bundle_id = '" +id + "'";


                SqlCommand query = new SqlCommand(q, con);
                SqlDataReader dr = query.ExecuteReader();

                if (dr.Read())
                {
                    tb_desc.Text = dr["bundle_desc"].ToString();
                    tb_dist.Text = dr["discount"].ToString();

                }
                con.Close();
                LoadCart();
            }
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
        protected void btn_uodate_Click(object sender, EventArgs e)
        {
            Bundle co = new Bundle();
            //decimal total_price, int update_history_id, int order_id
            int coupdate = 0;
            int pohistory = 1;
            int order_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            string desc = tb_desc.Text;
            int dist = Convert.ToInt32(tb_dist.Text);
            double rate = Convert.ToDouble(tb_dist.Text) / 100;
            double discount = Convert.ToDouble(lbl_TotalItem.Text) * rate;
            double price = Convert.ToDouble(lbl_TotalItem.Text) - discount;
            //double price = Convert.ToDouble(lbl_TotalItem) - (Convert.ToDouble(lbl_TotalItem) * Convert.ToDouble(tb_dist));
            lbl_TotalPrice.Text = price.ToString();
            decimal totalprice = decimal.Parse(lbl_TotalPrice.Text);
            coupdate = co.BundleUpdate(desc, totalprice, dist, pohistory, order_id);



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
                        coiupdate = co.ItemUpdate(quantity, order_id, Convert.ToInt32(ID));
                    }
                }
                //Response.Write("<script>alert('Customer order has been updated');</script>");
                CustOrderCart.Instance.Items.Clear();
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Bundle has been updated');window.location ='Bundles.aspx';",
                      true);
            }
            else
            {
                Response.Write("<script>alert('Bundle has NOT been updated');</script>");
            }

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            CustOrderCart.Instance.Items.Clear();
            Response.Redirect("Bundles.aspx");
        }
    }
}