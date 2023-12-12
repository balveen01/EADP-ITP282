using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Triangle.assets.mp
{
    public partial class POrdersMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
            con.Open();
            string q = "SELECT * from purchase_orders p where p.is_archived = 'False' and is_com_declined = 'True' ";


            SqlCommand query = new SqlCommand(q, con);
            SqlDataReader dr = query.ExecuteReader();

            string total = null;
            int count = 0;
            while (dr.Read())
            {
                total = dr["is_com_declined"].ToString();
                count += 1;
            }
            lbl_reject.Text = "(" + count.ToString() + ")" ;

            con.Close();
        }

        protected void lbtn_PO_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Purchase-Orders/View.aspx");
        }

        protected void lbtn_DO_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Delivery/Deliveries.aspx");
        }


        protected void lbtn_raise_po_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Purchase-Orders/RaisePO.aspx");
        }

        protected void lbtn_approve_po_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Purchase-Orders/ViewApprovePO.aspx");
        }

        protected void lbtn_Accounts_Archived_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Purchase-Orders/ArcPO.aspx");
        }

        protected void lbtn_Status_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Admin/Purchase-Orders/PoReject.aspx");
        }
    }
}