using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;

namespace Doosan.models
{
    public class Category
    {
        string _connStr = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;

        private string _type_name, _type_desc;
        private int _type_id, _update_history_id;
        private bool _is_archived;


        public Category(int type_id, string type_name, string type_desc, int update_history_id, bool is_archived)
        {
            _type_id = type_id;
            _type_name = type_name;
            _type_desc = type_desc;
            _update_history_id = update_history_id;
            _is_archived = is_archived;
        }

        public Category(string type_name, string type_desc, int update_history_id, bool is_archived)
        {
            _type_name = type_name;
            _type_desc = type_desc;
            _update_history_id = update_history_id;
            _is_archived = is_archived;
        }

        public Category(int type_id)
        {
            _type_id = type_id;
        }

        public Category()
        {
        }

        public int type_id
        {
            get { return _type_id; }
            set { _type_id = value; }
        }
        public string type_name
        {
            get { return _type_name; }
            set { _type_name = value; }
        }

        public string type_desc
        {
            get { return _type_desc; }
            set { _type_desc = value; }
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

        public Category getCategory(int id)
        {
            Category categoryinfo = null;

            string type_name, type_desc;
            int type_id, update_history_id;
            bool is_archived;

            string queryStr = "SELECT * FROM product_type WHERE type_id = @id";
            //string queryStr = "SELECT * FROM products WHERE product_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                type_desc = dr["type_desc"].ToString();
                type_name = dr["type_name"].ToString();
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());

                categoryinfo = new Category(id, type_name, type_desc, update_history_id, is_archived);
            }
            else
            {
                categoryinfo = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return categoryinfo;
        }

        public List<Category> getCategoryAll()
        {
            List<Category> categorylist = new List<Category>();

            string type_name, type_desc;
            int type_id, update_history_id;
            bool is_archived;


            string queryStr = "SELECT * FROM product_type";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                type_desc = dr["type_desc"].ToString();
                type_name = dr["type_name"].ToString();
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());

                Category a = new Category(type_id, type_name, type_desc, update_history_id, is_archived);
                categorylist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return categorylist;
        }


        public List<Category> getCategoryArchievAll()
        {
            List<Category> categorylist = new List<Category>();

            string type_name, type_desc;
            int type_id, update_history_id;
            bool is_archived;


            string queryStr = "SELECT * FROM product_type where is_archived = 'True' Order by type_id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                type_desc = dr["type_desc"].ToString();
                type_name = dr["type_name"].ToString();
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());

                Category a = new Category(type_id, type_name, type_desc, update_history_id, is_archived);
                categorylist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return categorylist;
        }

        public List<Category> checkcat(int id)
        {
            List<Category> categorylist = new List<Category>();

            string type_name, type_desc;
            int type_id, update_history_id;
            bool is_archived;


            string queryStr = "SELECT * FROM products p inner join product_type t on p.type_id = t.type_id WHERE p.type_id= @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                type_desc = dr["type_desc"].ToString();
                type_name = dr["type_name"].ToString();
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());

                Category a = new Category(type_id, type_name, type_desc, update_history_id, is_archived);
                categorylist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return categorylist;
        }
        public int CategoryInsert(string name, string desc, int history)
        {
            //string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO product_type (type_name, type_desc, update_history_id) values (@type_name, @type_desc, @update_history_id)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@product_id", this.product_id);
            cmd.Parameters.AddWithValue("@type_name", name);
            cmd.Parameters.AddWithValue("@type_desc", desc);
            cmd.Parameters.AddWithValue("@update_history_id", history);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int UpdateCategory(int type_id, string type_name, string type_desc, int update_history_id)
        {
            string queryStr = "UPDATE product_type SET type_name = @type_name, type_desc = @type_desc WHERE type_id = @type_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@type_name", type_name);
            cmd.Parameters.AddWithValue("@type_desc", type_desc);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            cmd.Parameters.AddWithValue("@type_id", type_id);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }

        public List<Category> getallthree(string tid)
        {
            List<Category> categorysearchlist = new List<Category>();

            string type_name, type_desc;
            int type_id, update_history_id;
            bool is_archived;

            string queryStr = tid;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@id", tid);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                type_desc = dr["type_desc"].ToString();
                type_name = dr["type_name"].ToString();
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                type_id = int.Parse(dr["type_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                Category a = new Category(type_id, type_name, type_desc, update_history_id, is_archived);
                categorysearchlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return categorysearchlist;
        }

        public int CategoryDelete(int id)
        {
            string querystr = "UPDATE product_type SET is_archived = 1 WHERE type_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }


        public int CategoryUnarchieve(int id)
        {
            string querystr = "UPDATE product_type SET is_archived = 0 WHERE type_id = @id";
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