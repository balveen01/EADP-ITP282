using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;
using System.Data;
using Triangle.BLL;
using System.IO;

namespace Triangle.w.Admin.Catalogue
{
    public partial class Products : System.Web.UI.Page
    {
        Product prod = null;
        string prodid = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                // call BindGridView
                BindGridView();
            }
        }
        private void BindGridView()
        {
            ProductCat myCat = new ProductCat();
            DataSet ds;
            ds = myCat.getProductList();
            gv_products.DataSource = ds;
            gv_products.DataBind();
        }

        protected void gv_products_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_products.PageIndex = newPageIndex;
            BindGridView();
        }

        protected void gv_products_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlPopUp.Visible = true;
            int selectedProductId = Convert.ToInt32(gv_products.SelectedValue);
            prodid = selectedProductId.ToString();
            ProductCat myCat = new ProductCat();
            DataSet ds;
            ds = myCat.getProductDetails(selectedProductId);
            dv_product.DataSource = ds;
            dv_product.DataBind();
        }




        protected void btn_close_Click(object sender, EventArgs e)
        {
            pnlPopUp.Visible = false;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            ProductCat myCat = new ProductCat();
            DataSet ds;
            prodid = gv_products.SelectedValue.ToString();
            ds = myCat.getProductDetails(Convert.ToInt32(prodid));

            //string iProductID = prod.Product_ID.ToString();
            ShoppingCart.Instance.AddItem(prodid, prod);

            Response.Write("<script language='javascript'>window.alert('Product added');</script>");
        }

        
    }
}