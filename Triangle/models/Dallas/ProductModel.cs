using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Triangle.models
{
    public class ProductModel
    {
        public static int GetStockOfProduct(string ID)
        {
            int output = 0;
            string queryString = "SELECT stock_level FROM products WHERE product_id = @id";

            try
            {
                using (SqlConnection CONNECTION = SQLConnTriangle.GetConnection())
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@id", ID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader.HasRows)
                            {
                                output = Convert.ToInt32(reader["stock_level"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return output;
        }
    }
}