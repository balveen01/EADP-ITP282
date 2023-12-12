using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;
using Triangle.BLL;

namespace Triangle.w.Admin.Catalogue
{
    public partial class ItemList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
                if (gv_CartView.Rows.Count == 0)
                {
                    btn_payment.Visible = false;
                    btn_Clear.Visible = false;
                    btn_Update.Visible = false;
                }
                else
                {
                    btn_payment.Visible = true;
                    btn_Clear.Visible = true;
                    btn_Update.Visible = true;
                }
            }
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



        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductDetails.aspx");
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            ShoppingCart.Instance.Items.Clear();
            LoadCart();
            lbl_ShippingFee.Text = "0.00";
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
        protected void btn_payment_Click(object sender, EventArgs e)
        {
            Response.Redirect("\\/w/Admin/Purchase-Orders/RaisePO.aspx");
        }
    }
}