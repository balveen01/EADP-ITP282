using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Triangle.models;
using Triangle.BLL;
using System.Data.SqlClient;

namespace Triangle.w.Admin.Catalogue
{
    public partial class CategoryUpdate : System.Web.UI.Page
    {
        Category cat = new Category();
        Product prod = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lbl_id.Text = Request.QueryString["id"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                con.Open();
                string q = "Select * from product_type where type_id = '" + lbl_id.Text + "'";


                SqlCommand query = new SqlCommand(q, con);
                SqlDataReader dr = query.ExecuteReader();

                if (dr.Read())
                {
                    tb_name.Text = dr["type_name"].ToString();
                    tb_desc.Text = dr["type_desc"].ToString();

                }
                con.Close();



            }
        }
        protected void btn_archive_Click(object sender, EventArgs e)
        {
            int check = 0;
            int tid = int.Parse(lbl_id.Text);
            List<Product> categorylist = new List<Product>();
            categorylist = prod.checkcat(tid);
            if (categorylist.Count != 0)
            {
                gv_products.Visible = true;
                detials.Visible = false;
                lbl_error.Text = "There are products that belong under this category. Please change the product type before archiving";
                List<Product> categorylistq = new List<Product>();
                categorylistq = prod.checkcat(tid);
                gv_products.DataSource = categorylistq;
                gv_products.DataBind();
            }
            else
            {
                int result = 0;
                int id = int.Parse(lbl_id.Text);
                result = cat.CategoryDelete(id);

                if (result > 0)
                {
                    ScriptManager.RegisterStartupScript
                          (this, this.GetType(),
                          "alert",
                          "alert('Category has been archived successfully');window.location ='Categories.aspx';",
                          true);
                }
                else
                {
                    //lbl_result.Text = "User removal NOT successfully";
                    ScriptManager.RegisterStartupScript
                          (this, this.GetType(),
                          "alert",
                          "alert('Category removal NOT successful');window.location ='Categories.aspx';",
                          true);
                }
            }
        }
        protected void gv_products_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_products.PageIndex = newPageIndex;
            List<Product> productlist = new List<Product>();
            productlist = prod.getProductAll();
            gv_products.DataSource = productlist;
            gv_products.DataBind();
        }

        protected void gv_products_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_products.SelectedRow;

            Response.Redirect("ProductUpdate.aspx?id=" + gr.Cells[0].Text);
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            int check = 0;
            int tid = int.Parse(lbl_id.Text);
            List<Product> categorylist = new List<Product>();
            categorylist = prod.checkcat(tid);
            if (categorylist.Count != 0)
            {
                gv_products.Visible = true;
                detials.Visible = false;
                lbl_error.Text = "There are products that belong under this category. Please change the product type before updating";
                List<Product> categorylistq = new List<Product>();
                categorylistq = prod.checkcat(tid);
                gv_products.DataSource = categorylistq;
                gv_products.DataBind();
            }
            else
            {
                int result = 0;

                result = cat.UpdateCategory(int.Parse(lbl_id.Text), tb_name.Text, tb_desc.Text);
                if (result > 0)
                {
                    ScriptManager.RegisterStartupScript
                           (this, this.GetType(),
                           "alert",
                           "alert('Category Edited');window.location ='Categories.aspx';",
                           true);
                    //Response.Redirect("Staff(Admin).aspx");
                }
                else
                {
                    //lbl_result.Text = "User update not successful";
                    Response.Write("<script>alert('Category update NOT successful');</script>");
                }
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categories.aspx");
        }
        protected void btn_insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryInsert.aspx");
        }
    }
}