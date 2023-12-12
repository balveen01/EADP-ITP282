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
    public class PurchaseOrder
    {
        string _connStr = ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;

        private string _supplier_name, _type;
        private int _order_id, _update_history_id, _supplier_id, _item_id, _qty, _product_id, _attempt_no;
        private decimal _total_price;
        private bool _is_archived, _is_com_approved, _is_supp_approved;
        private DateTime _order_date;

        public PurchaseOrder(int order_id, decimal total_price, DateTime order_date, bool is_com_approved, bool is_supp_approved, int update_history_id, int supplier_id, bool is_archived, int item_id, int qty, int product_id, string type) 
        {
            _order_id = order_id;
            _total_price = total_price;
            _order_date = order_date;
            _is_com_approved = is_com_approved;
            _item_id = item_id;
            _qty = qty;
            _product_id = product_id;
            _is_supp_approved = is_supp_approved;
            _update_history_id = update_history_id;
            _supplier_id = supplier_id;
            _is_archived = is_archived;
            _type = type;

        }

        public PurchaseOrder(int order_id, decimal total_price, DateTime order_date, bool is_com_approved, bool is_supp_approved, int update_history_id, int supplier_id, bool is_archived, string supplier_name, string type)
        {
            _order_id = order_id;
            _total_price = total_price;
            _order_date = order_date;
            _is_com_approved = is_com_approved;
            _product_id = product_id;
            _is_supp_approved = is_supp_approved;
            _update_history_id = update_history_id;
            _supplier_id = supplier_id;
            _is_archived = is_archived;
            _supplier_name = supplier_name;
            _type = type;

        }

        public PurchaseOrder(int order_id, decimal total_price, DateTime order_date, bool is_com_approved, bool is_supp_approved, int update_history_id, int supplier_id, bool is_archived, string supplier_name, int attempt_no)
        {
            _order_id = order_id;
            _total_price = total_price;
            _order_date = order_date;
            _is_com_approved = is_com_approved;
            _product_id = product_id;
            _is_supp_approved = is_supp_approved;
            _update_history_id = update_history_id;
            _supplier_id = supplier_id;
            _is_archived = is_archived;
            _supplier_name = supplier_name;
            _attempt_no = attempt_no;

        }

        public PurchaseOrder(decimal total_price, DateTime order_date, bool is_com_approved, bool is_supp_approved, int update_history_id, int supplier_id, bool is_archived, int item_id, int qty, int product_id, string type)
        {
            _total_price = total_price;
            _order_date = order_date;
            _is_com_approved = is_com_approved;
            _item_id = item_id;
            _qty = qty;
            _product_id = product_id;
            _is_supp_approved = is_supp_approved;
            _update_history_id = update_history_id;
            _supplier_id = supplier_id;
            _is_archived = is_archived;
            _type = type;

        }

        public PurchaseOrder(int order_id, decimal total_price, DateTime order_date, bool is_com_approved, bool is_supp_approved, int update_history_id, int supplier_id, bool is_archived, string supplier_name)
        {
            _order_id = order_id;
            _total_price = total_price;
            _order_date = order_date;
            _is_com_approved = is_com_approved;
            _is_supp_approved = is_supp_approved;
            _update_history_id = update_history_id;
            _supplier_id = supplier_id;
            _is_archived = is_archived;
            _supplier_name = supplier_name;
        }

        public PurchaseOrder(int order_id)
        {
            _order_id = order_id;
        }

        public PurchaseOrder()
        {
        }

        public int order_id
        {
            get { return _order_id; }
            set { _order_id = value; }
        }

        public string supplier_name
        {
            get { return _supplier_name; }
            set { _supplier_name = value; }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; }
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

        public bool is_com_approved
        {
            get { return _is_com_approved; }
            set { _is_com_approved = value; }
        }

        public bool is_supp_approved
        {
            get { return _is_supp_approved; }
            set { _is_supp_approved = value; }
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
        public int attempt_no
        {
            get { return _attempt_no; }
            set { _attempt_no = value; }
        }
        public int product_id
        {
            get { return _product_id; }
            set { _product_id = value; }
        }
        public int supplier_id
        {
            get { return _supplier_id; }
            set { _supplier_id = value; }
        }

        public bool is_archived
        {
            get { return _is_archived; }
            set { _is_archived = value; }
        }
        private String errMsg;
        public DataSet WSGetAllPO() //GET ALL PURCHASE ORDERS
        {
            //StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * from purchase_orders p where p.is_archived = 'False' and supplier_id =1 and is_com_approved = 'True' order by p.order_date desc";

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

        public DataSet WSGetAppPO() //GET ALL SUPPLIER APPROVED ORDERS
        {
            //StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * from purchase_orders p where p.is_archived = 'False' and supplier_id =1 and is_supp_approved = 'True' and is_com_approved = 'True' order by p.order_date desc";



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

        public DataSet WSGetDecPO() //GET ALL SUPPLIER DECLINED ORDERS
        {
            //StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * from purchase_orders p where p.is_archived = 'False'and supplier_id =1  and is_supp_declined = 'True' and is_com_approved = 'True' order by p.order_date desc";



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

        public DataSet WSGetPendPO() //GET ALL PENDING ORDERS
        {
            //StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * from purchase_orders p where p.is_archived = 'False' and supplier_id =1 and is_supp_approved = 'False' and is_supp_declined = 'False' and is_com_approved = 'True'  order by p.order_date desc";



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

        public DataSet WSgetPO(int id) //GET ALL PURCHASE ORDER DETAILS
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet booksData;

            SqlConnection conn = new SqlConnection(_connStr);
            booksData = new DataSet();
            string queryStr = "SELECT * from purchase_orders p where p.is_archived = 'False' and is_com_approved = 'True' and supplier_id =1 and order_id = " + id + " order by p.order_date desc";
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

        public DataSet WsSuppapprove(int id)
        {
            SqlDataAdapter da;
            DataSet booksData;
            //DataSet nofRow = null;

            booksData = new DataSet();
            string querystr = "UPDATE purchase_orders SET is_supp_approved = 1 WHERE order_id = " + id;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            //cmd.Parameters.AddWithValue("@id", id);
            //conn.Open();
            try
            {
                da = new SqlDataAdapter(querystr.ToString(), conn);
                da.Fill(booksData);
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                //nofRow = cmd.ExecuteNonQuery();
                conn.Close();
            }
            ;
            conn.Close();
           
            return booksData;
        }

        public DataSet WsSuppdeclined(int id)
        {
            SqlDataAdapter da;
            DataSet booksData;
            //DataSet nofRow = null;

            booksData = new DataSet();
            string querystr = "UPDATE purchase_orders SET is_supp_declined = 1 WHERE order_id = " + id;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            //cmd.Parameters.AddWithValue("@id", id);
            //conn.Open();
            try
            {
                da = new SqlDataAdapter(querystr.ToString(), conn);
                da.Fill(booksData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                //nofRow = cmd.ExecuteNonQuery();
                conn.Close();
            }
    ;
            conn.Close();

            return booksData;
        }


        public PurchaseOrder getPO(int id)
        {
            PurchaseOrder poinfo = null;

            int order_id, update_history_id, supplier_id;
            decimal total_price;
            bool is_archived, is_com_approved, is_supp_approved;
            DateTime order_date;
            string type;
            
            string queryStr = "SELECT * from purhcase_orders p inner join purchase_order_item o on p.order_id = o.order_id where p.order_id = @id and p.is_archived = False and p.is_com_approved = True" ;
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
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_com_approved = bool.Parse(dr["is_com_approved"].ToString());
                is_supp_approved = bool.Parse(dr["is_supp_approved"].ToString());
                item_id = int.Parse(dr["order_item_id"].ToString());
                qty = int.Parse(dr["qty"].ToString());
                product_id = int.Parse(dr["product_id"].ToString());
                type = dr["type"].ToString();

                poinfo = new PurchaseOrder(id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived, item_id, qty, product_id, type);
            }
            else
            {
                poinfo = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }
        public List<PurchaseOrder> getArcPOall()
        {
            List<PurchaseOrder> poinfo = new List<PurchaseOrder>();

            int order_id, update_history_id, supplier_id;
            decimal total_price;
            string type;
            bool is_archived, is_com_approved, is_supp_approved;
            DateTime order_date;


            string queryStr = "SELECT * from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where p.is_archived = 'True' order by p.order_date desc";
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
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_com_approved = bool.Parse(dr["is_com_approved"].ToString());
                is_supp_approved = bool.Parse(dr["is_supp_approved"].ToString());
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                supplier_name = dr["supplier_name"].ToString();
                //product_id = int.Parse(dr["product_id"].ToString());
                //type = dr["type"].ToString();
                PurchaseOrder a = new PurchaseOrder(order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived,supplier_name);
                poinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }







        public List<PurchaseOrder> getPOall()
        {
            List<PurchaseOrder> poinfo = new List<PurchaseOrder>();

            string supplier_name, type;
            int order_id, update_history_id, supplier_id;
            decimal total_price;
            bool is_archived, is_com_approved, is_supp_approved;
            DateTime order_date;


            //string queryStr = "SELECT * from purchase_orders p inner join purchase_order_item po on po.order_id = p.order_id where p.is_archived = 'False' order by p.order_id ";
            string queryStr = "SELECT *, p.order_id from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where p.is_archived = 'False' order by p.order_date desc";
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
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                supplier_name = dr["supplier_name"].ToString();
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_com_approved = bool.Parse(dr["is_com_approved"].ToString());
                is_supp_approved = bool.Parse(dr["is_supp_approved"].ToString());
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                //type = dr["type"].ToString();
                PurchaseOrder a = new PurchaseOrder(order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived, supplier_name);
                poinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }




        public List<PurchaseOrder> getPOcom(string query)
        {
            List<PurchaseOrder> poinfo = new List<PurchaseOrder>();

            int order_id, update_history_id, supplier_id;
            string type;
            decimal total_price;
            bool is_archived, is_com_approved, is_supp_approved;
            DateTime order_date;


            //string queryStr = "SELECT * from purchase_orders p inner join purchase_order_item po on po.order_id = p.order_id where p.is_archived = 'False' order by p.order_id ";
            //string queryStr = "SELECT * from purchase_orders p where p.is_archived = 'False' order by p.order_id ";

            string queryStr = query;
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
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_com_approved = bool.Parse(dr["is_com_approved"].ToString());
                is_supp_approved = bool.Parse(dr["is_supp_approved"].ToString());
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                type = dr["type"].ToString();
                PurchaseOrder a = new PurchaseOrder(order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived, type);
                poinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }


        public List<PurchaseOrder> getPOsupp(string query)
        {
            List<PurchaseOrder> poinfo = new List<PurchaseOrder>();

            int order_id, update_history_id, supplier_id;
            decimal total_price;
            bool is_archived, is_com_approved, is_supp_approved;
            string type;
            DateTime order_date;


            //string queryStr = "SELECT * from purchase_orders p inner join purchase_order_item po on po.order_id = p.order_id where p.is_archived = 'False' order by p.order_id ";
            //string queryStr = "SELECT * from purchase_orders p where p.is_archived = 'False' order by p.order_id ";

            string queryStr = query;
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
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_com_approved = bool.Parse(dr["is_com_approved"].ToString());
                is_supp_approved = bool.Parse(dr["is_supp_approved"].ToString());
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                type = dr["type"].ToString();
                PurchaseOrder a = new PurchaseOrder(order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived, type);
                poinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }


        public List<PurchaseOrder> getAPOall()
        {
            List<PurchaseOrder> poinfo = new List<PurchaseOrder>();

            string supplier_name, type;
            int order_id, update_history_id, supplier_id, attempt_no;
            decimal total_price;
            bool is_archived, is_com_approved, is_supp_approved;
            DateTime order_date;


            string queryStr = "SELECT * from purchase_orders p inner join suppliers s on p.supplier_id = s.supplier_id where p.is_archived = 'False' and is_com_approved = 'False' and is_com_declined = 'False' order by p.order_date desc";
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
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                attempt_no = int.Parse(dr["attempt_no"].ToString());
                supplier_name = dr["supplier_name"].ToString();
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_com_approved = bool.Parse(dr["is_com_approved"].ToString());
                is_supp_approved = bool.Parse(dr["is_supp_approved"].ToString());
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                //type = dr["type"].ToString();
                PurchaseOrder a = new PurchaseOrder(order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived, supplier_name, attempt_no);
                poinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }

        public List<PurchaseOrder> getRPOall()
        {
            List<PurchaseOrder> poinfo = new List<PurchaseOrder>();

            string supplier_name, type;
            int order_id, update_history_id, supplier_id, attempt_no;
            decimal total_price;
            bool is_archived, is_com_approved, is_supp_approved;
            DateTime order_date;


            string queryStr = "SELECT * from purchase_orders p inner join suppliers s on s.supplier_id = p.supplier_id where p.is_archived = 'False' and is_com_approved = 'False' and is_com_declined = 'True' order by p.order_date desc";
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
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                supplier_name = dr["supplier_name"].ToString();
                attempt_no = int.Parse(dr["attempt_no"].ToString());
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_com_approved = bool.Parse(dr["is_com_approved"].ToString());
                is_supp_approved = bool.Parse(dr["is_supp_approved"].ToString());
                //type = dr["type"].ToString();
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                PurchaseOrder a = new PurchaseOrder(order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived, supplier_name, attempt_no);
                poinfo.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return poinfo;
        }







        public int POInsert(decimal total_price, int supplier_id, int update_history_id)
        {
            //string msg = null;
            StringBuilder sql;
            int result = 0;
            int newOrderId = 0;

           string queryStr = "INSERT INTO purchase_orders (total_price, order_date, update_history_id, supplier_id) values (@total_price, @order_date, @update_history_id, @supplier_id)";

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
            cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
            

            conn.Open();
            //newOrderId = (Int32)cmd.ExecuteScalar();  // ExecuteScalar return 1st column of the record


            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int POIInsert(int qty, int order_id, int product_id, string type)
        {
            //string msg = null;
            int result = 0;

            string queryStr = "INSERT purchase_order_item (quantity, order_id, product_id, type) VALUES (@quantity, @order_id, @product_id, @type)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@product_id", this.product_id);
            cmd.Parameters.AddWithValue("@quantity", qty);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@product_id", product_id);
            cmd.Parameters.AddWithValue("@type", type);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int poUpdate(decimal total_price, int update_history_id, int order_id)
        {
            //order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived
            //string queryStr = "UPDATE purchase_orders SET " + "total_price = @total_price, " + " update_history_id = @update_history_id, " + "supplier_id = @supplier_id " + "WHERE order_id = @order_id";
            //string queryStr = "UPDATE customer_order inner p join customer_order_item o on p.order_id = o.order_id SET " + "p.total_price = @total_price, " + " p.update_history_id = @update_history_id, " + "o.quantity = @quantity" + "WHERE o.order_id = @order_id and p.order_id = @order_id";
            string queryStr = "Update purchase_orders SET total_price = @total_price, update_history_id = @update_history_id WHERE order_id = @order_id";

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


        public int poiUpdate(int qty, int order_id, int product_id)
        {
            //order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived
            //string queryStr = "UPDATE purchase_orders SET " + "total_price = @total_price, " + " update_history_id = @update_history_id, " + "supplier_id = @supplier_id " + "WHERE order_id = @order_id";
            //string queryStr = "UPDATE customer_order inner p join customer_order_item o on p.order_id = o.order_id SET " + "p.total_price = @total_price, " + " p.update_history_id = @update_history_id, " + "o.quantity = @quantity" + "WHERE o.order_id = @order_id and p.order_id = @order_id";
            string queryStr = "Update purchase_order_item SET quantity = @quantity WHERE order_id = @order_id and product_id = @product_id";
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



        public int poApprove(decimal total_price, int update_history_id, int order_id)
        {
            //order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived
            //string queryStr = "UPDATE purchase_orders SET " + "total_price = @total_price, " + " update_history_id = @update_history_id, " + "supplier_id = @supplier_id " + "WHERE order_id = @order_id";
            //string queryStr = "UPDATE customer_order inner p join customer_order_item o on p.order_id = o.order_id SET " + "p.total_price = @total_price, " + " p.update_history_id = @update_history_id, " + "o.quantity = @quantity" + "WHERE o.order_id = @order_id and p.order_id = @order_id";
            string queryStr = "Update purchase_orders SET total_price = @total_price, update_history_id = @update_history_id, is_com_declined = 'False' WHERE order_id = @order_id";

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






        public List<PurchaseOrder> getallthree(string tid) //TO SEARCH AND FILTER
        {
            List<PurchaseOrder> posearchlist = new List<PurchaseOrder>();

            string supplier_name;
            int order_id, update_history_id, supplier_id;
            decimal total_price;
            bool is_archived, is_com_approved, is_supp_approved;
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
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                supplier_name = dr["supplier_name"].ToString();
                is_archived = bool.Parse(dr["is_archived"].ToString());
                is_com_approved = bool.Parse(dr["is_com_approved"].ToString());
                is_supp_approved = bool.Parse(dr["is_supp_approved"].ToString());
                //item_id = int.Parse(dr["order_item_id"].ToString());
                //qty = int.Parse(dr["quantity"].ToString());
                //product_id = int.Parse(dr["product_id"].ToString());
                PurchaseOrder a = new PurchaseOrder(order_id, total_price, order_date, is_com_approved, is_supp_approved, update_history_id, supplier_id, is_archived, supplier_name);
                posearchlist.Add(a);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return posearchlist;
        }

        public int poDelete(int id)
        {
            string querystr = "UPDATE purchase_orders SET is_archived = 1 WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }
        public int poiDelete(int id)
        {
            string querystr = "UPDATE purchase_order_item SET is_archived = 1 WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }


        public int poUnarchieve(int id)
        {
            string querystr = "UPDATE purchase_orders SET is_archived = 0 WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }
        public int poiUnarchieve(int id)
        {
            string querystr = "UPDATE purchase_order_item SET is_archived = 0 WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int pocomapprove(int id)
        {
            string querystr = "UPDATE purchase_orders SET is_com_approved = 1 WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int pocomdecline(int id, string reason)
        {
            string querystr = "UPDATE purchase_orders SET attempt_no = attempt_no + 1, is_com_declined = 1, reason = @reason WHERE order_id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@reason", reason);
            //cmd.Parameters.AddWithValue("@no", no);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

    }
}