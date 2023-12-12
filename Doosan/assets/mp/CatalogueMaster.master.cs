using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.assets.mp
{
    public partial class CatalogueMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Products_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/Products.aspx");
        }

        protected void lbtn_Products_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/Add-Product.aspx");
        }

        protected void lbtn_Categories_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/Categories.aspx");
        }
        protected void lbtn_Accounts_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/ArchiveProduct.aspx");
        }

        protected void lbtn_Categories_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/ArchiveCategory.aspx");
        }

        protected void lbtn_bundle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/Bundles.aspx");
        }

        protected void lbtn_addbundle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/Add-Bundle.aspx");
        }

        protected void lbtn_Bundle_Archive_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Catalogue/ArchiveBundle.aspx");
        }
    }
}