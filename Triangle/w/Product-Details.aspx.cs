using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.models;

namespace Triangle
{
    public partial class Product_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindProduct();

                if (Session["Current_User"] == null || Session["Current_User"].ToString() == "")
                {
                    btn_Add.Visible = false;
                    btn_GoToSignIn.Visible = true;
                }
                else
                {
                    btn_Add.Visible = true;
                    btn_GoToSignIn.Visible = false;
                }
            }
        }

        protected void bindProduct()
        {
            string prodID = Request.QueryString["pid"].ToString();
            Product product = new Product();

            string queryString = "SELECT * FROM products WHERE product_id=@id";
            try
            {
                SqlConnection CONNECTION = SQLConnTriangle.GetConnection();
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@id", prodID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lbl_ProductName.Text = reader["product_name"].ToString();
                                lbl_ProductDesc.Text = reader["product_desc"].ToString();
                                lbl_Category.Text = reader["type_id"].ToString();
                                lbl_ReleaseDate.Text = reader["insert_date"].ToString();
                                lbl_ProductPrice.Text = reader["unit_price"].ToString();
                                Image1.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])reader["product_image"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_ProductName.Text = ex.Message;
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string prodID = Request.QueryString["pid"];
            Product product = new Product();
            product.getProduct(Convert.ToInt32(prodID));
            int stockLevel = ProductModel.GetStockOfProduct(prodID);
            if ((stockLevel - Convert.ToInt32(ddl_quantity.SelectedValue)) >= 0)
            {
                ConsumerShoppingCart.Instance.AddItem(prodID, lbl_ProductName.Text, Convert.ToDecimal(lbl_ProductPrice.Text), Convert.ToInt16(ddl_quantity.SelectedValue));
            }
            else
            {
                Response.Write("<script>alert('No more stock, please select a lower quantity.');</script>");
            }
        }

        protected void btn_GoToSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Sign-In.aspx");
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/w/Products.aspx");
        }
    }
}