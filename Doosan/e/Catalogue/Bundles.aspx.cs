using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.models;

namespace Doosan.e.Catalogue
{
    public partial class Bundles : System.Web.UI.Page
    {
        Bundle bund = new Bundle();
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
            List<Bundle> productlist = new List<Bundle>();
            productlist = bund.getAallBundle();
            gv_bundle.DataSource = productlist;
            gv_bundle.DataBind();
        }

        protected void gv_products_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_bundle.PageIndex = newPageIndex;
            BindGridView();
        }

        protected void gv_products_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_bundle.SelectedRow;

            Response.Redirect("BundleDetails.aspx?id=" + gr.Cells[0].Text);
        }


    }
}