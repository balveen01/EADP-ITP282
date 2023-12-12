using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.BLL;
using Triangle.models;

namespace Triangle.w
{
    public partial class AddItem : System.Web.UI.Page
    {
        Product prod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lbl_total.Text = "$0.00";
                bindListBox();
            }
        }

        private void bindListBox()
        {
            ProductCat myCat = new ProductCat();
            DataSet ds;
            // Name will be displayed in the dropdownlist control
            ddl_name.DataTextField = "product_name";
            // when an item is selected in dropdownlist
            // CategoryID will be returned in ddlCategory.SelectedValue
            ddl_name.DataValueField = "product_id";
            ds = myCat.getProductList();
            ddl_name.DataSource = ds;
            ddl_name.DataBind();

            lbl_price.Text = ds.Tables[0].Rows[0]["unit_price"].ToString();
            //ddl_name.DataBind();
        }

        protected void ddl_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductCat myCat = new ProductCat();
            DataSet ds;
            ds = myCat.getProductDetails(Convert.ToInt32(ddl_name.Text));

            decimal priceqty = decimal.Parse(ds.Tables[0].Rows[0]["unit_price"].ToString());
            lbl_price.Text = priceqty.ToString("#,##0");

            decimal price = 0;
            int quant = 0;
            decimal total = 0;
            price = decimal.Parse(lbl_price.Text);
            if (tb_quant.Text == "")
            {
                quant = 0;
            }
            else
            {
                quant = int.Parse(tb_quant.Text);
            }
            total = price * quant;
            lbl_total.Text = total.ToString("#,##0");

        }

        protected void tb_quant_TextChanged(object sender, EventArgs e)
        {
            ProductCat myCat = new ProductCat();
            DataSet ds;
            ds = myCat.getProductDetails(Convert.ToInt32(ddl_name.Text));

            lbl_price.Text = ds.Tables[0].Rows[0]["unit_price"].ToString();

            if (ddl_name.Text != null)
            {
                decimal price = decimal.Parse(lbl_price.Text);
                int quant = int.Parse(tb_quant.Text);
                decimal total = price * quant;
                lbl_total.Text = total.ToString();
            }
            else
            {
                lbl_total.Text = "$0.00";
            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //ProductCat myCat = new ProductCat();
            //DataSet ds;
            //ds = myCat.getProductDetails(Convert.ToInt32(ddl_name.Text));

            //string iProductID = prod.Product_ID.ToString();
            int quantity = Convert.ToInt32(tb_quant.Text);
            ShoppingCart.Instance.AddItem(ddl_name.Text, prod);
            ShoppingCart.Instance.SetItemQuantity(ddl_name.Text, quantity);
            Response.Write("<script language='javascript'>window.alert('Product added');</script>");
        }
    }
}