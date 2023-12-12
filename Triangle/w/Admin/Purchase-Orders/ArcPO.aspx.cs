using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.BLL;
using Triangle.models;

namespace Triangle.w.Admin.Purchase_Orders
{
    public partial class ArcPO : System.Web.UI.Page
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

        protected void gv_po_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int result1 = 0;
            int id = int.Parse(gv_po.DataKeys[e.RowIndex].Value.ToString());
            //int id = int.Parse(gv_po.DataKeys[e.RowIndex].Value.ToString());
            result = po.poiUnarchieve(id);
            result1 = po.poUnarchieve(id);

            if (result > 0 && result1 >0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Purchase Order has been unarchived successfully');window.location ='ArcPO.aspx';",true);
                //Response.Write("Purchase Order has been unarchived successfully");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('NOT successful');window.location ='ArcCat.aspx';",true);
                //Response.Write("NOT successful");
            }
        }

        protected void gv_po_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int newPageIndex = e.NewPageIndex;
            gv_po.PageIndex = newPageIndex;
            BindGridView();
        }

        private void BindGridView()
        {
            List<PurchaseOrder> categorylist = new List<PurchaseOrder>();
            categorylist = po.getArcPOall();
            gv_po.DataSource = categorylist;
            gv_po.DataBind();


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
                    string q = "SELECT * from purchase_orders p where p.is_archived = 'True' and supplier_id = 1 and order_id = " + Convert.ToInt32(gv_po.Rows[no].Cells[0].Text) + " order by p.order_id";


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
                        gv_po.Rows[no].Cells[3].Text = "Approved";
                    }
                    else if (capprove == "False" && cdeclined == "True")
                    {
                        gv_po.Rows[no].Cells[3].Text = "Declined";
                    }
                    else if (capprove == "False" && cdeclined == "False")
                    {
                        gv_po.Rows[no].Cells[3].Text = "Pending";
                    }

                    //string approve = ds1.Tables[0].Rows[0]["is_supp_approved"].ToString();
                    //string declined = ds1.Tables[0].Rows[0]["is_supp_declined"].ToString();
                    if (approve == "True" && declined == "False")
                    {
                        gv_po.Rows[no].Cells[4].Text = "Approved";
                    }
                    else if (approve == "False" && declined == "True")
                    {
                        gv_po.Rows[no].Cells[4].Text = "Declined";
                    }
                    else if (approve == "False" && declined == "False")
                    {
                        gv_po.Rows[no].Cells[4].Text = "Pending";
                    }

                }
            }

        }


    }
}