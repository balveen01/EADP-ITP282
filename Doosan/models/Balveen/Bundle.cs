using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Doosan.TriangleWS;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using System.Text;

namespace Doosan.models
{
    public class Bundle
    {
        string _connStr = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;

        private string _bundle_desc;
        private int _bundle_id, _update_history_id, _product_id, _qty, _item_id, _discount;
        private decimal _total_price;
        private bool _is_archived;

        public Bundle(int bundle_id, string bundle_desc, decimal total_price, int update_history_id, bool is_archived, int item_id, int qty, int product_id, int discount)
        {
            _bundle_id = bundle_id;
            _bundle_desc = bundle_desc;
            _total_price = total_price;
            _update_history_id = update_history_id;
            _is_archived = is_archived;
            _item_id = item_id;
            _qty = qty;
            _product_id = product_id;
            _discount = discount;
        }
        public Bundle(int bundle_id, string bundle_desc, decimal total_price, int update_history_id, bool is_archived, int discount)
        {
            _bundle_id = bundle_id;
            _bundle_desc = bundle_desc;
            _total_price = total_price;
            _update_history_id = update_history_id;
            _is_archived = is_archived;
            //_item_id = item_id;
            //_qty = qty;
            //_product_id = product_id;
            _discount = discount;
        }
        public Bundle(string bundle_desc, decimal total_price, int update_history_id, bool is_archived, int item_id, int qty, int product_id, int discount)
        {
            _bundle_desc = bundle_desc;
            _total_price = total_price;
            _update_history_id = update_history_id;
            _is_archived = is_archived;
            _item_id = item_id;
            _qty = qty;
            _product_id = product_id;
            _discount = discount;
        }
        public Bundle(int bundle_id)
        {
            _bundle_id = bundle_id;
        }
        public Bundle()
        {
        }

        public int bundle_id
        {
            get { return _bundle_id; }
            set { _bundle_id = value; }
        }

        public string bundle_desc
        {
            get { return _bundle_desc; }
            set { _bundle_desc = value; }
        }
        public decimal total_price
        {
            get { return _total_price; }
            set { _total_price = value; }
        }
        public int update_history_id
        {
            get { return _update_history_id; }
            set { _update_history_id = value; }
        }
        public bool is_archived
        {
            get { return _is_archived; }
            set { _is_archived = value; }
        }
        public int item_id
        {
            get { return _item_id; }
            set { _item_id = value; }
        }
        public int qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public int product_id
        {
            get { return _product_id; }
            set { _product_id = value; }
        }
        public int discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        private String errMsg;
        public DataSet WSGetAllBundle()
        {
            //StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * from bundle p where p.is_archived = 'False' order by p.bundle_id ";

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

        public DataSet WSgetBundle(int id) //GET ALL PURCHASE ORDER DETAILS
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT total_price,* from bundle p inner join bundle_item b on p.bundle_id = b.bundle_id inner join products s on s.product_id = b.product_id where p.is_archived = 'False' and p.bundle_id = " + id + " order by p.bundle_id ";
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@id", id);
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


        public Bundle getCO(int id)
        {
            Bundle bundleinfo = null;

            string bundle_desc;
            int bundle_id, update_history_id, product_id, qty, item_id, discount;
            decimal total_price;
            bool is_archived;

            string queryStr = "SELECT * from bundle b inner join bundle_item o on b.bundle_id = o.bundle_id where p.bundle_id = @id and b.is_archived = False";
            //string queryStr = "SELECT * FROM products WHERE product_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                bundle_id = int.Parse(dr["bundle_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                discount = int.Parse(dr["discount"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                item_id = int.Parse(dr["bundle_item_id"].ToString());
                qty = int.Parse(dr["quantity"].ToString());
                product_id = int.Parse(dr["product_id"].ToString());
                bundle_desc = dr["bundle_desc"].ToString();

                bundleinfo = new Bundle(bundle_id, bundle_desc, total_price, update_history_id, is_archived, item_id, qty, product_id, discount);
            }
            else
            {
                bundleinfo = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return bundleinfo;
        }

        public List<Bundle> getAallBundle()
        {
            List<Bundle> bundleinfo = new List<Bundle>();

            string bundle_desc;
            int bundle_id, update_history_id, product_id, qty, item_id, discount;
            decimal total_price;
            bool is_archived;


            //string queryStr = "SELECT * from bundle b inner join bundle_item o on b.bundle_id = o.bundle_id where b.is_archived = 'False' order by b.bundle_id";
            string queryStr = "SELECT * from bundle b where b.is_archived = 'False' order by b.bundle_id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                bundle_id = int.Parse(dr["bundle_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                discount = int.Parse(dr["discount"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                //item_id = int.Parse(dr["bundle_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                bundle_desc = dr["bundle_desc"].ToString();
                Bundle a = new Bundle(bundle_id, bundle_desc, total_price, update_history_id, is_archived, discount);
                bundleinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return bundleinfo;
        }
        public List<Bundle> getallthree(string tid)
        {
            List<Bundle> bundleinfo = new List<Bundle>();

            string bundle_desc;
            int bundle_id, update_history_id, product_id, qty, item_id, discount;
            decimal total_price;
            bool is_archived;


            string queryStr = tid;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                bundle_id = int.Parse(dr["bundle_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                discount = int.Parse(dr["discount"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                item_id = int.Parse(dr["bundle_item_id"].ToString());
                qty = int.Parse(dr["quantity"].ToString());
                product_id = int.Parse(dr["product_id"].ToString());
                bundle_desc = dr["bundle_desc"].ToString();
                Bundle a = new Bundle(bundle_id, bundle_desc, total_price, update_history_id, is_archived, item_id, qty, product_id, discount);
                bundleinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return bundleinfo;
        }

        public List<Bundle> getArcBundle()
        {
            List<Bundle> bundleinfo = new List<Bundle>();

            string bundle_desc;
            int bundle_id, update_history_id, product_id, qty, item_id, discount;
            decimal total_price;
            bool is_archived;


            string queryStr = "SELECT * from bundle b where b.is_archived = 'True' order by b.bundle_id";
            //string queryStr = "SELECT * from customer_order p where p.is_archived = 'True' order by p.order_id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                bundle_id = int.Parse(dr["bundle_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                discount = int.Parse(dr["discount"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                //item_id = int.Parse(dr["bundle_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                bundle_desc = dr["bundle_desc"].ToString();
                Bundle a = new Bundle(bundle_id, bundle_desc, total_price, update_history_id, is_archived, discount);
                bundleinfo.Add(a);
                
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return bundleinfo;
        }

        public int BundleInsert(string desc, decimal total_price, int discount, int update_history_id)
        {
            int result = 0;

            string queryStr = "Insert into bundle(total_price, bundle_desc, update_history_id, discount) values (@total_price, @bundle_desc, @update_history_id, @discount)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@bundle_desc", desc);
            cmd.Parameters.AddWithValue("@total_price", total_price);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            cmd.Parameters.AddWithValue("@discount", discount);
            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int ItemInsert(int qty, int bundle_id, int product_id)
        {
            int result = 0;

            string queryStr = "Insert into bundle_item(quantity, bundle_id, product_id) values (@quantity, @bundle_id, @product_id)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@quantity", qty);
            cmd.Parameters.AddWithValue("@bundle_id", bundle_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int BundleUpdate(string desc, decimal total_price, int discount, int update_history_id, int bundle_id)
        {
            int result = 0;

            string queryStr = "Update bundle set total_price=@total_price, bundle_desc=@bundle_desc, update_history_id=@update_history_id, discount=@discount where bundle_id = @bundle_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@bundle_desc", desc);
            cmd.Parameters.AddWithValue("@total_price", total_price);
            cmd.Parameters.AddWithValue("@bundle_id", bundle_id);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            cmd.Parameters.AddWithValue("@discount", discount);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int ItemUpdate(int qty, int bundle_id, int product_id)
        {
            int result = 0;

            string queryStr = "Update bundle_item set quantity=@quantity, product_id=@product_id where bundle_id = @bundle_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@quantity", qty);
            cmd.Parameters.AddWithValue("@bundle_id", bundle_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int BundleDelete(int id)
        {
            string querystr = "UPDATE bundle SET is_archived = 1 WHERE bundle_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int ItemDelete(int id)
        {
            string querystr = "UPDATE bundle_item SET is_archived = 1 WHERE bundle_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }


        public int BundleUnarchieve(int id)
        {
            string querystr = "UPDATE bundle SET is_archived = 0 WHERE bundle_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }
        public int ItemUnarchieve(int id)
        {
            string querystr = "UPDATE bundle_item SET is_archived = 0 WHERE bundle_id = @id";
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