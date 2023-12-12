using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.BLL;
using Doosan.models;
using System.Data;

namespace Doosan.w.Purchase_Orders
{
    public partial class Purchase_Orders : System.Web.UI.Page
    {
        CustomerOrder cust = new CustomerOrder();
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
            CO myCat = new CO();
            DataSet ds;
            ds = myCat.getPOList();
            gv_po.DataSource = ds.Tables[0].DefaultView;
            gv_po.DataBind();
        }
        protected void gv_po_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_po.PageIndex = newPageIndex;
            BindGridView();
        }
        protected void gv_po_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_po.SelectedRow;

            Response.Redirect("Create-Customer-Order.aspx?id=" + gr.Cells[0].Text);
        }



        protected void gv_po_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow gr = gv_po.SelectedRow;

            Response.Redirect("PoDetail.aspx?id=" + gv_po.DataKeys[e.RowIndex].Value);
        }

        protected void gv_po_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CO myCat = new CO();
            DataSet ds1;
            //ds1 = myCat.getPOList();
            //string approve = ds1.Tables[0].Rows[0]["is_supp_approved"].ToString();
            //string declined = ds1.Tables[0].Rows[0]["is_supp_declined"].ToString();
            int no = -1;
            foreach (GridViewRow row in gv_po.Rows)
            {
                no += 1;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    ds1 = myCat.getPODetails(Convert.ToInt32(gv_po.Rows[no].Cells[0].Text));
                    string approve = ds1.Tables[0].Rows[0]["is_supp_approved"].ToString();
                    string declined = ds1.Tables[0].Rows[0]["is_supp_declined"].ToString();
                    if (approve == "True" && declined == "False")
                    {
                        gv_po.Rows[no].Cells[3].Text = "Approved";
                    }
                    else if (approve == "False" && declined == "True")
                    {
                        gv_po.Rows[no].Cells[3].Text = "Declined";
                    }
                    else if (approve == "False" && declined == "False")
                    {
                        gv_po.Rows[no].Cells[3].Text = "Pending";
                    }
                }
            }

        }
    }
}