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
    public partial class CategoryInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categories.aspx");
        }


        protected void btn_add_Click(object sender, EventArgs e)
        {
            int result = 0;

            //  Product prod = new Product(tb_ProductID.Text, tb_ProductName.Text, tb_ProductDesc.Text, decimal.Parse(tb_UnitPrice.Text), FileUpload1.FileName, int.Parse(tb_StockLevel.Text));
            int update_history_id = 1;

            Category cat = new Category();
            result = cat.CategoryInsert(tb_name.Text, tb_desc.Text, update_history_id);
            if (result > 0)
            {

                Response.Write("<script language='javascript'>window.alert('Category Insert Successful');window.location='Categories.aspx';</script>");
                // Response.Write("<sript>alert('Insert successful');</script>");
            }

            else
            {
                Response.Write("<sript>alert('Category Insert not successful');</script>");
            }
        }
    }
}