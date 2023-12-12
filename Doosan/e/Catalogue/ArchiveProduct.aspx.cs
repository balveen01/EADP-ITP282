using Doosan.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doosan.e.Catalogue
{
    public partial class ArchiveProduct : System.Web.UI.Page
    {
        Product aprod = new Product();
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
            List<Product> productlist = new List<Product>();
            productlist = aprod.getProductArchievAll();
            gv_products.DataSource = productlist;
            gv_products.DataBind();


        }

        protected void gv_products_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_products.PageIndex = newPageIndex;
            allthree();
        }



        protected void gv_products_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = int.Parse(gv_products.DataKeys[e.RowIndex].Value.ToString());
            result = aprod.ProductUnarchieve(id);

            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Product has been unarchived successfully');window.location ='ArchiveProduct.aspx';",true);
                //Response.Write("Product has been unarchived successfully");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('NOT successful');window.location ='ArchiveProduct.aspx';",true);
                //Response.Write("NOT successful");
            }
        }

        protected void ddl_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            allthree();
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
            if (ddl_filter.Text == "None" && string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text != "None") //to sort
            {
                this.gv_products.Visible = true;
                List<Product> productsortlist = new List<Product>();
                string tid = ddl_sort.Text;
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'True' order by p." + tid;
                productsortlist = aprod.getallthree(queryStr);
                gv_products.DataSource = productsortlist;
                gv_products.DataBind();
            }
            else if (ddl_sort.Text == "None" && string.IsNullOrEmpty(tb_search.Text) && ddl_filter.Text != "None")//to filter
            {
                this.gv_products.Visible = true;
                List<Product> productsortlist = new List<Product>();
                string tid = ddl_filter.Text;
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'True' and p.type_id = " + tid;
                productsortlist = aprod.getallthree(queryStr);
                gv_products.DataSource = productsortlist;
                gv_products.DataBind();
                this.gv_products.Visible = true;
            }
            else if (ddl_filter.Text == "None" && ddl_sort.Text == "None" && tb_search.Text.Length != 0)//to search
            {
                this.gv_products.Visible = true;
                List<Product> productsearchlist = new List<Product>();
                string tid = tb_search.Text;
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where product_name like '%" + tid + "%' and p.is_archived = 'True'";
                productsearchlist = aprod.getallthree(queryStr);
                if (productsearchlist.Count == 0)
                {
                    lbl_search.Text = "There is no product with that name";
                    this.gv_products.Visible = false;

                    if (String.IsNullOrEmpty(tb_search.Text))
                    {
                        this.gv_products.Visible = true;
                        lbl_search.Text = "";
                        BindGridView();
                    }
                }

                else
                {
                    lbl_search.Text = "";
                    gv_products.DataSource = productsearchlist;
                    gv_products.DataBind();
                }
            }
            else if (ddl_filter.Text == "None" && tb_search.Text.Length != 0 && ddl_sort.Text != "None")//sort and search
            {
                this.gv_products.Visible = true;
                List<Product> productbothlist = new List<Product>();
                string sid = ddl_sort.Text;
                string tid = tb_search.Text; ;
                string queryStr = "SELECT * FROM product_type where type_name like '%" + tid + "%' and is_archived = 'True' order by " + sid;
                productbothlist = aprod.getallthree(queryStr);
                gv_products.DataSource = productbothlist;
                gv_products.DataBind();
            }
            else if (ddl_sort.Text == "None" && tb_search.Text.Length != 0 && ddl_filter.Text != "None")//filter and search
            {
                this.gv_products.Visible = true;
                List<Product> productbothlist = new List<Product>();
                string tid = tb_search.Text;
                string fid = ddl_filter.Text;
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where product_name like '%" + tid + "%' and p.is_archived = 'True' and t.type_id = " + fid;
                productbothlist = aprod.getallthree(queryStr);
                gv_products.DataSource = productbothlist;
                gv_products.DataBind();
            }
            else if (string.IsNullOrEmpty(tb_search.Text) && ddl_filter.Text != "None" && ddl_sort.Text != "None")//filter and sort
            {
                this.gv_products.Visible = true;
                List<Product> productbothlist = new List<Product>();
                string sid = ddl_sort.Text;
                string fid = ddl_filter.Text;
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'True' and t.type_id = " + fid + "order by p." + sid;
                productbothlist = aprod.getallthree(queryStr);
                gv_products.DataSource = productbothlist;
                gv_products.DataBind();
            }
            else if (ddl_filter.Text == "None" && string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text == "None")//none
            {
                BindGridView();
            }
            else // for all 
            {
                this.gv_products.Visible = true;
                List<Product> productbothlist = new List<Product>();
                string sid = ddl_sort.Text;
                string tid = tb_search.Text;
                string fid = ddl_filter.Text;
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where product_name like '%" + tid + "%' and p.is_archived = 'True' and t.type_id = " + fid + "order by p." + sid;
                productbothlist = aprod.getallthree(queryStr);
                gv_products.DataSource = productbothlist;
                gv_products.DataBind();
            }
        }
    }
}