using Doosan.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace Doosan.e.Catalogue
{
    public partial class ProductUpdate : System.Web.UI.Page
    {
        Product prod = new Product();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lbl_id.Text = Request.QueryString["id"].ToString();
                bindListBox();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString);
                con.Open();
                string q = "Select product_id, product_name, unit_price, p.type_id, type_name, product_desc, product_image, insert_date from products p inner join product_type t on p.type_id = t.type_id where product_id = " + lbl_id.Text;


                SqlCommand query = new SqlCommand(q, con);
                SqlDataReader dr = query.ExecuteReader();

                if (dr.Read())
                {
                    tb_name.Text = dr["product_name"].ToString();
                    lbl_insert.Text = dr["insert_date"].ToString();
                    tb_desc.Text = dr["product_desc"].ToString();
                    tb_price.Text = dr["unit_price"].ToString();
                    //ddl_type.Text = dr["type_name"].ToString();
                    byte[] bytes = (byte[])dr["product_image"];
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    image.ImageUrl = "data:image/png;base64," + base64String;
                    //image.ImageUrl = "~\\assets\\img\\" + dr["product_image"].ToString();
                    ddl_type.SelectedValue = dr["type_id"].ToString();

                }
                con.Close();
            }
        }
        private void bindListBox()
        {

            ddl_type.DataSource = getReader();
            // Name will be displayed in the dropdownlist control
            ddl_type.DataTextField = "type_name";
            // when an item is selected in dropdownlist
            // CategoryID will be returned in ddlCategory.SelectedValue
            ddl_type.DataValueField = "type_id";
            ddl_type.DataBind();

        }

        private SqlDataReader getReader()
        {
            //get connection string from web.config
            string strConnectionString =
                ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT type_id, type_name  from product_type";

            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            // CommandBehavior.CloseConnection will automatically close connection
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }

        protected void btn_archive_Click(object sender, EventArgs e)
        {
            int result = 0;
            int id = int.Parse(lbl_id.Text);
            result = prod.ProductDelete(id);

            if (result > 0)
            {
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Product has been archived successfully');window.location ='Products.aspx';",
                      true);
            }
            else
            {
                //lbl_result.Text = "User removal NOT successfully";
                ScriptManager.RegisterStartupScript
                      (this, this.GetType(),
                      "alert",
                      "alert('Product removal NOT successful');window.location ='Products.aspx';",
                      true);
            }
        }


        protected void btn_update_Click(object sender, EventArgs e)
        {
            int result = 0;

            string image = "";
            int update_history_id = 1;

            if (FileUpload.HasFile)
            {
                HttpPostedFile postedFile = FileUpload.PostedFile;
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                result = prod.ProductUpdateImage(int.Parse(lbl_id.Text), tb_name.Text, tb_desc.Text, decimal.Parse(tb_price.Text), bytes, update_history_id, int.Parse(ddl_type.Text));
                if (result > 0)
                {

                    Response.Write("<script language='javascript'>window.alert('Update Successful');window.location='Products.aspx';</script>");

                    //ScriptManager.RegisterStartupScript
                           //(this, this.GetType(),
                           //"alert",
                           //"alert('Product Edited');window.location ='ProductCatalogue.aspx';",
                           //true);
                    //Response.Redirect("Customer(Admin).aspx");
                }
                else
                {
                    //lbl_result.Text = "User update NOT successful";
                    Response.Write("<script>alert('Product update NOT successful');</script>");
                }
            }
            else
            {
                result = prod.ProductUpdate(int.Parse(lbl_id.Text), tb_name.Text, tb_desc.Text, decimal.Parse(tb_price.Text), update_history_id, int.Parse(ddl_type.SelectedValue));
                if (result > 0)
                {
                    Response.Write("<script language='javascript'>window.alert('Update Successful');window.location='Products.aspx';</script>");

                    //ScriptManager.RegisterStartupScript
                           //(this, this.GetType(),
                           //"alert",
                           //"alert('Customer Edited');window.location ='ProductCatalogue.aspx';",
                           //true);
                    //Response.Redirect("Customer(Admin).aspx");
                }
                else
                {
                    //lbl_result.Text = "User update NOT successful";
                    Response.Write("<script>alert('User update NOT successful');</script>");
                }
            }
        }
    }
}