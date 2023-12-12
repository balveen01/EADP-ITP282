using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Doosan.models
{
    public class ProductsModel
    {

        public DataTable GetSalesPerMonth()
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();
            DataSet sales = new DataSet();
            string queryString = "SELECT YEAR(order_date) as SalesYear, MONTH(order_date) as SalesMonth, SUM(total_price) AS TotalSales FROM customer_order GROUP BY YEAR(order_date), MONTH(order_date) ORDER BY YEAR(order_date), MONTH(order_date)";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(sales);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return sales.Tables[0];
        }

        public DataTable GetProductsSortedByPurchases()
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();
            DataSet products = new DataSet();
            string queryString = "SELECT DISTINCT(o.product_id) 'ID', QUOTENAME(p.product_name, '\"\"') 'ProductName',  SUM(o.quantity) 'Frequency' FROM customer_order_item o INNER JOIN products p  on p.product_id = o.product_id GROUP BY p.product_name, o.product_id ORDER BY SUM(o.quantity) Desc";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(products);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return products.Tables[0];
        }
    }
}