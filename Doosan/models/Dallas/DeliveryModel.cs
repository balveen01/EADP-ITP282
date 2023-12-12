using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Doosan.models
{
    public class DeliveryModel
    {
        SqlConnection CONNECTION = SQLConnDoosan.GetConnection();

        private string _deliveryAddress;
        private DateTime _packingDate, _deliveryDate, _approvedDate;
        private bool _isApproved, _isPacked, _isDelivered;
        private int _deliveryId, _updateHistoryId, _orderId;

        public int Delivery_ID
        {
            get { return _deliveryId; }
            set { _deliveryId = value; }
        }
        public string Delivery_Address
        {
            get { return _deliveryAddress; }
            set { _deliveryAddress = value; }
        }
        public DateTime PackingDate
        {
            get { return _packingDate; }
            set { _packingDate = value; }
        }
        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }
            set { _deliveryDate = value; }
        }
        public DateTime ApprovedDate
        {
            get { return _approvedDate; }
            set { _approvedDate = value; }
        }
        public bool isApproved
        {
            get { return _isApproved; }
            set { _isApproved = value; }
        }
        public bool isPacked
        {
            get { return _isPacked; }
            set { _isPacked = value; }
        }
        public bool isDelivered
        {
            get { return _isDelivered; }
            set { _isDelivered = value; }
        }
        public int UpdateHistory_ID
        {
            get { return _updateHistoryId; }
            set { _updateHistoryId = value; }
        }
        public int Order_ID
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        public DeliveryModel()
        {

        }

        public static int createDelivery(string address, string orderID)
        {
            int output = 0;
            string queryString = "INSERT INTO delivery_details (delivery_address, order_id) VALUES (@delivery_address, @order_id)";
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();

            using (CONNECTION)
            {
                CONNECTION.Open();
                using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION)) {
                    cmd.Parameters.AddWithValue("@delivery_address", address);
                    cmd.Parameters.AddWithValue("@order_id", orderID);
                    output = cmd.ExecuteNonQuery();
                }
            }


            return output;
        }

        public DataSet getAllDeliveries()
        {
            DataSet deliveries = new DataSet();
            string queryString = "SELECT * FROM Delivery_Details WHERE is_archived = 1";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(deliveries);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return deliveries;
        }

        public DataSet getAllDeliveriesArchived()
        {
            DataSet deliveries = new DataSet();
            string queryString = "SELECT * FROM Delivery_Details WHERE is_archived = 0";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(deliveries);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return deliveries;
        }

        public DataSet getDelivery(int Id)
        {
            DataSet deliveries = new DataSet();
            string queryString = "SELECT * FROM Delivery_Details WHERE delivery_id=@id";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@id", Id);
                        da.Fill(deliveries);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return deliveries;
        }

        public DataSet getDeliveryFullDetails()
        {
            DataSet details = new DataSet();
            string queryString = "SELECT * FROM delivery_details d INNER JOIN customer_order co ON d.order_id = co.order_id INNER JOIN companies c ON co.company_id = c.company_id WHERE d.is_archived = 0 ORDER BY co.order_date DESC";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(details);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return details;
        }

        public DataSet getDeliveryFullDetailsArchived()
        {
            DataSet details = new DataSet();
            string queryString = "SELECT * FROM delivery_details d INNER JOIN customer_order co ON d.order_id = co.order_id INNER JOIN companies c ON co.company_id = c.company_id WHERE d.is_archived = 1 ORDER BY co.order_date DESC";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(details);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return details;
        }

        public DataSet getDeliveryFullDetails(int Id)
        {
            DataSet details = new DataSet();
            string queryString = "SELECT * FROM delivery_details d INNER JOIN customer_order co ON d.order_id = co.order_id INNER JOIN companies c ON co.company_id = c.company_id WHERE delivery_id=@id ORDER BY co.order_date DESC";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@id", Id);
                        da.Fill(details);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return details;
        }

        public DataSet getDeliveryFullDetailsOrderId(int Id)
        {
            DataSet details = new DataSet();
            string queryString = "SELECT * FROM delivery_details d INNER JOIN customer_order co ON d.order_id = co.order_id INNER JOIN companies c ON co.company_id = c.company_id WHERE d.order_id=@id";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@id", Id);
                        da.Fill(details);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return details;
        }
        
        public DataSet getDeliveryFullDetailsByCompany(int Id)
        {
            DataSet details = new DataSet();
            string queryString = "SELECT * FROM delivery_details d INNER JOIN customer_order co ON d.order_id = co.order_id INNER JOIN companies c ON co.company_id = c.company_id WHERE c.company_id=@id ORDER BY co.order_date DESC";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@id", Id);
                        da.Fill(details);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return details;
        }

        public DataSet getDeliveriesBySearch(string Keyword)
        {
            DataSet deliveries = new DataSet();

            string queryString = "SELECT * FROM delivery_details d INNER JOIN customer_order co ON d.order_id = co.order_id INNER JOIN companies c ON co.company_id = c.company_id WHERE delivery_id LIKE '%' + @keyword + '%' OR c.company_name LIKE '%' + @keyword + '%' AND d.is_archived = 0  ORDER BY co.order_date DESC";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@keyword", Keyword);
                        da.Fill(deliveries);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return deliveries;
        }

        public DataSet getDeliveriesArchivedBySearch(string Keyword)
        {
            DataSet deliveries = new DataSet();

            string queryString = "SELECT * FROM delivery_details d INNER JOIN customer_order co ON d.order_id = co.order_id INNER JOIN companies c ON co.company_id = c.company_id WHERE delivery_id LIKE '%' + @keyword + '%' OR OR c.company_name LIKE '%' + @keyword + '%' AND d.is_archived = 1  ORDER BY co.order_date DESC";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@keyword", Keyword);
                        da.Fill(deliveries);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return deliveries;
        }

        public DataTable getDeliveryApprovalTimes()
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();
            DataSet deliveries = new DataSet();
            string queryString = "SELECT delivery_id, QUOTENAME(FORMAT (approved_date, 'ddd dd/MMM/yyyy HH:mm:ss'), '\"\"'), '\"a\"' FROM delivery_details";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(deliveries);
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
            return deliveries.Tables[0];
        }

        public DataTable getDeliveryPackedTimes()
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();
            DataSet deliveries = new DataSet();
            string queryString = "SELECT delivery_id, QUOTENAME(FORMAT (packing_date, 'ddd dd/MMM/yyyy HH:mm:ss'), '\"\"'), '\"p\"' FROM delivery_details";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(deliveries);
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
            return deliveries.Tables[0];
        }

        public DataTable getDeliveryDeliverTimes()
        {
            SqlConnection CONNECTION = SQLConnDoosan.GetConnection();
            DataSet deliveries = new DataSet();
            string queryString = "SELECT delivery_id, QUOTENAME(FORMAT (deliver_date, 'ddd dd/MMM/yyyy HH:mm:ss'), '\"\"'), '\"d\"' FROM delivery_details";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(deliveries);
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
            return deliveries.Tables[0];
        }
    }
}