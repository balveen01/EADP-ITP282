using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Triangle.models
{
    public class Payment
    {
        string _connStr = ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;
        private string _payment_id = null;
        private string _description = string.Empty;
        private decimal _total_price = 0;
        private string _bank_name = string.Empty;
        private string _bank_number = string.Empty;
        private string _bank_branch = string.Empty;
        private string _card_name = string.Empty;
        private string _card_number = string.Empty;
        private string _expiry_date = string.Empty;
        private string _is_archived = string.Empty;
        //private string _status = string.Empty;
        private String _payment_date;
        private int _supplier_id, _update_history_id, _invoice_id;
        private string _payment_method;
        private bool _is_received, _is_approved, _is_declined;



        public Payment()
        {
        }

        //constructor takes all 

        public Payment(string payment_id, string description, decimal total_price, string bank_name,
       string bank_number, string bank_branch, string card_name, string card_number, string expiry_date,
       string is_archived, String payment_date, int supplier_id, int invoice_id, int update_history_id, string payment_method, bool is_received, bool is_approved, bool is_declined)
        {
            _payment_id = payment_id;
            _description = description;
            _total_price = total_price;
            _bank_name = bank_name;
            _bank_number = bank_number;
            _bank_branch = bank_branch;
            _card_name = card_name;
            _card_number = card_number;
            _expiry_date = expiry_date;
            _is_archived = is_archived;
            _payment_date = payment_date;
            _invoice_id = invoice_id;
            _update_history_id = update_history_id;
            _supplier_id = supplier_id;
            _payment_method = payment_method;
            _is_received = is_received;
            _is_approved = is_approved;
            _is_declined = is_declined;

        }

        //constructor takes all without payment_id
        public Payment(string description, decimal total_price, string bank_name,
            string bank_number, string bank_branch, string card_name, string card_number, string expiry_date,
            string is_archived, String payment_date, int supplier_id, int invoice_id, int update_history_id, string payment_method, bool is_received, bool is_approved, bool is_declined)
        {
            _description = description;
            _total_price = total_price;
            _bank_name = bank_name;
            _bank_number = bank_number;
            _bank_branch = bank_branch;
            _card_name = card_name;
            _card_number = card_number;
            _expiry_date = expiry_date;
            _is_archived = is_archived;
            _payment_date = payment_date;
            _invoice_id = invoice_id;
            _update_history_id = update_history_id;
            _supplier_id = supplier_id;
            _payment_method = payment_method;
            _is_received = is_received;
            _is_approved = is_approved;
            _is_declined = is_declined;

        }

        //    public Payment(string description, decimal total_price, string bank_name,
        //string bank_number, string bank_branch, string card_name, string card_number, string expiry_date,
        //string is_archived, DateTime payment_date, int supplier_id, int invoice_id, int update_history_id, string payment_method, bool is_recevied, bool is_approved)
        //    {
        //        _description = description;
        //        _total_price = total_price;
        //        _bank_name = bank_name;
        //        _bank_number = bank_number;
        //        _bank_branch = bank_branch;
        //        _card_name = card_name;
        //        _card_number = card_number;
        //        _expiry_date = expiry_date;
        //        _is_archived = is_archived;
        //        _payment_date = payment_date;
        //        _invoice_id = invoice_id;
        //        _update_history_id = update_history_id;
        //        _supplier_id = supplier_id;
        //        _payment_method = payment_method;
        //        _is_received = is_recevied ;
        //        _is_approved = is_approved;
        //    }


        public Payment(string payment_id)
        {
            _payment_id = payment_id;
        }

        public Payment(string description, decimal total_price, string bank_name,
           string bank_number, string bank_branch, string card_name, string card_number, string expiry_date,
            string payment_date, string payment_method)
            : this(null, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, "False", payment_date, 1, 1, 1, payment_method, false, true, false)
        {


        }



        public string payment_id
        {
            get { return _payment_id; }
            set { _payment_id = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public decimal total_price
        {
            get { return _total_price; }
            set { _total_price = value; }
        }

        public string bank_name
        {
            get { return _bank_name; }
            set { _bank_name = value; }
        }

        public string bank_number
        {
            get { return _bank_number; }
            set { _bank_number = value; }
        }

        public string bank_branch
        {
            get { return _bank_branch; }
            set { _bank_branch = value; }
        }

        public string card_name
        {
            get { return _card_name; }
            set { _card_name = value; }
        }

        public string card_number
        {
            get { return _card_number; }
            set { _card_number = value; }
        }

        public string expiry_date
        {
            get { return _expiry_date; }
            set { _expiry_date = value; }
        }

        public string is_archived
        {
            get { return _is_archived; }
            set { _is_archived = value; }
        }

        public string payment_date
        {
            get { return _payment_date; }
            set { _payment_date = value; }
        }
        public string payment_method
        {
            get { return _payment_method; }
            set { _payment_method = value; }
        }
        public int supplier_id
        {
            get { return _supplier_id; }
            set { _supplier_id = value; }
        }

        public bool is_received
        {
            get { return _is_received; }
            set { _is_received = value; }
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

        public int invoice_id
        {
            get { return _invoice_id; }
            set { _invoice_id = value; }
        }
        public bool is_declined
        {
            get { return _is_declined; }
            set { _is_declined = value; }
        }





        public List<Payment> getAllPayment()
        {
            List<Payment> paymentList = new List<Payment>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, payment_method, payment_date;
            decimal total_price;
            int supplier_id, update_history_id, invoice_id;

            bool is_approved, is_received, is_declined;
            string queryStr = "SELECT * FROM payments WHERE is_archived = 0";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                payment_id = dr["payment_id"].ToString();
                description = dr["description"].ToString();
                total_price = decimal.Parse(dr["total_price"].ToString());
                bank_name = dr["bank_name"].ToString();
                bank_number = dr["bank_number"].ToString();
                bank_branch = dr["bank_branch"].ToString();
                card_name = dr["card_name"].ToString();
                card_number = dr["card_number"].ToString();
                expiry_date = dr["expiry_date"].ToString();
                is_archived = dr["is_archived"].ToString();
                payment_method = dr["payment_method"].ToString();
                payment_date = (dr["payment_date"].ToString());
                invoice_id = int.Parse(dr["invoice_id"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                is_received = bool.Parse(dr["is_received"].ToString());
                is_declined = bool.Parse(dr["is_declined"].ToString());
                Payment pay = new Payment(payment_id, description, total_price, bank_name,
             bank_number, bank_branch, card_name, card_number, expiry_date,
             is_archived, payment_date, supplier_id, invoice_id, update_history_id, payment_method, is_received, is_approved, is_declined);
                paymentList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return paymentList;
        }
        public List<Payment> getAllArchivedPayment()
        {
            List<Payment> paymentList = new List<Payment>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, payment_method, payment_date;
            decimal total_price;
            int supplier_id, update_history_id, invoice_id;

            bool is_approved, is_received, is_declined;
            string queryStr = "SELECT * FROM payments WHERE is_archived = 1";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                payment_id = dr["payment_id"].ToString();
                description = dr["description"].ToString();
                total_price = decimal.Parse(dr["total_price"].ToString());
                bank_name = dr["bank_name"].ToString();
                bank_number = dr["bank_number"].ToString();
                bank_branch = dr["bank_branch"].ToString();
                card_name = dr["card_name"].ToString();
                card_number = dr["card_number"].ToString();
                expiry_date = dr["expiry_date"].ToString();
                is_archived = dr["is_archived"].ToString();
                payment_method = dr["payment_method"].ToString();
                payment_date = (dr["payment_date"].ToString());
                invoice_id = int.Parse(dr["invoice_id"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                is_received = bool.Parse(dr["is_received"].ToString());
                is_declined = bool.Parse(dr["is_declined"].ToString());
                Payment pay = new Payment(payment_id, description, total_price, bank_name,
             bank_number, bank_branch, card_name, card_number, expiry_date,
             is_archived, payment_date, supplier_id, invoice_id, update_history_id, payment_method, is_received, is_approved, is_declined);
                paymentList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return paymentList;
        }

        public Payment getPayment(string payment_id)
        {
            Payment paymentDetail = null;
            string description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, payment_method, payment_date;
            decimal total_price;
            int supplier_id, update_history_id, invoice_id;

            bool is_approved, is_received, is_declined;
            string queryStr = "SELECT * FROM payments WHERE payment_id = @payment_id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@payment_id", payment_id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                description = dr["description"].ToString();
                total_price = decimal.Parse(dr["total_price"].ToString());
                bank_name = dr["bank_name"].ToString();
                bank_number = dr["bank_number"].ToString();
                bank_branch = dr["bank_branch"].ToString();
                card_name = dr["card_name"].ToString();
                card_number = dr["card_number"].ToString();
                expiry_date = dr["expiry_date"].ToString();
                is_archived = dr["is_archived"].ToString();
                payment_method = dr["payment_method"].ToString();
                payment_date = (dr["payment_date"].ToString());
                invoice_id = int.Parse(dr["invoice_id"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                is_received = bool.Parse(dr["is_received"].ToString());
                is_declined = bool.Parse(dr["is_declined"].ToString());
                Payment pay = new Payment(description, total_price, bank_name,
             bank_number, bank_branch, card_name, card_number, expiry_date,
             is_archived, payment_date, supplier_id, invoice_id, update_history_id, payment_method, is_received, is_approved, is_declined);

            }

            else
            {
                paymentDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();
            return paymentDetail;
        }

        public int PaymentDelete(string payment_id)
        {
            string queryStr = "DELETE FROM payments WHERE payment_id=@payment_id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@payment_id", payment_id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int PaymentUpdate(string paymentid, string description, decimal total_price, string expiry_date, string status, string is_declined)
        {
            string queryStr = "UPDATE [payments] SET " + "description = @description, " + "total_price = @total_price, " + "expiry_date = @expiry_date, " + "is_approved = @is_approved, " + "is_declined = @is_declined " + "WHERE payment_id = @payment_id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@payment_id", paymentid);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@total_price", total_price);
            cmd.Parameters.AddWithValue("@expiry_date", expiry_date);
            cmd.Parameters.AddWithValue("@is_approved", is_approved);
            cmd.Parameters.AddWithValue("@is_declined", is_declined);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;

        }

        public List<Payment> PaymentSearch(string desc)
        {
            List<Payment> payList = new List<Payment>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, payment_method, payment_date;
            decimal total_price;
            int supplier_id, update_history_id, invoice_id;

            bool is_approved, is_received, is_declined;
            string queryStr = "SELECT * FROM [payments] WHERE is_archived = 0 AND description like '" + desc + "%'";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                payment_id = dr["payment_id"].ToString();
                description = dr["description"].ToString();
                total_price = decimal.Parse(dr["total_price"].ToString());
                bank_name = dr["bank_name"].ToString();
                bank_number = dr["bank_number"].ToString();
                bank_branch = dr["bank_branch"].ToString();
                card_name = dr["card_name"].ToString();
                card_number = dr["card_number"].ToString();
                expiry_date = dr["expiry_date"].ToString();
                is_archived = dr["is_archived"].ToString();
                payment_method = dr["payment_method"].ToString();
                payment_date = (dr["payment_date"].ToString());
                invoice_id = int.Parse(dr["invoice_id"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                is_received = bool.Parse(dr["is_received"].ToString());
                is_declined = bool.Parse(dr["is_declined"].ToString());
                Payment pay = new Payment(payment_id, description, total_price, bank_name,
              bank_number, bank_branch, card_name, card_number, expiry_date,
              is_archived, payment_date, supplier_id, invoice_id, update_history_id, payment_method, is_received, is_approved, is_declined);
                payList.Add(pay);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();
            return payList;

        }

        public List<Payment> PaymentFilter(string stat)
        {
            List<Payment> payList = new List<Payment>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, payment_method, payment_date;
            decimal total_price;
            int supplier_id, update_history_id, invoice_id;

            bool is_approved, is_received, is_declined;
            string queryStr = string.Format("SELECT * FROM [payments] WHERE is_archived = 0 AND is_received = '" + stat + "'");


            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                payment_id = dr["payment_id"].ToString();
                description = dr["description"].ToString();
                total_price = decimal.Parse(dr["total_price"].ToString());
                bank_name = dr["bank_name"].ToString();
                bank_number = dr["bank_number"].ToString();
                bank_branch = dr["bank_branch"].ToString();
                card_name = dr["card_name"].ToString();
                card_number = dr["card_number"].ToString();
                expiry_date = dr["expiry_date"].ToString();
                is_archived = dr["is_archived"].ToString();
                payment_method = dr["payment_method"].ToString();
                payment_date = (dr["payment_date"].ToString());
                invoice_id = int.Parse(dr["invoice_id"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                is_received = bool.Parse(dr["is_received"].ToString());
                is_declined = bool.Parse(dr["is_declined"].ToString());
                Payment pay = new Payment(payment_id, description, total_price, bank_name,
              bank_number, bank_branch, card_name, card_number, expiry_date,
              is_archived, payment_date, supplier_id, invoice_id, update_history_id, payment_method, is_received, is_approved, is_declined);
                payList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return payList;
        }

        public List<Payment> PaymentSortPrice()
        {
            List<Payment> payList = new List<Payment>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, payment_method, payment_date;
            decimal total_price;
            int supplier_id, update_history_id, invoice_id;

            bool is_approved, is_received, is_declined;
            string queryStr = string.Format("SELECT * FROM [payments] WHERE is_archived = 0 ORDER BY total_price DESC");


            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                payment_id = dr["payment_id"].ToString();
                description = dr["description"].ToString();
                total_price = decimal.Parse(dr["total_price"].ToString());
                bank_name = dr["bank_name"].ToString();
                bank_number = dr["bank_number"].ToString();
                bank_branch = dr["bank_branch"].ToString();
                card_name = dr["card_name"].ToString();
                card_number = dr["card_number"].ToString();
                expiry_date = dr["expiry_date"].ToString();
                is_archived = dr["is_archived"].ToString();
                payment_method = dr["payment_method"].ToString();
                payment_date = (dr["payment_date"].ToString());
                invoice_id = int.Parse(dr["invoice_id"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                is_received = bool.Parse(dr["is_received"].ToString());
                is_declined = bool.Parse(dr["is_declined"].ToString());
                Payment pay = new Payment(payment_id, description, total_price, bank_name,
              bank_number, bank_branch, card_name, card_number, expiry_date,
              is_archived, payment_date, supplier_id, invoice_id, update_history_id, payment_method, is_received, is_approved, is_declined);
                payList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return payList;
        }

        public List<Payment> PaymentSortExpiryDate()
        {
            List<Payment> payList = new List<Payment>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, payment_method, payment_date;
            decimal total_price;
            int supplier_id, update_history_id, invoice_id;

            bool is_approved, is_received, is_declined;
            string queryStr = string.Format("SELECT * FROM [payments] WHERE is_archived = 0 ORDER BY expiry_date");


            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                payment_id = dr["payment_id"].ToString();
                payment_id = dr["payment_id"].ToString();
                description = dr["description"].ToString();
                total_price = decimal.Parse(dr["total_price"].ToString());
                bank_name = dr["bank_name"].ToString();
                bank_number = dr["bank_number"].ToString();
                bank_branch = dr["bank_branch"].ToString();
                card_name = dr["card_name"].ToString();
                card_number = dr["card_number"].ToString();
                expiry_date = dr["expiry_date"].ToString();
                is_archived = dr["is_archived"].ToString();
                payment_method = dr["payment_method"].ToString();
                payment_date = (dr["payment_date"].ToString());
                invoice_id = int.Parse(dr["invoice_id"].ToString());
                update_history_id = int.Parse(dr["update_history_id"].ToString());
                supplier_id = int.Parse(dr["supplier_id"].ToString());
                is_approved = bool.Parse(dr["is_approved"].ToString());
                is_received = bool.Parse(dr["is_received"].ToString());
                is_declined = bool.Parse(dr["is_declined"].ToString());
                Payment pay = new Payment(payment_id, description, total_price, bank_name,
              bank_number, bank_branch, card_name, card_number, expiry_date,
              is_archived, payment_date, supplier_id, invoice_id, update_history_id, payment_method, is_received, is_approved, is_declined);
                payList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return payList;
        }

        public int PaymentArchive(int id)
        {
            string queryStr = "UPDATE [payments] SET is_archived = 1 WHERE payment_id=@id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int PaymentInsert()
        {
            int result = 0;
            string queryStr = "INSERT INTO [payments](description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, payment_date, payment_method, supplier_id, invoice_id, update_history_id, is_received, is_approved, is_declined)"
                + "values(@description, @total_price, @bank_name, @bank_number, @bank_branch, @card_name, @card_number, @expiry_date, @is_archived, @payment_date,@payment_method, @supplier_id, @invoice_id, @update_history_id, @is_received, @is_approved, @is_declined)";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@description", this.description);
            cmd.Parameters.AddWithValue("@total_price", this.total_price);
            cmd.Parameters.AddWithValue("@bank_name", this.bank_name);
            cmd.Parameters.AddWithValue("@bank_number", this.bank_number);
            cmd.Parameters.AddWithValue("@bank_branch", this.bank_branch);
            cmd.Parameters.AddWithValue("@card_name", this.card_name);
            cmd.Parameters.AddWithValue("@card_number", this.card_number);
            cmd.Parameters.AddWithValue("@expiry_date", this.expiry_date);
            cmd.Parameters.AddWithValue("@is_archived", this.is_archived);
            cmd.Parameters.AddWithValue("@payment_date", this.payment_date);
            cmd.Parameters.AddWithValue("@payment_method", this.payment_method);
            cmd.Parameters.AddWithValue("@supplier_id", this.supplier_id);
            cmd.Parameters.AddWithValue("@invoice_id", this.invoice_id);
            cmd.Parameters.AddWithValue("@update_history_id", this.update_history_id);
            cmd.Parameters.AddWithValue("@is_received", this.is_received);
            cmd.Parameters.AddWithValue("@is_approved", this.is_approved);
            cmd.Parameters.AddWithValue("@is_declined", this.is_declined);


            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        //private String errMsg;
        //Conn dbConn = new Conn();

        //private DataSet GetAll()
        //{
        //    StringBuilder sql;
        //    SqlDataAdapter da;
        //    DataSet Payment;

        //    SqlConnection conn = dbConn.GetConnect();
        //    Payment = new DataSet();
        //    sql = new StringBuilder();
        //    sql.AppendLine("SELECT * FROM payments");

        //    try
        //    {
        //        da = new SqlDataAdapter(sql.ToString(), conn);
        //        da.Fill(Payment);
        //    }
        //    catch (Exception ex)
        //    {
        //        errMsg = ex.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return Payment;
        //}
    }

}