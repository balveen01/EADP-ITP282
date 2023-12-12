using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle.assets.mp
{
    public partial class CatalogueMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Products_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/Products.aspx");
        }

        protected void lbtn_CProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/CProducts.aspx");
        }

        protected void lbtn_Products_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/Add-Product.aspx");
        }

        protected void lbtn_Categories_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/Categories.aspx");
        }

        protected void lbtn_Add_Item_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/AddItem.aspx");
        }

        protected void lbtn_Item_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/ItemList.aspx");
        }

        protected void lbtn_Accounts_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/ArchiveProduct.aspx");
        }

        protected void lbtn_cat_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/ArcCat.aspx");
        }

        protected void lbtn_Bundle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Catalogue/ViewBundle.aspx");
        }
    }
}