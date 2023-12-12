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
    public class Supplier
    {
        string _connStr = ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;

        private string _supplier_name, _supplier_email, _supplier_address, _supplier_contact;
        private int _supplier_id;
        private bool _is_archived;

        public Supplier(int supplier_id, string supplier_name, string supplier_email, string supplier_address, string supplier_contact, bool is_archived)
        {
            _supplier_id = supplier_id;
            _supplier_name = supplier_name;
            _supplier_email = supplier_email;
            _supplier_address = supplier_address;
            _supplier_contact = supplier_contact;
            _is_archived = is_archived;
        }

        public Supplier(string supplier_name, string supplier_email, string supplier_address, string supplier_contact, bool is_archived)
        {
            _supplier_name = supplier_name;
            _supplier_email = supplier_email;
            _supplier_address = supplier_address;
            _supplier_contact = supplier_contact;
            _is_archived = is_archived;
        }
        public Supplier(int supplier_id)
        {
            _supplier_id = supplier_id;
        }

        public Supplier()
        {
        }

        public int supplier_id
        {
            get { return _supplier_id; }
            set { _supplier_id = value; }
        }

        public string supplier_name
        {
            get { return _supplier_name; }
            set { _supplier_name = value; }
        }

        public string supplier_email
        {
            get { return _supplier_email; }
            set { _supplier_email = value; }
        }

        public string supplier_address
        {
            get { return _supplier_address; }
            set { _supplier_address = value; }
        }

        public string supplier_contact
        {
            get { return _supplier_contact; }
            set { _supplier_contact = value; }
        }

        public bool is_archived
        {
            get { return _is_archived; }
            set { _is_archived = value; }
        }


        public Supplier getSupplier(int id)
        {
            Supplier supplierinfo = null;

            string supplier_name, supplier_email, supplier_address, supplier_contact;
            int supplier_id;
            bool is_archived;

            string queryStr = "SELECT * form suppliers WHERE supplier_id = @id where is_archived = 'False'";
            //string queryStr = "SELECT * FROM products WHERE product_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                supplier_name = dr["supplier_name"].ToString();
                supplier_address = dr["supplier_address"].ToString();
                supplier_email = dr["supplier_email"].ToString();
                supplier_contact = dr["supplier_contact"].ToString();
                is_archived = bool.Parse(dr["is_archived"].ToString());

                supplierinfo = new Supplier(id, supplier_name, supplier_email, supplier_address, supplier_contact, is_archived);
            }
            else
            {
                supplierinfo = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return supplierinfo;
        }

        public List<Supplier> getsupplierAll()
        {
            List<Supplier> supplierlist = new List<Supplier>();

            string supplier_name, supplier_email, supplier_address, supplier_contact;
            int supplier_id;
            bool is_archived;


            string queryStr = "SELECT * from supplier where p.is_archived = 'False' Order by product_id ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                supplier_name = dr["supplier_name"].ToString();
                supplier_address = dr["supplier_address"].ToString();
                supplier_email = dr["supplier_email"].ToString();
                supplier_contact = dr["supplier_contact"].ToString();
                is_archived = bool.Parse(dr["is_archived"].ToString());
                Supplier a = new Supplier(supplier_id, supplier_name, supplier_email, supplier_address, supplier_contact, is_archived);
                supplierlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return supplierlist;
        }


    }
}