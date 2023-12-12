using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Doosan.models
{
    public class DeliveryStatus
    {
        // Get Status
        public static bool CheckIsApproved(string Id)
        {
            string queryString = "SELECT is_approved FROM delivery_details WHERE delivery_id = @id";
            bool output = false;

            try
            {
                using (SqlConnection CONNECTION = SQLConnDoosan.GetConnection())
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader.HasRows)
                            {
                                output = Convert.ToBoolean(reader["is_approved"]);
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

        public static bool CheckIsPacked(string Id)
        {
            string queryString = "SELECT is_packed FROM delivery_details WHERE delivery_id = @id";
            bool output = false;

            try
            {
                using (SqlConnection CONNECTION = SQLConnDoosan.GetConnection())
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader.HasRows)
                            {
                                output = Convert.ToBoolean(reader["is_packed"]);
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

        public static bool CheckIsDelivered(string Id)
        {
            string queryString = "SELECT is_delivered FROM delivery_details WHERE delivery_id = @id";
            bool output = false;

            try
            {
                using (SqlConnection CONNECTION = SQLConnDoosan.GetConnection())
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader.HasRows)
                            {
                                output = Convert.ToBoolean(reader["is_delivered"]);
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


        // Set Status
        public static int SetIsApproved(string Id)
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();

            string queryString = "UPDATE delivery_details SET is_approved=1, approved_date=@date WHERE delivery_id=@id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id", Id);
                        output = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return output;
        }

        public static int SetIsNotApproved(string Id)
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();

            string queryString = "UPDATE delivery_details SET is_approved=0, approved_date=@date WHERE delivery_id = @id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id", Id);
                        output = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return output;
        }

        public static int SetIsPacked(string Id)
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();

            string queryString = "UPDATE delivery_details SET is_packed=1, packing_date=@date WHERE delivery_id = @id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id", Id);
                        output = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return output;
        }

        public static int SetIsNotPacked(string Id)
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();

            string queryString = "UPDATE delivery_details SET is_packed=0, packing_date=@date WHERE delivery_id = @id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id", Id);
                        output = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return output;
        }

        public static int SetIsDelivered(string Id)
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();

            string queryString = "UPDATE delivery_details SET is_delivered=1, deliver_date=@date WHERE delivery_id = @id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id", Id);
                        output = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return output;
        }

        public static int SetIsNotDelivered(string Id)
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();

            string queryString = "UPDATE delivery_details SET is_delivered=0, deliver_date=@date WHERE delivery_id = @id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id", Id);
                        output = cmd.ExecuteNonQuery();
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