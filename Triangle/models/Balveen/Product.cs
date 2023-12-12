using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Text;

namespace Triangle.models
{
    public class Product
    {
        string _connStr = ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;

        private string _product_name, _product_desc, _type_name, _type;
        private int _product_id, _update_history_id, _type_id, _stock_level, _rop, _rop_qty, _quantity, _order_item_id;
        private decimal _unit_price;
        private DateTime _insert_date;
        private bool _is_archived, _is_reordering, _is_over_rop;
        private byte[] _product_image;




        public Product(int product_id, string product_name, string product_desc, decimal unit_price, byte[] product_image, DateTime insert_date, int type_id, bool is_archived, string type_name, int stock_level, int rop, int rop_qty, bool is_reordering, bool is_over_rop, int update_history_id)
        {
            _product_id = product_id;
            _product_name = product_name;
            _product_desc = product_desc;
            _unit_price = unit_price;
            _product_image = product_image;
            _insert_date = insert_date;
            _update_history_id = update_history_id;
            _type_id = type_id;
            _is_archived = is_archived;
            _stock_level = stock_level;
            _is_over_rop = is_over_rop;
            _rop = rop;
            _rop_qty = rop_qty;
            _is_reordering = is_reordering;
            _type_name = type_name;
        }
        public Product(int product_id, string product_name, string product_desc, decimal unit_price, byte[] product_image, DateTime insert_date, int type_id, bool is_archived, string type_name, int stock_level, int rop, int rop_qty, bool is_reordering, bool is_over_rop, int quantity, int order_item_id, int update_history_id, string type)
        {
            _product_id = product_id;
            _product_name = product_name;
            _product_desc = product_desc;
            _unit_price = unit_price;
            _product_image = product_image;
            _insert_date = insert_date;
            _update_history_id = update_history_id;
            _type_id = type_id;
            _is_archived = is_archived;
            _stock_level = stock_level;
            _is_over_rop = is_over_rop;
            _rop = rop;
            _rop_qty = rop_qty;
            _is_reordering = is_reordering;
            _type_name = type_name;
            _quantity = quantity;
            _type = type;
            _order_item_id = order_item_id;
        }

        public Product(string product_name, string product_desc, decimal unit_price, byte[] product_image, DateTime insert_date, int type_id, bool is_archived, string type_name, int stock_level, int rop, int rop_qty, bool is_reordering, bool is_over_rop, int update_history_id, string type)
        {
            _product_id = product_id;
            _product_name = product_name;
            _product_desc = product_desc;
            _unit_price = unit_price;
            _product_image = product_image;
            _insert_date = insert_date;
            _update_history_id = update_history_id;
            _type_id = type_id;
            _is_archived = is_archived;
            _stock_level = stock_level;
            _is_over_rop = is_over_rop;
            _rop = rop;
            _rop_qty = rop_qty;
            _is_reordering = is_reordering;
            _type_name = type_name;
            _type = type;
        }

        public Product(string product_name, string product_desc, decimal unit_price, byte[] product_image, DateTime insert_date, int type_id, bool is_archived, int stock_level, int rop, int rop_qty, bool is_reordering, bool is_over_rop, int update_history_id, string type)
        {
            _product_id = product_id;
            _product_name = product_name;
            _product_desc = product_desc;
            _unit_price = unit_price;
            _product_image = product_image;
            _insert_date = insert_date;
            _update_history_id = update_history_id;
            _type_id = type_id;
            _is_archived = is_archived;
            _stock_level = stock_level;
            _is_over_rop = is_over_rop;
            _rop = rop;
            _rop_qty = rop_qty;
            _is_reordering = is_reordering;
            //_type_name = type_name;
            _type = type;
        }

        public Product(int product_id)
        {
            _product_id = product_id;
        }

        public Product()
        {
        }

        public int product_id
        {
            get { return _product_id; }
            set { _product_id = value; }
        }

        public int update_history_id
        {
            get { return _update_history_id; }
            set { _update_history_id = value; }
        }

        public int order_item_id
        {
            get { return _order_item_id; }
            set { _order_item_id = value; }
        }

        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string product_name
        {
            get { return _product_name; }
            set { _product_name = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string product_desc
        {
            get { return _product_desc; }
            set { _product_desc = value; }
        }

        public decimal unit_price
        {
            get { return _unit_price; }
            set { _unit_price = value; }
        }

        public byte[] product_image
        {
            get { return _product_image; }
            set { _product_image = value; }
        }

        public DateTime insert_date
        {
            get { return _insert_date; }
            set { _insert_date = value; }
        }


        public int stock_level
        {
            get { return _stock_level; }
            set { _stock_level = value; }
        }
        public int rop
        {
            get { return _rop; }
            set { _rop = value; }
        }
        public int rop_qty
        {
            get { return _rop_qty; }
            set { _rop_qty = value; }
        }

        public int type_id
        {
            get { return _type_id; }
            set { _type_id = value; }
        }
        public bool is_archived
        {
            get { return _is_archived; }
            set { _is_archived = value; }
        }
        public bool is_reordering
        {
            get { return _is_reordering; }
            set { _is_reordering = value; }
        }
        public bool is_over_rop
        {
            get { return _is_over_rop; }
            set { _is_over_rop = value; }
        }

        public string type_name
        {
            get { return _type_name; }
            set { _type_name = value; }
        }
        private String errMsg;
        public DataSet GetProducts()
        {
            DoosanWS.DoosanAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new DoosanWS.DoosanAPIClient();
            return betterBookSupplierClient.GetProducts();
        }

        public DataSet Alltheree(string tid)
        {
            //Product betterBookSupplierClient;
            //betterBookSupplierClient = new Product();
            //return betterBookSupplierClient.Alltheree(tid);
            DoosanWS.DoosanAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new DoosanWS.DoosanAPIClient();
            return betterBookSupplierClient.Allthree(tid);
        }

        public DataSet GetProductDetails(int id)
        {
            //Product betterBookSupplierClient;
            //betterBookSupplierClient = new Product();
            //return betterBookSupplierClient.GetProductDetails(id);
            DoosanWS.DoosanAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new DoosanWS.DoosanAPIClient();
            return betterBookSupplierClient.GetProductDetails(id);
        }

        //string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id inner join purchase_order_item o on o.product_id = p.product_id WHERE o.order_id = @id";
        public DataSet WsGetPOProd(int id)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id inner join purchase_order_item o on o.product_id = p.product_id WHERE o.order_id = " + id;
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@id", id);
            //conn.Open();


            try
            {
                da = new SqlDataAdapter(queryStr.ToString(), conn);
                //da.SelectCommand.Parameters.AddWithValue("@id", id);
                da.Fill(booksData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return booksData;
        }

        
        public Product getProduct(int id)
        {
            Product productinfo = null;

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id;
            decimal unit_price;
            byte[] product_image;
            DateTime insert_date;

            string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id WHERE product_id = @id";
            //string queryStr = "SELECT * FROM products WHERE product_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                type_name = dr["type_name"].ToString();
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_id = int.Parse(dr["type_id"].ToString());
                int stock_level = int.Parse(dr["stock_level"].ToString());

                productinfo = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, update_history_id);
            }
            else
            {
                productinfo = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productinfo;
        }
        


        public List<Product> checkcat(int id)
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id;
            decimal unit_price;
            byte[] product_image;
            DateTime insert_date;


            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id WHERE p.type_id= @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                rop = int.Parse(dr["rop"].ToString());
                rop_qty = int.Parse(dr["rop_qty"].ToString());
                stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                is_reordering = bool.Parse(dr["is_reordering"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, update_history_id);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }
        public List<Product> getProductAll()
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id, rop, rop_qty, stock_level;
            decimal unit_price;
            DateTime insert_date;
            bool is_archived, is_over_rop, is_reordering;
            byte[] product_image;


            string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' Order by product_id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                rop = int.Parse(dr["rop"].ToString());
                rop_qty = int.Parse(dr["rop_qty"].ToString());
                stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                is_reordering = bool.Parse(dr["is_reordering"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, update_history_id);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }



        public List<Product> getProductinfo(int id)
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name, type;
            int product_id, update_history_id, type_id, rop, rop_qty, stock_level, quantity, order_item_id;
            decimal unit_price;
            DateTime insert_date;
            byte[] product_image;
            bool is_archived, is_over_rop, is_reordering;


            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id inner join purchase_order_item o on o.product_id = p.product_id WHERE o.order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                rop = int.Parse(dr["rop"].ToString());
                rop_qty = int.Parse(dr["rop_qty"].ToString());
                stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                //product_image = Encoding.ASCII.GetBytes(dr["product_image"].ToString());
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                quantity = int.Parse(dr["quantity"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                is_reordering = bool.Parse(dr["is_reordering"].ToString());
                order_item_id = int.Parse(dr["order_item_id"].ToString());
                type = dr["type"].ToString();
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, quantity, order_item_id, update_history_id, type);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }

       /* public List<Product> getProduct(int id)
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id, rop, rop_qty, stock_level, quantity, order_item_id;
            decimal unit_price;
            DateTime insert_date;
            byte[] product_image;
            bool is_archived, is_over_rop, is_reordering;


            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id WHERE p.product_id= @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                rop = int.Parse(dr["rop"].ToString());
                rop_qty = int.Parse(dr["rop_qty"].ToString());
                stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                //product_image = Encoding.ASCII.GetBytes(dr["product_image"].ToString());
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                quantity = int.Parse(dr["quantity"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                is_reordering = bool.Parse(dr["is_reordering"].ToString());
                order_item_id = int.Parse(dr["order_item_id"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, quantity, order_item_id, update_history_id);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }*/


        public List<Product> getProductArchievAll() //TO GET ARCHIVED PRODUCTS
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id;
            decimal unit_price;
            byte[] product_image;
            DateTime insert_date;


            string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'True' Order by product_id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                rop = int.Parse(dr["rop"].ToString());
                rop_qty = int.Parse(dr["rop_qty"].ToString());
                stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                is_reordering = bool.Parse(dr["is_reordering"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, update_history_id);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }


        public int ProductInsert(string name, string desc, decimal price, byte[] image, int history, int type, int stock_level, int rop, int rop_qty, int update_history_id, bool avaliable)
        {
            //string msg = null;

            //stocklevel, rop, rop qty
            int result = 0;
            int newid = 0;

            string queryStr = "INSERT INTO products (product_name, product_desc, unit_price, product_image, type_id, stock_level, rop, rop_qty, update_history_id, is_available) values (@product_name, @product_desc, @unit_price, @product_image, @type_id, @stock_level, @rop, @rop_qty, @update_history_id, @avaliable)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@product_id", this.product_id);
            cmd.Parameters.AddWithValue("@product_name", name);
            cmd.Parameters.AddWithValue("@product_desc", desc);
            cmd.Parameters.AddWithValue("@unit_price", price);
            cmd.Parameters.AddWithValue("@product_image", image);
            //cmd.Parameters.AddWithValue("@insert_date", this.insert_date);
            cmd.Parameters.AddWithValue("@update_history_id", history);
            cmd.Parameters.AddWithValue("@stock_level", stock_level);
            cmd.Parameters.AddWithValue("@rop", rop);
            cmd.Parameters.AddWithValue("@rop_qty", rop_qty);
            cmd.Parameters.AddWithValue("@type_id", type);
            cmd.Parameters.AddWithValue("avaliable", avaliable);

            //newid = (Int32)cmd.ExecuteScalar();

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int ProductUpdate(int product_id, string product_name, string product_desc, decimal unit_price, int update_history_id, int type_id, int stock_level, int rop, int qty)
        {
            string queryStr = "UPDATE products SET " + "product_name = @product_name, " + "product_desc = @product_desc, " + "unit_price = @unit_price,  " + "type_id = @type_id, " + "stock_level = @stock_level," + "rop = @rop," + "rop_qty = @rop_qty," + "update_history_id = @update_history_id WHERE product_id = @product_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@product_name", product_name);
            cmd.Parameters.AddWithValue("@product_desc", product_desc);
            cmd.Parameters.AddWithValue("@unit_price", unit_price);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            cmd.Parameters.AddWithValue("@type_id", type_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@stock_level", stock_level);
            cmd.Parameters.AddWithValue("@rop", rop);
            cmd.Parameters.AddWithValue("@rop_qty", qty);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }

        public int ProductUpdateImage(int product_id, string product_name, string product_desc, decimal unit_price, byte[] product_image, int update_history_id, int type_id, int stock_level, int rop, int qty) //TO INSERT WITH IMAGE
        {
            string queryStr = "UPDATE products SET " + "product_name = @product_name, " + "product_desc = @product_desc, " + "unit_price = @unit_price, " + "update_history_id = @update_history_id," + "product_image = @product_image, " + "type_id = @type_id, " + "stock_level = @stock_level," + "rop = @rop," + "rop_qty = @rop_qty WHERE product_id = @product_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@product_name", product_name);
            cmd.Parameters.AddWithValue("@product_desc", product_desc);
            cmd.Parameters.AddWithValue("@unit_price", unit_price);
            cmd.Parameters.AddWithValue("@product_image", product_image);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            cmd.Parameters.AddWithValue("@type_id", type_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@stock_level", stock_level);
            cmd.Parameters.AddWithValue("@rop", rop);
            cmd.Parameters.AddWithValue("@rop_qty", qty);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }


        public List<Product> checkproduct(string tid) //TO SEARCH ONLY
        {
            List<Product> checkproduct = new List<Product>();

            string product_name, product_desc;
            int product_id, update_history_id, type_id;
            decimal unit_price;
            byte[] product_image;
            bool is_archived;
            DateTime insert_date;

            //string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' Order by product_id ";

            string queryStr = "SELECT * FROM products where product_name = @id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", tid);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                rop = int.Parse(dr["rop"].ToString());
                rop_qty = int.Parse(dr["rop_qty"].ToString());
                stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                //type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                is_reordering = bool.Parse(dr["is_reordering"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, update_history_id);
                checkproduct.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return checkproduct;
        }


        public List<Product> getallthree(string tid)
        {
            List<Product> categorysearchlist = new List<Product>();

            string product_name, product_desc;
            int product_id, update_history_id, type_id;
            decimal unit_price;
            byte[] product_image;
            bool is_archived;
            DateTime insert_date;

            string queryStr = tid;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@id", tid);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                rop = int.Parse(dr["rop"].ToString());
                rop_qty = int.Parse(dr["rop_qty"].ToString());
                stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                is_reordering = bool.Parse(dr["is_reordering"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, update_history_id);
                categorysearchlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return categorysearchlist;
        }

        public int ProductDelete(int id)
        {
            string querystr = "UPDATE PRODUCTS SET is_archived = 1 WHERE PRODUCT_ID = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }


        public int ProductUnarchieve(int id)
        {
            string querystr = "UPDATE PRODUCTS SET is_archived = 0 WHERE PRODUCT_ID = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int IncreaseProductStock(int prodid, int stock)
        {
            string queryStr = "UPDATE products SET " + "stock_level = stock_level + @stock_level,"  + "is_reordering = 0," + "is_available = 1 WHERE product_id = @product_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@product_id", prodid);
            cmd.Parameters.AddWithValue("@stock_level", stock);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }





        public List<Product> getallavailableproducts()
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id, rop, rop_qty, stock_level;
            decimal unit_price;
            DateTime insert_date;
            bool is_archived, is_over_rop, is_reordering;
            byte[] product_image;


            string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False'and is_available = 'True' Order by product_id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                rop = int.Parse(dr["rop"].ToString());
                rop_qty = int.Parse(dr["rop_qty"].ToString());
                stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                is_reordering = bool.Parse(dr["is_reordering"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, stock_level, rop, rop_qty, is_reordering, is_over_rop, update_history_id);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }
    }
}
