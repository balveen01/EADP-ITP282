using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Doosan.TriangleWS;

namespace Doosan.models
{
    public class PaymentModel
    {
        string _connStr = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;
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
        private string _status = string.Empty;


        public PaymentModel()
        {
        }

        public PaymentModel(string payment_id, string description, decimal total_price, string bank_name,
       string bank_number, string bank_branch, string card_name, string card_number, string expiry_date,
       string is_archived, string status)
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
            _status = status;
        }

        public PaymentModel(string description, decimal total_price, string bank_name,
            string bank_number, string bank_branch, string card_name, string card_number, string expiry_date,
            string is_archived, string status)
            : this(null, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status)
        {

        }


        public PaymentModel(string payment_id)
            : this(payment_id, "", 0, "", "", "", "", "", "", "", "")
        {

        }

        public PaymentModel(string description, decimal total_price, string bank_name,
            string bank_number, string bank_branch, string card_name, string card_number, string expiry_date
            )
            : this(null, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, "False", "Paid")
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

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }


        public List<PaymentModel> getAllPayment()
        {
            List<PaymentModel> paymentList = new List<PaymentModel>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status;
            decimal total_price;
            string queryStr = "SELECT * FROM payment_info WHERE is_archived = 0";
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
                status = dr["status"].ToString();
                PaymentModel pay = new PaymentModel(payment_id, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status);
                paymentList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return paymentList;
        }
        public List<PaymentModel> getAllArchivedPayment()
        {
            List<PaymentModel> paymentList = new List<PaymentModel>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status;
            decimal total_price;
            string queryStr = "SELECT * FROM payment_info WHERE is_archived = 1";
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
                status = dr["status"].ToString();
                PaymentModel pay = new PaymentModel(payment_id, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status);
                paymentList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return paymentList;
        }

        public PaymentModel getPayment(string payment_id)
        {
            PaymentModel paymentDetail = null;
            string description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status;
            decimal total_price;
            string queryStr = "SELECT * FROM payment_info WHERE payment_id = @payment_id";
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
                status = dr["status"].ToString();
                PaymentModel pay = new PaymentModel(payment_id, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status);
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
            string queryStr = "DELETE FROM payment_info WHERE payment_id=@payment_id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@payment_id", payment_id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public int PaymentUpdate(string paymentid, string description, decimal total_price, string expiry_date, string status)
        {
            string queryStr = "UPDATE [payment_info] SET " + "description = @description, " + "total_price = @total_price, " + "expiry_date = @expiry_date, " + "status = @status " + "WHERE payment_id = @payment_id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@payment_id", paymentid);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@total_price", total_price);
            cmd.Parameters.AddWithValue("@expiry_date", expiry_date);
            cmd.Parameters.AddWithValue("@status", status);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;

        }

        public List<PaymentModel> PaymentSearch(string desc)
        {
            List<PaymentModel> payList = new List<PaymentModel>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status;
            decimal total_price;
            string queryStr = "SELECT * FROM [payment_info]  WHERE is_archived = 0 description like '" + desc + "%'";
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
                status = dr["status"].ToString();
                PaymentModel pay = new PaymentModel(payment_id, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status);
                payList.Add(pay);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();
            return payList;

        }

        public List<PaymentModel> PaymentFilter(string stat)
        {
            List<PaymentModel> payList = new List<PaymentModel>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status;
            decimal total_price;
            string queryStr = string.Format("SELECT * FROM [payment_info] WHERE is_archived = 0 AND status = '" + stat + "'");


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
                status = dr["status"].ToString();
                PaymentModel pay = new PaymentModel(payment_id, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status);
                payList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return payList;
        }

        public List<PaymentModel> PaymentSortPrice()
        {
            List<PaymentModel> payList = new List<PaymentModel>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status;
            decimal total_price;
            string queryStr = string.Format("SELECT * FROM [payment_info] WHERE is_archived = 0 ORDER BY total_price DESC");


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
                status = dr["status"].ToString();
                PaymentModel pay = new PaymentModel(payment_id, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status);
                payList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return payList;
        }

        public List<PaymentModel> PaymentSortExpiryDate()
        {
            List<PaymentModel> payList = new List<PaymentModel>();
            string payment_id, description, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status;
            decimal total_price;
            string queryStr = string.Format("SELECT * FROM [payment_info] WHERE is_archived = 0 ORDER BY expiry_date DESC");


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
                status = dr["status"].ToString();
                PaymentModel pay = new PaymentModel(payment_id, description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status);
                payList.Add(pay);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return payList;
        }

        public int PaymentArchive(int id)
        {
            string queryStr = "UPDATE [payment_info] SET is_archived = 1 WHERE payment_id=@id";
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
            string queryStr = "INSERT INTO [payment_info](description, total_price, bank_name, bank_number, bank_branch, card_name, card_number, expiry_date, is_archived, status)"
                + "values(@description, @total_price, @bank_name, @bank_number, @bank_branch, @card_name, @card_number, @expiry_date, @is_archived, @status)";
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
            cmd.Parameters.AddWithValue("@status", this.status);
            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        private string errMsg;
        public DataSet WSGetAll()
        {
            SqlDataAdapter da;
            DataSet payment;

            SqlConnection conn = new SqlConnection(_connStr);
            payment = new DataSet();
            string queryStr = "SELECT * FROM [payment_info] WHERE is_archived=0";
            try
            {
                da = new SqlDataAdapter(queryStr.ToString(), conn);
                da.Fill(payment);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return payment;
        }


        public DataSet GetAPaymet()
        {
            TriangleAPIClient payment;
            payment = new TriangleAPIClient();
            return payment.GetPayment();
        }

        public DataSet GetDetail (int id)
        {
            TriangleAPIClient details;
            details = new TriangleAPIClient();
            return details.GetDetails(id);
        }
      

        public void updateStatus(int id)
        {
            TriangleAPIClient details;
            details = new TriangleAPIClient();
             details.updateStatus(id);
        }

        public void updateStatusDecline(int id)
        {
            TriangleAPIClient details;
            details = new TriangleAPIClient();
            details.updateStatusDecline(id);
        }
    }

    
}