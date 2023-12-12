using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;
using Triangle.BLL;
using System.Data;

namespace Triangle.w.Admin.Catalogue
{
    public partial class ViewBundle : System.Web.UI.Page
    {
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
            BundleCat myCat = new BundleCat();
            DataSet ds;
            ds = myCat.getBundleList();
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
            string id = gv_products.SelectedValue.ToString();
            Response.Redirect("BundleDetail.aspx?id=" + id);
        }
    }
}