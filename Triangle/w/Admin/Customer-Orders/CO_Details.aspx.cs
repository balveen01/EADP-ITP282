using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;

namespace Triangle.w.Admin.Customer_Orders
{
    public partial class CO_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }

        protected void bind()
        {
            string id = Request.QueryString["id"];
            BCOrders orderModel = new BCOrders();
            DataSet ds = orderModel.GetBCOrder(id);
            gv_CO.DataSource = ds;
            gv_CO.DataBind();

            lbl_ID.Text = id;
            lbl_Date.Text = ds.Tables[0].Rows[0][1].ToString();
            lbl_Total_Price.Text = "$" + ds.Tables[0].Rows[0][2].ToString();
        }
    }
}