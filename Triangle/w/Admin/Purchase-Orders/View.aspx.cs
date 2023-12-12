using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;
using Triangle.BLL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using OfficeOpenXml;

namespace Triangle.w.Admin.Purchase_Orders
{
    public partial class View : System.Web.UI.Page
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
            productlist = po.getPOall();
            gv_po.DataSource = productlist;
            gv_po.DataBind();
        }


        protected void gv_po_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gv_po.SelectedRow;

            Response.Redirect("PoDetails.aspx?id=" + gr.Cells[0].Text);
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
            if (ddl_filter.Text == "None" && string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text != "None") //to sort
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productsortlist = new List<PurchaseOrder>();
                string tid = ddl_sort.Text;
                string queryStr = "SELECT *from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where p.is_archived = 'False' order by " + tid;
                productsortlist = po.getallthree(queryStr);
                gv_po.DataSource = productsortlist;
                gv_po.DataBind();
            }
            else if (ddl_sort.Text == "None" && string.IsNullOrEmpty(tb_search.Text) && ddl_filter.Text != "None")//to filter
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productsortlist = new List<PurchaseOrder>();
                string tid = ddl_filter.Text;
                string queryStr = "SELECT *from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where p.is_archived = 'False' and " + tid;
                productsortlist = po.getallthree(queryStr);
                gv_po.DataSource = productsortlist;
                gv_po.DataBind();
                this.gv_po.Visible = true;
            }
            else if (ddl_filter.Text == "None" && ddl_sort.Text == "None" && tb_search.Text.Length != 0)//to search
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productsearchlist = new List<PurchaseOrder>();
                string tid = tb_search.Text;
                string queryStr = "SELECT *from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where s.supplier_name like '%" + tid + "%' and p.is_archived = 'False'";
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
            else if (ddl_filter.Text == "None" && tb_search.Text.Length != 0 && ddl_sort.Text != "None")//sort and search
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productbothlist = new List<PurchaseOrder>();
                string sid = ddl_sort.Text;
                string tid = tb_search.Text; ;
                string queryStr = "SELECT * from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where s.supplier_name like '%" + tid + "%' and p.is_archived = 'False' order by " + sid;
                productbothlist = po.getallthree(queryStr);
                gv_po.DataSource = productbothlist;
                gv_po.DataBind();
            }
            else if (ddl_sort.Text == "None" && tb_search.Text.Length != 0 && ddl_filter.Text != "None")//filter and search
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productbothlist = new List<PurchaseOrder>();
                string tid = tb_search.Text;
                string fid = ddl_filter.Text;
                string queryStr = "SELECT * from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where s.supplier_name like '%" + tid + "%' and p.is_archived = 'False' and " + fid;
                productbothlist = po.getallthree(queryStr);
                gv_po.DataSource = productbothlist;
                gv_po.DataBind();
            }
            else if (string.IsNullOrEmpty(tb_search.Text) && ddl_filter.Text != "None" && ddl_sort.Text != "None")//filter and sort
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productbothlist = new List<PurchaseOrder>();
                string sid = ddl_sort.Text;
                string fid = ddl_filter.Text;
                string queryStr = "SELECT * from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where p.is_archived = 'False' and " + fid + " order by " + sid;
                productbothlist = po.getallthree(queryStr);
                gv_po.DataSource = productbothlist;
                gv_po.DataBind();
            }
            else if (ddl_filter.Text == "None" && string.IsNullOrEmpty(tb_search.Text) && ddl_sort.Text == "None")//none
            {
                BindGridView();
            }
            else // for all 
            {
                this.gv_po.Visible = true;
                List<PurchaseOrder> productbothlist = new List<PurchaseOrder>();
                string sid = ddl_sort.Text;
                string tid = tb_search.Text;
                string fid = ddl_filter.Text;
                string queryStr = "SELECT * from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where s.supplier_name like '%" + tid + "%' and p.is_archived = 'False' and " + fid + " order by " + sid;
                productbothlist = po.getallthree(queryStr);
                gv_po.DataSource = productbothlist;
                gv_po.DataBind();
            }
        }

        protected void gv_po_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //po myCat = new CO();
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
                    //ds1 = po.WSgetPO(Convert.ToInt32(gv_po.Rows[no].Cells[0].Text));





                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
                    con.Open();
                    string q = "SELECT * from purchase_orders p where p.is_archived = 'False' and supplier_id = 1 and order_id = " + Convert.ToInt32(gv_po.Rows[no].Cells[0].Text) + " order by p.order_id";


                    SqlCommand query = new SqlCommand(q, con);
                    SqlDataReader dr = query.ExecuteReader();
                    string approve = null;
                    string declined = null;
                    string cdeclined = null;
                    string capprove = null;
                    if (dr.Read())
                    {
                        approve = dr["is_supp_approved"].ToString();
                        declined = dr["is_supp_declined"].ToString();
                        capprove = dr["is_com_approved"].ToString();
                        cdeclined = dr["is_com_declined"].ToString();
                    }

                    con.Close();



                    //string declined = ds1.Tables[0].Rows[0]["is_supp_declined"].ToString();
                    if (capprove == "True" && cdeclined == "False")
                    {
                        gv_po.Rows[no].Cells[4].Text = "Approved";
                    }
                    else if (capprove == "False" && cdeclined == "True")
                    {
                        gv_po.Rows[no].Cells[4].Text = "Declined";
                    }
                    else if (capprove == "False" && cdeclined == "False")
                    {
                        gv_po.Rows[no].Cells[4].Text = "Pending";
                    }

                    //string approve = ds1.Tables[0].Rows[0]["is_supp_approved"].ToString();
                    //string declined = ds1.Tables[0].Rows[0]["is_supp_declined"].ToString();
                    if (approve == "True" && declined == "False")
                    {
                        gv_po.Rows[no].Cells[5].Text = "Approved";
                    }
                    else if (approve == "False" && declined == "True")
                    {
                        gv_po.Rows[no].Cells[5].Text = "Declined";
                    }
                    else if (approve == "False" && declined == "False")
                    {
                        gv_po.Rows[no].Cells[5].Text = "Pending";
                    }

                }
            }

        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;
            con.ConnectionString = path;
            DataTable dtnew = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("select o.order_id,order_item_id,total_price, order_date,supplier_name,product_name,quantity from purchase_orders o inner join purchase_order_item c on c.order_id = o.order_id inner join products p on c.product_id = p.product_id inner join suppliers com on com.supplier_id = o.supplier_id", con);
            adp.Fill(dtnew);

            if (dtnew.Rows.Count > 0)
            {
                string filpath = Server.MapPath("~/excel/ExcelExportFile.xlsx");
                //string fileName = Path.Combine(Server.MapPath("~/excel"), DateTime.Now.ToString("ddMMyyyyhhmmss") + ".xlsx");

                FileInfo Files = new FileInfo(filpath);
                ExcelPackage excel = new ExcelPackage(Files);
                var sheetcreate = excel.Workbook.Worksheets.Add("purchase_order" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));

                for (int i = 0; i < dtnew.Columns.Count; i++)
                {
                    sheetcreate.Cells[1, i + 1].Value = dtnew.Columns[i].ColumnName.ToString();
                }

                for (int i = 0; i < dtnew.Rows.Count; i++)
                {
                    for (int j = 0; j < dtnew.Columns.Count; j++)
                    {
                        sheetcreate.Cells[i + 2, j + 1].Value = dtnew.Rows[i][j].ToString();
                    }
                }
                excel.Save();

                byte[] content = File.ReadAllBytes(filpath);
                HttpContext context = HttpContext.Current;

                context.Response.BinaryWrite(content);
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=PurchaseOrder.xlsx");
                Context.Response.End();
            }

        }
    }
}