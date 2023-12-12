using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Triangle.models
{
    public class BCOrders
    {
        public BCOrders() { }

        SqlConnection CONNECTION = SQLConnTriangle.GetConnection();

        public DataSet GetAllBCOrders()
        {
            DataSet orders = new DataSet();
            string queryString = "SELECT * FROM business_orders ORDER BY order_date desc";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION);
                da.Fill(orders);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return orders;
        }

        public DataSet GetBCOrder(string id)
        {
            DataSet orders = new DataSet();
            string queryString = "SELECT * FROM business_orders bc INNER JOIN business_order_item bci on bc.order_id = bci.order_id INNER JOIN products prod on prod.product_id = bci.product_id WHERE bc.order_id = @order_id";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION);
                da.SelectCommand.Parameters.AddWithValue("@order_id", id);
                da.Fill(orders);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return orders;
        }
    }
}