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
    public class CustomerOrder
    {
        string _connStr = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;

        private string _company_name;
        private int _order_id, _update_history_id, _company_id, _item_id, _qty, _product_id, _poid_ref;
        private decimal _total_price;
        private bool _is_archived, _is_approved;
        private DateTime _order_date;

        public CustomerOrder(int order_id, decimal total_price, DateTime order_date, bool is_approved, int update_history_id, int company_id, bool is_archived, int item_id, int qty, int product_id, int poid_ref)
        {
            _order_id = order_id;
            _total_price = total_price;
            _order_date = order_date;
            _item_id = item_id;
            _qty = qty;
            _product_id = product_id;
            _is_approved = is_approved;
            _update_history_id = update_history_id;
            _company_id = company_id;
            _is_archived = is_archived;
            _poid_ref = poid_ref;

        }


        public CustomerOrder(decimal total_price, DateTime order_date, bool is_approved, int update_history_id, int company_id, bool is_archived, int item_id, int qty, int product_id, int poid_ref)
        {
            _total_price = total_price;
            _order_date = order_date;
            _item_id = item_id;
            _qty = qty;
            _product_id = product_id;
            _is_approved = is_approved;
            _update_history_id = update_history_id;
            _company_id = company_id;
            _is_archived = is_archived;
            _poid_ref = poid_ref;

        }

        public CustomerOrder(int order_id, decimal total_price, DateTime order_date, bool is_approved, int update_history_id, int company_id, bool is_archived, int poid_ref)
        {
            _order_id = order_id;
            _total_price = total_price;
            _order_date = order_date;
            _is_approved = is_approved;
            _update_history_id = update_history_id;
            _company_id = company_id;
            _is_archived = is_archived;
            _poid_ref = poid_ref;
        }

        public CustomerOrder(int order_id, decimal total_price, DateTime order_date, bool is_approved, int update_history_id, int company_id, bool is_archived, string company_name, int poid_ref)
        {
            _order_id = order_id;
            _total_price = total_price;
            _order_date = order_date;
            _is_approved = is_approved;
            _update_history_id = update_history_id;
            _company_id = company_id;
            _is_archived = is_archived;
            _company_name = company_name;
            _poid_ref = poid_ref;
        }
        public CustomerOrder(int order_id)
        {
            _order_id = order_id;
        }

        public CustomerOrder()
        {
        }

        public int order_id
        {
            get { return _order_id; }
            set { _order_id = value; }
        }

        public int poid_ref
        {
            get { return _poid_ref; }
            set { _poid_ref= value; }
        }

        public string company_name
        {
            get { return _company_name; }
            set { _company_name= value; }
        }

        public decimal total_price
        {
            get { return _total_price; }
            set { _total_price = value; }
        }

        public DateTime order_date
        {
            get { return _order_date; }
            set { _order_date = value; }
        }

        public bool is_approved
        {
            get { return _is_approved; }
            set { _is_approved = value; }
        }

        public int update_history_id
        {
            get { return _update_history_id; }
            set { _update_history_id = value; }
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
        public int company_id
        {
            get { return _company_id; }
            set { _company_id = value; }
        }

        public bool is_archived
        {
            get { return _is_archived; }
            set { _is_archived = value; }
        }
        public DataSet GetPO()
        {
            TriangleAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new TriangleAPIClient();
            return betterBookSupplierClient.GetPO();
        }
        public DataSet GetDecPO()
        {
            TriangleAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new TriangleAPIClient();
            return betterBookSupplierClient.GetDecPO();
        }
        public DataSet GetAppPO()
        {
            TriangleAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new TriangleAPIClient();
            return betterBookSupplierClient.GetAppPO();
        }
        public DataSet GetPendPO()
        {
            TriangleAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new TriangleAPIClient();
            return betterBookSupplierClient.GetPendPO();
        }

        public DataSet GetPODetails(int id)
        {
            TriangleAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new TriangleAPIClient();
            return betterBookSupplierClient.GetPODetails(id);
        }

        public DataSet SuppApprove(int id)
        {
            TriangleAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new TriangleAPIClient();
            return betterBookSupplierClient.SuppApprove(id);
        }

        public DataSet SuppDeclined(int id)
        {
            TriangleAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new TriangleAPIClient();
            return betterBookSupplierClient.SuppDeclined(id);
        }
        public DataSet ProdInfo(int id)
        {
            TriangleAPIClient betterBookSupplierClient;
            betterBookSupplierClient = new TriangleAPIClient();
            return betterBookSupplierClient.GetPOProducts(id);
        }

        public CustomerOrder getCO(int id)
        {
            CustomerOrder coinfo = null;

            int order_id, update_history_id, company_id, poid;
            decimal total_price;
            bool is_archived, is_approved;
            DateTime order_date;
            string queryStr = "SELECT * from customer_order p inner join customer_order_item o on p.order_id = o.order_id where p.order_id = @id and p.is_archived = False";
            //string queryStr = "SELECT * FROM products WHERE product_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                order_id = int.Parse(dr["order_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                order_date = DateTime.Parse(dr["order_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                company_id = int.Parse(dr["company_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                item_id = int.Parse(dr["order_item_id"].ToString());
                qty = int.Parse(dr["qty"].ToString());
                product_id = int.Parse(dr["product_id"].ToString());
                poid = int.Parse(dr["poid_ref"].ToString());

                coinfo = new CustomerOrder(id, total_price, order_date, is_approved, update_history_id, company_id, is_archived, item_id, qty, product_id, poid);
            }
            else
            {
                coinfo = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return coinfo;
        }
        public List<CustomerOrder> getACOall()
        {
            List<CustomerOrder> poinfo = new List<CustomerOrder>();

            string company_name;
            int order_id, update_history_id, company_id, poid;
            decimal total_price;
            bool is_archived, is_approved;
            DateTime order_date;


            string queryStr = "SELECT *, c.company_name from customer_order p inner join companies c on c.company_id = p.company_id where p.is_archived = 'False' order by p.order_date desc";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                order_id = int.Parse(dr["order_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                order_date = DateTime.Parse(dr["order_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                company_id = int.Parse(dr["company_id"].ToString());
                company_name = dr["company_name"].ToString();
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                poid = int.Parse(dr["poid_ref"].ToString());
                CustomerOrder a = new CustomerOrder(order_id, total_price, order_date, is_approved, update_history_id, company_id, is_archived, company_name, poid);
                poinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }
        public List<CustomerOrder> getallthree(string tid) //TO SEARCH AND FILTER
        {
            List<CustomerOrder> posearchlist = new List<CustomerOrder>();

            int order_id, update_history_id, company_id, poid;
            decimal total_price;
            bool is_archived, is_approved;
            DateTime order_date;

            //string queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' Order by product_id ";

            //Bstring queryStr = "SELECT *, t.type_name FROM products p inner join product_type t on p.type_id = t.type_id where p.is_archived = 'False' and t.type_id = @fid order by p." + sid;

            string queryStr = tid;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@id", tid);
            //cmd.Parameters.AddWithValue("@fid", fid);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                order_id = int.Parse(dr["order_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                order_date = DateTime.Parse(dr["order_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                company_id = int.Parse(dr["company_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                company_name = dr["company_name"].ToString();
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                poid =int.Parse(dr["poid_ref"].ToString());
                CustomerOrder a = new CustomerOrder(order_id, total_price, order_date, is_approved, update_history_id, company_id, is_archived, company_name,poid);
                posearchlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return posearchlist;
        }
        public List<CustomerOrder> getArcCOall()
        {
            List<CustomerOrder> poinfo = new List<CustomerOrder>();

            int order_id, update_history_id, company_id, poid;
            decimal total_price;
            bool is_archived, is_approved;
            DateTime order_date;


            string queryStr = "SELECT * from customer_order p where p.is_archived = 'True' order by p.order_date desc ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                order_id = int.Parse(dr["order_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                order_date = DateTime.Parse(dr["order_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                company_id = int.Parse(dr["company_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                poid = int.Parse(dr["poid_ref"].ToString());
                CustomerOrder a = new CustomerOrder(order_id, total_price, order_date, is_approved, update_history_id, company_id, is_archived, poid);
                poinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }

        public int COInsert(decimal total_price, int company_id, int update_history_id, bool approve, int poid)
        {
            //string msg = null;
            StringBuilder sql;
            int result = 0;
            int newOrderId = 0;

            string queryStr = "INSERT INTO customer_order (total_price, order_date, update_history_id, company_id, is_approved, poid_ref) values (@total_price, @order_date, @update_history_id, @company_id, @approved, @poid)";

            // string queryStr = "DECLARE @orderid int NSERT INTO purchase_order (total_price, order_date, update_history_id, supplier_id) values (@total_price, @order_date, @update_history_id, @supplier_id) SET @orderid = SCOPE_IDENTITY() INSERT INTO Member_Detail(pk, name) VALUES(@MemberId, 'hello again')";

            //sql = new StringBuilder();
            //sql.AppendLine("INSERT INTO purchase_order (total_price, order_date, update_history_id, supplier_id)");

            //sql.AppendLine("values (@total_price, @order_date, @update_history_id, @supplier_id)");
            //sql.AppendLine("SELECT CAST(scope_identity() AS int)");
            //sql.AppendLine(" ");


            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@product_id", this.product_id);
            cmd.Parameters.AddWithValue("@total_price", total_price);
            cmd.Parameters.AddWithValue("@order_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            cmd.Parameters.AddWithValue("@company_id", company_id);
            cmd.Parameters.AddWithValue("@approved", approve);
            cmd.Parameters.AddWithValue("@poid", poid);

            conn.Open();
            //newOrderId = (Int32)cmd.ExecuteScalar();  // ExecuteScalar return 1st column of the record


            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
        public int COIInsert(int qty, int order_id, int product_id)
        {
            //string msg = null;
            int result = 0;

            string queryStr = "INSERT customer_order_item (quantity, order_id, product_id) VALUES (@quantity, @order_id, @product_id)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@product_id", this.product_id);
            cmd.Parameters.AddWithValue("@quantity", qty);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int coUpdate(decimal total_price, int update_history_id, int order_id)
        {
            //order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived
            //string queryStr = "UPDATE purchase_orders SET " + "total_price = @total_price, " + " update_history_id = @update_history_id, " + "supplier_id = @supplier_id " + "WHERE order_id = @order_id";
            //string queryStr = "UPDATE customer_order inner p join customer_order_item o on p.order_id = o.order_id SET " + "p.total_price = @total_price, " + " p.update_history_id = @update_history_id, " + "o.quantity = @quantity" + "WHERE o.order_id = @order_id and p.order_id = @order_id";
            string queryStr = "Update customer_order SET total_price = @total_price, update_history_id = @update_history_id WHERE order_id = @order_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@total_price", total_price);
            cmd.Parameters.AddWithValue("@update_history_id", update_history_id);
            //cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
            cmd.Parameters.AddWithValue("@order_id", order_id);


            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }


        public int coiUpdate(int qty, int order_id, int product_id)
        {
            //order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived
            //string queryStr = "UPDATE purchase_orders SET " + "total_price = @total_price, " + " update_history_id = @update_history_id, " + "supplier_id = @supplier_id " + "WHERE order_id = @order_id";
            //string queryStr = "UPDATE customer_order inner p join customer_order_item o on p.order_id = o.order_id SET " + "p.total_price = @total_price, " + " p.update_history_id = @update_history_id, " + "o.quantity = @quantity" + "WHERE o.order_id = @order_id and p.order_id = @order_id";
            string queryStr = "Update customer_order_item SET quantity = @quantity WHERE order_id = @order_id and product_id = @product_id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@quantity", qty);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }


        public List<CustomerOrder> getPOSearch(string id)
        {
            List<CustomerOrder> cosearchlist = new List<CustomerOrder>();

            int order_id, update_history_id, supplier_id, poid;
            decimal total_price;
            bool is_archived, is_approved;
            DateTime order_date;

            string queryStr = "SELECT *from customer_order where company_id like '%' + @id +  '%' and p.is_archived = 'False'";


            //string queryStr = "SELECT * from purhcase_order";
            //string queryStr = "SELECT * FROM products WHERE product_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                order_id = int.Parse(dr["order_id"].ToString());
                total_price = decimal.Parse(dr["total_price"].ToString());
                order_date = DateTime.Parse(dr["insert_date"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                company_id = int.Parse(dr["company_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                item_id = int.Parse(dr["item_id"].ToString());
                qty = int.Parse(dr["qty"].ToString());
                product_id = int.Parse(dr["product_id"].ToString());
                poid = int.Parse(dr["poid_ref"].ToString());


                CustomerOrder a = new CustomerOrder(order_id, total_price, order_date, is_approved, update_history_id, company_id, is_archived, item_id, qty, product_id, poid);
                cosearchlist.Add(a);
            }
            else
            {
                cosearchlist = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return cosearchlist;
        }
        public int coDelete(int id)
        {
            string querystr = "UPDATE customer_order SET is_archived = 1 WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int coiDelete(int id)
        {
            string querystr = "UPDATE customer_order_item SET is_archived = 1 WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }


        public int coUnarchieve(int id)
        {
            string querystr = "UPDATE customer_order SET is_archived = 0 WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }
        public int coiUnarchieve(int id)
        {
            string querystr = "UPDATE customer_order_item SET is_archived = 0 WHERE order_item_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int cocomapprove(int id)
        {
            string querystr = "UPDATE customer_order SET is_com_approved = 1 WHERE order_id = @id";
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