using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Doosan.BLL;
using Doosan.models;


namespace Doosan.DAL
{
    public class dalInvoice
    {
        private String errMsg;
        SQLConnDoosan dbConn = new SQLConnDoosan();

        public DataSet GetAllInvoice()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet InvoiceData;

            SqlConnection conn = SQLConnDoosan.GetConnection();
            InvoiceData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT i.*, c.company_id, co.order_id");
            sql.AppendLine("FROM invoices i");
            sql.AppendLine("INNER JOIN companies c ON c.company_id = i.company_id");
            sql.AppendLine("INNER JOIN customer_order co ON co.order_id = i.order_id");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(InvoiceData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return InvoiceData;
        }
    }
}