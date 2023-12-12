using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.BLL;
using Doosan.models;
namespace Doosan.e.Orders
{
    public partial class ArcCo : System.Web.UI.Page
    {
        CustomerOrder co = new CustomerOrder();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                // call BindGridView
                BindGridView();
            }
        }

        protected void gv_po_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_co.PageIndex = newPageIndex;
            BindGridView();
        }

        private void BindGridView()
        {
            List<CustomerOrder> categorylist = new List<CustomerOrder>();
            categorylist = co.getArcCOall();
            gv_co.DataSource = categorylist;
            gv_co.DataBind();


        }

        protected void gv_co_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int result1 = 0;
            int id = int.Parse(gv_co.DataKeys[e.RowIndex].Value.ToString());
            //int id = int.Parse(gv_po.DataKeys[e.RowIndex].Value.ToString());
            result = co.coiUnarchieve(id);
            result1 = co.coUnarchieve(id);

            if (result > 0 && result1 > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Customer Order has been unarchived successfully');window.location ='ArcCo.aspx';",true);
                //Response.Write("Customer Order has been unarchived successfully");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('NOT successful');window.location ='ArcCo.aspx';",true);
                //Response.Write("NOT successful");
            }
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
                this.gv_co.Visible = true;
                List<CustomerOrder> productsortlist = new List<CustomerOrder>();
                string tid = ddl_sort.Text;
                string queryStr = "SELECT *from customer_order o inner join companies c on c.company_id = o.company_id where o.is_archived = 'True' order by " + tid;
                productsortlist = co.getallthree(queryStr);
                gv_co.DataSource = productsortlist;
                gv_co.DataBind();
            }
            else if (ddl_sort.Text == "None" && tb_search.Text.Length != 0)//to search
            {
                this.gv_co.Visible = true;
                List<CustomerOrder> productsearchlist = new List<CustomerOrder>();
                string tid = tb_search.Text;
                string queryStr = "SELECT *from customer_order o inner join companies c on c.company_id = o.company_id where company_namelike '%" + tid + "%' and o.is_archived = 'True'";
                productsearchlist = co.getallthree(queryStr);
                if (productsearchlist.Count == 0)
                {
                    lbl_search.Text = "There is no product when with that name";
                    this.gv_co.Visible = false;

                    if (String.IsNullOrEmpty(tb_search.Text))
                    {
                        this.gv_co.Visible = true;
                        lbl_search.Text = "";
                        BindGridView();
                    }
                }

                else
                {
                    lbl_search.Text = "";
                    gv_co.DataSource = productsearchlist;
                    gv_co.DataBind();
                }
            }
            else if (tb_search.Text.Length != 0 && ddl_sort.Text != "None")//sort and search
            {
                this.gv_co.Visible = true;
                List<CustomerOrder> productbothlist = new List<CustomerOrder>();
                string sid = ddl_sort.Text;
                string tid = tb_search.Text; ;
                string queryStr = "SELECT * from customer_order o inner join companies c on c.company_id = o.company_id  where company_name like '%" + tid + "%' and o.is_archived = 'True' order by " + sid;
                productbothlist = co.getallthree(queryStr); ;
                gv_co.DataSource = productbothlist;
                gv_co.DataBind();
            }

            else if (string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text == "None")//none
            {
                BindGridView();
            }
        }
    }
}