using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.models;
namespace Doosan.e.Catalogue
{
    public partial class ArchiveBundle : System.Web.UI.Page
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
            productlist = bund.getArcBundle();
            gv_bundle.DataSource = productlist;
            gv_bundle.DataBind();
        }


        protected void gv_co_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int result1 = 0;
            int id = int.Parse(gv_bundle.DataKeys[e.RowIndex].Value.ToString());
            //int id = int.Parse(gv_po.DataKeys[e.RowIndex].Value.ToString());
            result = bund.ItemUnarchieve(id);
            result1 = bund.BundleUnarchieve(id);

            if (result > 0 && result1 > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Bundle has been unarchived successfully');window.location ='ArchiveBundle.aspx';",true);
                //Response.Write("Bundle has been unarchived successfully");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('NOT successful');window.location ='ArchiveBundle.aspx';",true);
                //Response.Write("NOT successful");
            }
        }
        protected void gv_products_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_bundle.PageIndex = newPageIndex;
            BindGridView();
        }

    }
}