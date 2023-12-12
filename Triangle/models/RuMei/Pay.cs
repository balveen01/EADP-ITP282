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
    public class Pay
    {
        private String errMsg;
        Conn dbConn = new Conn();
        public DataSet GetAll()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet Payment;

            SqlConnection conn = dbConn.GetConnect();
            Payment = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM payments where is_archived = 0");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(Payment);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return Payment;
        }

        public DataSet GetPaymentDetail(int id)
        {
          
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet Payment;

            SqlConnection conn = dbConn.GetConnect();
            Payment = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT payment_id, description, total_price, expiry_date, is_received, is_declined FROM payments where is_archived = 0 AND payment_id = " + id);

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
          
         
                da.Fill(Payment);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return Payment;
        }
        public void updateStatus(int id)
        {
           
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet Payment;

            SqlConnection conn = dbConn.GetConnect();
            Payment = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("UPDATE payments");
            sql.AppendLine(" ");
            sql.AppendLine("Set is_received = 1");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE payment_id =" + id);

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
              

                da.Fill(Payment);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public void updateStatusDecline(int id)
        {

            StringBuilder sql;
            SqlDataAdapter da;
            DataSet Payment;

            SqlConnection conn = dbConn.GetConnect();
            Payment = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("UPDATE payments");
            sql.AppendLine(" ");
            sql.AppendLine("Set is_declined = 1");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE payment_id =" + id);

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);


                da.Fill(Payment);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

    }


}