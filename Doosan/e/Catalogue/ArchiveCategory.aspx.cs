using Doosan.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.e.Catalogue
{
    public partial class ArchiveCategory : System.Web.UI.Page
    {
        Category cat = new Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                // call BindGridView
                BindGridView();
            }
        }
        protected void gv_category_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = int.Parse(gv_category.DataKeys[e.RowIndex].Value.ToString());
            result = cat.CategoryUnarchieve(id);

            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Category has been unarchived successfully');window.location ='ArchiveCategory.aspx';",true);
                //Response.Write("Category has been unarchived successfully");
            }
            else
            {
                //lbl_result.Text = "User removal NOT successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('NOT successful');window.location ='ArchiveCategory.aspx';", true);
                //Response.Write("NOT successful");
            }
        }

        protected void gv_category_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_category.PageIndex = newPageIndex;
            BindGridView();
        }

        private void BindGridView()
        {
            List<Category> categorylist = new List<Category>();
            categorylist = cat.getCategoryArchievAll();
            gv_category.DataSource = categorylist;
            gv_category.DataBind();


        }

        protected void ddl_sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            allthree();
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            allthree();
        }
        private void allthree()
        {
            if (string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text != "None") //to sort
            {
                this.gv_category.Visible = true;
                List<Category> productsortlist = new List<Category>();
                string tid = ddl_sort.Text;
                string queryStr = "SELECT * FROM product_type where is_archived = 'True' order by " + tid;
                productsortlist = cat.getallthree(queryStr);
                gv_category.DataSource = productsortlist;
                gv_category.DataBind();
            }
            else if (ddl_sort.Text == "None" && tb_search.Text.Length != 0)//to search
            {
                this.gv_category.Visible = true;
                List<Category> productsearchlist = new List<Category>();
                string tid = tb_search.Text;
                string queryStr = "SELECT * FROM product_type where type_name like'%" + tid + "%'  and is_archived = 'True'";
                productsearchlist = cat.getallthree(queryStr);
                if (productsearchlist.Count == 0)
                {
                    lbl_search.Text = "There is no product when with that name";
                    this.gv_category.Visible = false;

                    if (String.IsNullOrEmpty(tb_search.Text))
                    {
                        this.gv_category.Visible = true;
                        lbl_search.Text = "";
                        BindGridView();
                    }
                }

                else
                {
                    lbl_search.Text = "";
                    gv_category.DataSource = productsearchlist;
                    gv_category.DataBind();
                }
            }
            else if (tb_search.Text.Length != 0 && ddl_sort.Text != "None")//sort and search
            {
                this.gv_category.Visible = true;
                List<Category> productbothlist = new List<Category>();
                string sid = ddl_sort.Text;
                string tid = tb_search.Text; ;
                string queryStr = "SELECT * FROM product_type where type_name like '%" + tid + "%' and is_archived = 'True' order by " + sid;
                productbothlist = cat.getallthree(queryStr);
                gv_category.DataSource = productbothlist;
                gv_category.DataBind();
            }

            else if (string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text == "None")//none
            {
                BindGridView();
            }
        }
    }
}