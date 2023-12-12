using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.BLL;
using Doosan.models;
using System.Data;

namespace Doosan.e.Delivery
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getDelivery();
            }
        }

        protected void getDelivery()
        {
            DeliveryBLL delivery = new DeliveryBLL();
            DataSet deliveryDetails = new DataSet();

            try
            {
                string order_ID = Request.QueryString["oid"];
                string delivery_ID = Request.QueryString["id"];

                if (delivery_ID != null)
                {
                    deliveryDetails = delivery.getDeliveryFullDetails(Convert.ToInt32(delivery_ID));
                }
                else
                {
                    deliveryDetails = delivery.getDeliveryFullDetailsOrderId(Convert.ToInt32(order_ID));
                }
            }
            catch
            {

            }

            decimal delivery_cost, goods_cost = 0;
            bool delivered, approved, packed;
            string approvedDate, packedDate, deliveryDate;

            lbl_ID.Text = deliveryDetails.Tables[0].Rows[0]["delivery_id"].ToString();
            lbl_OrderID.Text = deliveryDetails.Tables[0].Rows[0]["order_id"].ToString();
            tb_deliveryAddress.Text = deliveryDetails.Tables[0].Rows[0]["delivery_address"].ToString();
            tb_companyAddress.Text = deliveryDetails.Tables[0].Rows[0]["company_address"].ToString();
            tb_companyName.Text = deliveryDetails.Tables[0].Rows[0]["company_name"].ToString();
            lbl_Order_Date.Text = deliveryDetails.Tables[0].Rows[0]["order_date"].ToString();

            alinkOrders.HRef = $"/e/Orders/CODetails.aspx?id={lbl_OrderID.Text}";


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
                lbl_deliveryDate.Text = deliveryDate;

            delivery_cost = Convert.ToDecimal(deliveryDetails.Tables[0].Rows[0]["total_price"].ToString());
            goods_cost = Convert.ToDecimal(deliveryDetails.Tables[0].Rows[0]["delivery_cost"].ToString());

            tb_deliveryCost.Text = delivery_cost.ToString();
            tb_goodsPrice.Text = goods_cost.ToString();
            tb_totalCost.Text = (goods_cost + delivery_cost).ToString();

            approved = Convert.ToBoolean(deliveryDetails.Tables[0].Rows[0]["is_approved"].ToString());
            packed = Convert.ToBoolean(deliveryDetails.Tables[0].Rows[0]["is_packed"].ToString());
            delivered = Convert.ToBoolean(deliveryDetails.Tables[0].Rows[0]["is_delivered"].ToString());

            tb_deliveryAddress.ReadOnly = approved;
            tb_deliveryCost.ReadOnly = approved;
            btn_Approve.Visible = !approved;
            btn_reverseApprove.Visible = approved;

            btn_d_approved.Visible = approved;
            btn_d_not_approved.Visible = !approved;
            btn_p_complete.Visible = packed;
            btn_p_incomplete.Visible = !packed;
            btn_d_recieved.Visible = delivered;
            btn_d_not_recieved.Visible = !delivered;
        }

        protected void btn_d_approved_Click(object sender, EventArgs e)
        {
            string delivery_ID = Request.QueryString["id"];
            if (!DeliveryStatus.CheckIsPacked(delivery_ID) && !DeliveryStatus.CheckIsDelivered(delivery_ID))
            {
                DeliveryStatus.SetIsNotApproved(delivery_ID);
                Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                Response.Write("<script>alert('ERROR: You are not allowed to revert the previous statuses.');</script>");
            }

        }

        protected void btn_d_not_approved_Click(object sender, EventArgs e)
        {
            string delivery_ID = Request.QueryString["id"];
            if (!DeliveryStatus.CheckIsPacked(delivery_ID) && !DeliveryStatus.CheckIsDelivered(delivery_ID))
            {
                DeliveryStatus.SetIsApproved(delivery_ID);
                Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                Response.Write("<script>alert('ERROR: You are not allowed to edit the future statuses.');</script>");
            }
        }

        protected void btn_p_complete_Click(object sender, EventArgs e)
        {
            string delivery_ID = Request.QueryString["id"];
            if (!DeliveryStatus.CheckIsDelivered(delivery_ID))
            {
                DeliveryStatus.SetIsNotPacked(delivery_ID);
                Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                Response.Write("<script>alert('ERROR: You are not allowed to revert the previous statuses.');</script>");
            }
        }

        protected void btn_p_incomplete_Click(object sender, EventArgs e)
        {
            string delivery_ID = Request.QueryString["id"];
            if (DeliveryStatus.CheckIsApproved(delivery_ID))
            {
                DeliveryStatus.SetIsPacked(delivery_ID);
                Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                Response.Write("<script>alert('ERROR: You are not allowed to edit the future statuses.');</script>");
            }
        }

        protected void btn_d_recieved_Click(object sender, EventArgs e)
        {
            string delivery_ID = Request.QueryString["id"];
            if (DeliveryStatus.CheckIsApproved(delivery_ID) && DeliveryStatus.CheckIsPacked(delivery_ID))
            {
                DeliveryStatus.SetIsNotDelivered(delivery_ID);
                Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                Response.Write("<script>alert('ERROR: You are not allowed to revert the previous statuses.');</script>");
            }
        }

        protected void btn_d_not_recieved_Click(object sender, EventArgs e)
        {
            string delivery_ID = Request.QueryString["id"];
            if (DeliveryStatus.CheckIsApproved(delivery_ID) && DeliveryStatus.CheckIsPacked(delivery_ID))
            {
                DeliveryStatus.SetIsDelivered(delivery_ID);
                Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                Response.Write("<script>alert('ERROR: You are not allowed to edit the future statuses.');</script>");
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/e/Delivery/View.aspx");
        }
    }
}