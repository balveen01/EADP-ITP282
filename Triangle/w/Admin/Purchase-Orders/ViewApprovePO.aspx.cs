using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;
using Triangle.BLL;

namespace Triangle.w.Admin.Purchase_Orders
{
    public partial class ViewApprovePO : System.Web.UI.Page
    {
        PurchaseOrder po = new PurchaseOrder();
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
            List<PurchaseOrder> productlist = new List<PurchaseOrder>();
            productlist = po.getAPOall();
            gv_po.DataSource = productlist;
            gv_po.DataBind();
        }


        protected void gv_po_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_po.SelectedRow;

            Response.Redirect("ApprovePO.aspx?id=" + gr.Cells[0].Text);
        }

        protected void gv_po_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_po.PageIndex = newPageIndex;
            allthree();
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
            if (string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text != "None") //to sort
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productsortlist = new List<PurchaseOrder>();
                string tid = ddl_sort.Text;
                string queryStr = "SELECT *from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where p.is_archived = 'False' and is_com_approved = 'False' order by " + tid;
                productsortlist = po.getallthree(queryStr);
                gv_po.DataSource = productsortlist;
                gv_po.DataBind();
            }
            else if (ddl_sort.Text == "None" && tb_search.Text.Length != 0)//to search
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productsearchlist = new List<PurchaseOrder>();
                string tid = tb_search.Text;
                string queryStr = "SELECT *, supplier_name from purchase_orders o inner join suppliers s on  s.supplier_id = o.supplier_id where s.supplier_name like '%" + tid + "%' and o.is_archived = 'False' and is_com_approved = 'False'";
                productsearchlist = po.getallthree(queryStr);
                if (productsearchlist.Count == 0)
                {
                    lbl_search.Text = "There is no product with that name";
                    this.gv_po.Visible = false;

                    if (String.IsNullOrEmpty(tb_search.Text))
                    {
                        this.gv_po.Visible = true;
                        lbl_search.Text = "";
                        BindGridView();
                    }
                }

                else
                {
                    lbl_search.Text = "";
                    gv_po.DataSource = productsearchlist;
                    gv_po.DataBind();
                }
            }
            else if (tb_search.Text.Length != 0 && ddl_sort.Text != "None")//sort and search
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productbothlist = new List<PurchaseOrder>();
                string sid = ddl_sort.Text;
                string tid = tb_search.Text;
                string queryStr = "SELECT * from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id  where supplier_name like '%" + tid + "%' and p.is_archived = 'False' and is_com_approved = 'False' order by " + sid;
                productbothlist = po.getallthree(queryStr);
                gv_po.DataSource = productbothlist;
                gv_po.DataBind();
            }
            else if (string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text == "None")//none
            {
                BindGridView();
            }
        }
    }
}