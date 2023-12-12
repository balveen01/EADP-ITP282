using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doosan.models;
using Doosan.BLL;
using System.Data;


namespace Doosan.e.Finance
{
    public partial class ViewPayment : System.Web.UI.Page
    {
        Payment aPay = new Payment();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            /*List<Payment> paymentList = new List<Payment>();
            paymentList = aPay.getAllPayment();
            gv_Payment.DataSource = paymentList;
            gv_Payment.DataBind();*/

            BllPayment payment = new BllPayment();
            DataSet ds;

            ds = payment.GetPayment();
            gv_Payment.DataSource = ds;
            gv_Payment.DataBind();
        }
        protected void gv_Payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_Payment.SelectedRow;
            string id = row.Cells[0].Text;
            Response.Redirect("PaymentDetail.aspx?id=" + id);
        }

        protected void gv_Payment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            PaymentModel pay = new PaymentModel();
            string payment_id = gv_Payment.DataKeys[e.RowIndex].Value.ToString();
            result = pay.PaymentDelete(payment_id);
            if (result > 0)
            {
                Response.Write("<script>alert('Product remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product Removal NOT successfully');</script>");
            }
            Response.Redirect("ViewPayment.aspx");
        }

        //protected void btn_search_Click(object sender, EventArgs e)
        //{
        //    this.gv_Payment.Visible = true;
        //    List<Payment> paymentsearchlist = new List<Payment>();
        //    string desc = tb_search.Text;
        //    paymentsearchlist = aPay.PaymentSearch(desc);
        //    if (paymentsearchlist.Count == 0)
        //    {
        //        lbl_search.Text = "Results not found";
        //        this.gv_Payment.Visible = false;

        //        if (String.IsNullOrEmpty(tb_search.Text))
        //        {
        //            this.gv_Payment.Visible = true;
        //            lbl_search.Text = "";
        //            List<Payment> paymentlist = new List<Payment>();
        //            paymentlist = aPay.getAllPayment();
        //            gv_Payment.DataSource = paymentlist;
        //            gv_Payment.DataBind();
        //        }
        //    }

        //    else
         //   {
         //       this.gv_Payment.Visible = true;
         //       lbl_search.Text = "";
          //      gv_Payment.DataSource = paymentsearchlist;
         //       gv_Payment.DataBind();
   //         }
   //     }





        //protected void rb_filter_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string stat = null;
        //    if (rb_filter.SelectedValue == "True")
        //    {
        //        stat = rb_filter.SelectedValue; //Add value into the query 

        //    }
        //    else
        //    {
        //        stat = rb_filter.SelectedValue;
        //    }

        //    List<Payment> filterlist = new List<Payment>();
        //    filterlist = aPay.PaymentFilter(stat);
        //    gv_Payment.DataSourceID = null;
        //    gv_Payment.DataSource = filterlist;
        //    gv_Payment.DataBind();
        //}

        //protected void rb_sort_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rb_sort.SelectedValue == "False")
        //    {
        //        List<Payment> filterlist = new List<Payment>();
        //        filterlist = aPay.PaymentSortPrice();
        //        gv_Payment.DataSourceID = null;
        //        gv_Payment.DataSource = filterlist;
        //        gv_Payment.DataBind();
        //    }
        //    else
        //    {
        //        List<Payment> filterlist = new List<Payment>();
        //        filterlist = aPay.PaymentSortExpiryDate();
        //        gv_Payment.DataSourceID = null;
        //        gv_Payment.DataSource = filterlist;
        //        gv_Payment.DataBind();
        //    }
        //}

       
    }
}