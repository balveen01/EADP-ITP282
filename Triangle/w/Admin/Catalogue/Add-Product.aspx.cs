using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Triangle.BLL;
using Triangle.models;

namespace Triangle.w.Admin.Catalogue
{
    public partial class Add_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                bindListBox();
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
                ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT type_id, type_name  from product_type";

            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            // CommandBehavior.CloseConnection will automatically close connection
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";
            if (FileUpload.HasFile == true)
            {
                //image = "assets\\imag\\" + FileUpload.FileName;
            }
            //  Product prod = new Product(tb_ProductID.Text, tb_ProductName.Text, tb_ProductDesc.Text, decimal.Parse(tb_UnitPrice.Text), FileUpload1.FileName, int.Parse(tb_StockLevel.Text));
            int update_history_id = 1;

            HttpPostedFile postedFile = FileUpload.PostedFile;
            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

            Product prod = new Product();
            bool avaliable = false;
            if (Convert.ToInt32(tb_stock.Text) == 0)
            {
                avaliable = false;
            }
            else if (Convert.ToInt32(tb_stock.Text) >0 )
            {
                avaliable = true;
            }
            result = prod.ProductInsert(tb_name.Text, tb_desc.Text, decimal.Parse(tb_price.Text), bytes, update_history_id, int.Parse(ddl_type.Text), int.Parse(tb_stock.Text), int.Parse(tb_rop.Text), int.Parse(tb_qty.Text), 1, avaliable);
            if (result > 0)
            {
                //string saveimg = Server.MapPath(" ") + "\\" + image;
                //lbl_Result.Text = saveimg.ToString();
                //FileUpload.SaveAs(saveimg);
                Response.Write("<script language='javascript'>window.alert('Product Insert Successful');window.location='CProducts.aspx';</script>");
                // Response.Write("<sript>alert('Insert successful');</script>");
            }

            else
            {
                Response.Write("<sript>alert('Product Insert not successful');</script>");
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }

    }
}