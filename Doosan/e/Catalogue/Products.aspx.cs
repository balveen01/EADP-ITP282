using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Doosan.models;

namespace Doosan.e.Catalogue
{
    public partial class Products : System.Web.UI.Page
    {
        Product aprod = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                bindListBox();
                // call BindGridView
                BindGridView();
            }
        }
        private void bindListBox()
        {

            ddl_filter.DataSource = getReader();
            // Name will be displayed in the dropdownlist control
            ddl_filter.DataTextField = "type_name";
            // when an item is selected in dropdownlist
            // CategoryID will be returned in ddlCategory.SelectedValue
            ddl_filter.DataValueField = "type_id";
            ddl_filter.DataBind();

        }

        private SqlDataReader getReader()
        {
            //get connection string from web.config
            string strConnectionString =
                ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT type_id, type_name  from product_type";

            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            // CommandBehavior.CloseConnection will automatically close connection
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        private void BindGridView()
        {
            List<Product> productlist = new List<Product>();
            productlist = aprod.getProductAll();
            gv_products.DataSource = productlist;
            gv_products.DataBind();
        }

        protected void gv_products_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_products.PageIndex = newPageIndex;
            allthree();
        }

        protected void gv_products_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_products.SelectedRow;

            Response.Redirect("ProductUpdate.aspx?id=" + gr.Cells[0].Text);
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
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' order by p." + tid;
                productsortlist = aprod.getallthree(queryStr);
                gv_products.DataSource = productsortlist;
                gv_products.DataBind();
            }
            else if (ddl_sort.Text == "None" && string.IsNullOrEmpty(tb_search.Text) && ddl_filter.Text != "None")//to filter
            {
                this.gv_products.Visible = true;
                List<Product> productsortlist = new List<Product>();
                string tid = ddl_filter.Text;
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' and p.type_id = " + tid;
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
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where product_name like '%" + tid +  "%' and p.is_archived = 'False'";
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
                string queryStr = "SELECT * FROM product_type where type_name like '%" + tid + "%' and is_archived = 'False' order by " + sid;
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
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where product_name like '%" + tid +  "%' and p.is_archived = 'False' and t.type_id = " + fid;
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
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' and t.type_id = " + fid + "order by p." + sid;
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
                string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where product_name like '%" + tid +  "%' and p.is_archived = 'False' and t.type_id = " + fid + "order by p." + sid;
                productbothlist = aprod.getallthree(queryStr);
                gv_products.DataSource = productbothlist;
                gv_products.DataBind();
            }
        }
    }
}