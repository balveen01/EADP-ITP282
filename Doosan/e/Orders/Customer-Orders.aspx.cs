using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.models;
using Doosan.BLL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace Doosan.w.Orders
{
    public partial class Customer_Orders : System.Web.UI.Page
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
        private void BindGridView()
        {
            List<CustomerOrder> customerorder = new List<CustomerOrder>();
            customerorder = co.getACOall();
            gv_co.DataSource = customerorder;
            gv_co.DataBind();
        }


        protected void gv_po_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_co.SelectedRow;

            Response.Redirect("CODetails.aspx?id=" + gr.Cells[0].Text);
        }

        protected void gv_po_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_co.PageIndex = newPageIndex;
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
                this.gv_co.Visible = true;
                List<CustomerOrder> productsortlist = new List<CustomerOrder>();
                string tid = ddl_sort.Text;
                string queryStr = "SELECT *from customer_order o inner join companies c on c.company_id = o.company_id where o.is_archived = 'False' order by " + tid;
                productsortlist = co.getallthree(queryStr);
                gv_co.DataSource = productsortlist;
                gv_co.DataBind();
            }
            else if (ddl_sort.Text == "None" && tb_search.Text.Length != 0)//to search
            {
                this.gv_co.Visible = true;
                List<CustomerOrder> productsearchlist = new List<CustomerOrder>();
                string tid = tb_search.Text;
                string queryStr = "SELECT *from customer_order o inner join companies c on c.company_id = o.company_id where company_namelike '%" + tid + "%' and o.is_archived = 'False'";
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
                string queryStr = "SELECT * from customer_order o inner join companies c on c.company_id = o.company_id  where company_name like '%" + tid + "%' and o.is_archived = 'False' order by " + sid;
                productbothlist = co.getallthree(queryStr); ;
                gv_co.DataSource = productbothlist;
                gv_co.DataBind();
            }

            else if (string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text == "None")//none
            {
                BindGridView();
            }
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;
            con.ConnectionString = path;
            DataTable dtnew = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("select o.order_id,order_item_id,total_price, order_date,is_approved,company_name,poid_ref,product_name,quantity from customer_order o inner join customer_order_item c on c.order_id = o.order_id inner join products p on c.product_id = p.product_id inner join companies com on com.company_id = o.company_id", con);
            adp.Fill(dtnew);

            if (dtnew.Rows.Count > 0)
            {
                string filpath = Server.MapPath("~/excel/ExcelExportFile.xlsx");
                FileInfo Files = new FileInfo(filpath);
                ExcelPackage excel = new ExcelPackage(Files);
                var sheetcreate =  excel.Workbook.Worksheets.Add("customer_order" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                for (int i = 0; i < dtnew.Columns.Count; i++)
                {
                    sheetcreate.Cells[1, i + 1].Value = dtnew.Columns[i].ColumnName.ToString();
                }

                for(int i = 0; i<dtnew.Rows.Count; i++)
                {
                    for (int j=0; j<dtnew.Columns.Count; j++)
                    {
                        sheetcreate.Cells[i + 2, j + 1].Value = dtnew.Rows[i][j].ToString();
                    }
                }
                excel.Save();

                byte[] content = File.ReadAllBytes(filpath);
                HttpContext context = HttpContext.Current;

                context.Response.BinaryWrite(content);
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=CustomerOrder.xlsx");
                Context.Response.End();
            }
        }
    }
}