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
    public partial class Deliveries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDelivery();
        }

        protected void LoadDelivery()
        {
            string delivery_ID = Request.QueryString["id"];
            decimal delivery_cost, goods_cost = 0;
            bool delivered, approved, packed;
            string approvedDate, packedDate, deliveryDate;

            DeliveryBLL delivery = new DeliveryBLL();
            DataSet deliveryDetails = new DataSet();
            deliveryDetails = delivery.getDeliveryFullDetails(Convert.ToInt32(delivery_ID));

            //alinkOrders.HRef = "../Purchase-Orders/PODetails.aspx";
            //tb_Order_ID.Text = deliveryDetails.Tables[0].Rows[0]["order_id"].ToString();
            tb_deliveryAddress.Text = deliveryDetails.Tables[0].Rows[0]["delivery_address"].ToString();
            tb_companyAddress.Text = deliveryDetails.Tables[0].Rows[0]["company_address"].ToString();



            approvedDate = deliveryDetails.Tables[0].Rows[0]["approved_date"].ToString();
            if (approvedDate == "")
                lbl_approvedDate.Text = "Not Approved Yet";
            else
                lbl_approvedDate.Text = approvedDate;

            packedDate = deliveryDetails.Tables[0].Rows[0]["packing_date"].ToString();
            if (packedDate == "")
                lbl_packingDate.Text = "Not Packed Yet";
            else
                lbl_packingDate.Text = packedDate;

            deliveryDate = deliveryDetails.Tables[0].Rows[0]["deliver_date"].ToString();
            if (deliveryDate == "")
                lbl_deliveryDate.Text = "Not Delivery Yet";
            else
                lbl_deliveryDate.Text = packedDate;

            delivery_cost = Convert.ToDecimal(deliveryDetails.Tables[0].Rows[0]["total_price"].ToString());
            goods_cost = Convert.ToDecimal(deliveryDetails.Tables[0].Rows[0]["delivery_cost"].ToString());

            tb_deliveryCost.Text = delivery_cost.ToString();
            tb_goodsPrice.Text = goods_cost.ToString();
            tb_totalCost.Text = (goods_cost + delivery_cost).ToString();

            approved = Convert.ToBoolean(deliveryDetails.Tables[0].Rows[0]["is_approved"].ToString());
            packed = Convert.ToBoolean(deliveryDetails.Tables[0].Rows[0]["is_packed"].ToString());
            delivered = Convert.ToBoolean(deliveryDetails.Tables[0].Rows[0]["is_delivered"].ToString());

            d_approved.Visible = approved;
            d_not_approved.Visible = !approved;
            p_complete.Visible = packed;
            p_incomplete.Visible = !packed;
            d_recieved.Visible = delivered;
            btn_d_not_recieved.Visible = !delivered;
        }

        protected void btn_d_not_recieved_Click(object sender, EventArgs e)
        {
            DeliveryBLL delivery = new DeliveryBLL();
                string delivery_ID = Request.QueryString["id"];

            if (p_complete.Visible == false || d_approved.Visible == false)
            {
                Response.Write("<script>alert('You are unable to do this action.');</script>");
            }
            else
            {
                int result = delivery.ChangeDeliveryStatusDelivered(delivery_ID);
                if (result > 0)
                {
                    Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }

            // Balveen
            DataSet dataset = new DataSet();
            DataSet deliveryDetails = new DataSet();
            deliveryDetails = delivery.getDeliveryFullDetails(Convert.ToInt32(delivery_ID));
            string poid = deliveryDetails.Tables[0].Rows[0]["poid_ref"].ToString();
            dataset = getproductqty(poid);
            foreach (DataTable table in dataset.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    Product prod = new Product();
                    int result = prod.IncreaseProductStock(Convert.ToInt32(row[0]), Convert.ToInt32(row[2]));
                }
            }
        }

        public DataSet getproductqty(string poid)
        {
            // Balveen
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString);
            DataSet product = new DataSet();
            string q = "SELECT DISTINCT(o.product_id) 'ID', p.product_name 'Product Name',  SUM(o.quantity) 'Amount'  FROM purchase_order_item o INNER JOIN products p on p.product_id = o.product_id WHERE o.order_id =" + poid + " GROUP BY p.product_name, o.product_id ORDER BY o.product_id asc";

            try
            {
                using (con)
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(q, con))
                    {
                        da.Fill(product);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return product;
        }
    }
}