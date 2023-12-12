using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Text;

namespace Doosan.models
{
    public class Product
    {
        string _connStr = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;

        private string _product_name, _product_desc,_type_name;
        private int _product_id, _update_history_id, _type_id, _quantity, _order_item_id, _bundle_item_id;
        private decimal _unit_price;
        private DateTime _insert_date;
        private bool _is_archived;
        private byte[] _product_image;

        public Product(int product_id, string product_name, string product_desc, decimal unit_price, byte[] product_image, DateTime insert_date, int update_history_id, int type_id, bool is_archived, string type_name)
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
            _type_name = type_name;
        }

        public Product(int product_id, string product_name, string product_desc, decimal unit_price, byte[] product_image, DateTime insert_date, int update_history_id, int type_id, bool is_archived, string type_name, int quantity, int order_item_id)
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
            _type_name = type_name;
            _quantity = quantity;
            _order_item_id = order_item_id;
        }

        public Product(int product_id, string product_name, string product_desc, decimal unit_price, byte[] product_image, int update_history_id, int type_id, bool is_archived, string type_name, int quantity, int bundle_item_id)
        {
            _product_id = product_id;
            _product_name = product_name;
            _product_desc = product_desc;
            _unit_price = unit_price;
            _product_image = product_image;
            //_insert_date = insert_date;
            _update_history_id = update_history_id;
            _type_id = type_id;
            _is_archived = is_archived;
            _type_name = type_name;
            _quantity = quantity;
            _bundle_item_id = bundle_item_id;
        }

        public Product(string product_name, string product_desc, decimal unit_price, byte[] product_image, DateTime insert_date, int update_history_id, int type_id, bool is_archived, string type_name)
        {
            _product_name = product_name;
            _product_desc = product_desc;
            _unit_price = unit_price;
            _product_image = product_image;
            _insert_date = insert_date;
            _update_history_id = update_history_id;
            _type_id = type_id;
            _is_archived = is_archived;
            _type_name = type_name;
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
        public int bundle_item_id
        {
            get { return _bundle_item_id; }
            set { _bundle_item_id = value; }
        }
        public string product_name
        {
            get { return _product_name; }
            set { _product_name = value; }
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

        public int update_history_id
        {
            get { return _update_history_id; }
            set { _update_history_id = value; }
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

        public string type_name
        {
            get { return _type_name; }
            set { _type_name = value; }
        }

        private String errMsg;
        public DataSet WsGetBundProd(int id)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id inner join bundle_item o on o.product_id = p.product_id inner join bundle b on b.bundle_id = o.bundle_id WHERE o.bundle_id = " + id;
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
        public DataSet WSGetAll()
        {
            //StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' Order by product_id ";



            try
            {
                da = new SqlDataAdapter(queryStr.ToString(), conn);
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

        public DataSet WSgetallthree(string tid)
        {
            //StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = tid;



            try
            {
                da = new SqlDataAdapter(queryStr.ToString(), conn);
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
        

        public DataSet WSgetProduct(int id)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id WHERE product_id = " + id;
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            //conn.Open();


            try
            {
                da = new SqlDataAdapter(queryStr.ToString(), conn);
                //da.SelectCommand.Parameters.AddWithValue("paraid", bookId);
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
            DateTime insert_date;
            byte[] product_image;

            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id WHERE product_id = @id";
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

                productinfo = new Product(id, product_name, product_desc, unit_price, product_image, insert_date, update_history_id, type_id, is_archived, type_name);
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
        public List<Product> getProductinfo(int id)
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id, rop, rop_qty, stock_level, quantity, order_item_id;
            decimal unit_price;
            DateTime insert_date;
            byte[] product_image;
            bool is_archived, is_over_rop, is_reordering;


            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id inner join customer_order_item o on o.product_id = p.product_id WHERE o.order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                //rop = int.Parse(dr["rop"].ToString());
                //rop_qty = int.Parse(dr["rop_qty"].ToString());
                //stock_level = int.Parse(dr["stock_level"].ToString());
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
                //is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                //is_reordering = bool.Parse(dr["is_reordering"].ToString());
                order_item_id = int.Parse(dr["order_item_id"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, update_history_id, type_id, is_archived, type_name, quantity, order_item_id);
                //Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, quantity, order_item_id);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }



        public List<Product> getBundleinfo(int id)
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id, rop, rop_qty, stock_level, quantity, order_item_id, bundle_item_id;
            decimal unit_price;
            DateTime insert_date;
            byte[] product_image;
            bool is_archived, is_over_rop, is_reordering;


            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id inner join bundle_item o on o.product_id = p.product_id WHERE o.bundle_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                //rop = int.Parse(dr["rop"].ToString());
                //rop_qty = int.Parse(dr["rop_qty"].ToString());
                //stock_level = int.Parse(dr["stock_level"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                //product_image = Encoding.ASCII.GetBytes(dr["product_image"].ToString());
                //insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                quantity = int.Parse(dr["quantity"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                //is_over_rop = bool.Parse(dr["is_over_rop"].ToString());
                //is_reordering = bool.Parse(dr["is_reordering"].ToString());
                bundle_item_id = int.Parse(dr["bundle_item_id"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, update_history_id, type_id, is_archived, type_name, quantity, bundle_item_id);
                //Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, type_id, is_archived, type_name, quantity, order_item_id);
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
            int product_id, update_history_id, type_id;
            decimal unit_price;
            byte[] product_image;
            DateTime insert_date;


            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' Order by product_id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, update_history_id, type_id, is_archived, type_name);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }


        public List<Product> getProductArchievAll() //TO GET ARCHIVED PRODUCTS
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id;
            decimal unit_price;
            DateTime insert_date;
            byte[] product_image;


            string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'True' Order by product_id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, update_history_id, type_id, is_archived, type_name);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }



        public List<Product> checkcat(int id)
        {
            List<Product> productlist = new List<Product>();

            string product_name, product_desc, type_name;
            int product_id, update_history_id, type_id, rop, rop_qty, stock_level, quantity, order_item_id;
            decimal unit_price;
            DateTime insert_date;
            byte[] product_image;
            bool is_archived, is_over_rop, is_reordering;


            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id WHERE p.type_id= @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                product_id = int.Parse(dr["product_id"].ToString());
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                //type_desc = dr["type_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_name = dr["type_name"].ToString();
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, update_history_id, type_id, is_archived, type_name);
                productlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return productlist;
        }

        public int ProductInsert(string name, string desc, decimal price, byte[] image, int history, int type)
        {
            //string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO products (product_name, product_desc, unit_price, product_image, update_history_id, type_id) values (@product_name, @product_desc, @unit_price, @product_image, @update_history_id, @type_id)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@product_id", this.product_id);
            cmd.Parameters.AddWithValue("@product_name", name);
            cmd.Parameters.AddWithValue("@product_desc", desc);
            cmd.Parameters.AddWithValue("@unit_price", price);
            cmd.Parameters.AddWithValue("@product_image", image);
            //cmd.Parameters.AddWithValue("@insert_date", this.insert_date);
            cmd.Parameters.AddWithValue("@update_history_id", history);
            cmd.Parameters.AddWithValue("@type_id", type);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int ProductUpdate(int product_id, string product_name, string product_desc, decimal unit_price, int update_history_id, int type_id) //TO UNSERT WITH NO IMAGE
        {
            string queryStr = "UPDATE products SET " + "product_name = @product_name, " + "product_desc = @product_desc, " + "unit_price = @unit_price, update_history_id = @update_history_id, " + "type_id = @type_id " + "WHERE product_id = @product_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@product_name", product_name);
            cmd.Parameters.AddWithValue("@product_desc", product_desc);
            cmd.Parameters.AddWithValue("@unit_price", unit_price);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            cmd.Parameters.AddWithValue("@type_id", type_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }

        public int ProductUpdateImage(int product_id, string product_name, string product_desc, decimal unit_price, byte[] product_image, int update_history_id, int type_id) //TO INSERT WITH IMAGE
        {
            string queryStr = "UPDATE products SET " + "product_name = @product_name, " + "product_desc = @product_desc, " + "unit_price = @unit_price, " + "product_image = @product_image, " + "update_history_id = @update_history_id, " + "type_id = @type_id " + "WHERE product_id = @product_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@product_name", product_name);
            cmd.Parameters.AddWithValue("@product_desc", product_desc);
            cmd.Parameters.AddWithValue("@unit_price", unit_price);
            cmd.Parameters.AddWithValue("@product_image", product_image);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            cmd.Parameters.AddWithValue("@type_id", type_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }



        public List<Product> getallthree(string tid)
        {
            List<Product> categorysearchlist = new List<Product>();


            string product_name, product_desc;
            int product_id, update_history_id, type_id;
            decimal unit_price;
            byte[] product_image;
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
                product_name = dr["product_name"].ToString();
                product_desc = dr["product_desc"].ToString();
                unit_price = decimal.Parse(dr["unit_price"].ToString());
                product_image = (byte[])dr["product_image"];
                insert_date = DateTime.Parse(dr["insert_date"].ToString());
                type_name = dr["type_name"].ToString();
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                Product a = new Product(product_id, product_name, product_desc, unit_price, product_image, insert_date, update_history_id, type_id, is_archived, type_name);
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
    }
}