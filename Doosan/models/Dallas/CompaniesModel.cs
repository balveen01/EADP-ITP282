using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Doosan.models
{
    public class CompaniesModel
    {
        SqlConnection CONNECTION = SQLConnDoosan.GetConnection();
        private string _name, _email, _address, _payment_method, _contact;
        private decimal _delivery_cost;
        private bool _is_archived;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Payment_Method
        {
            get { return _payment_method; }
            set { _payment_method = value; }
        }

        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        public decimal Delivery_Cost
        {
            get { return _delivery_cost; }
            set { _delivery_cost = value; }
        }

        public bool is_Archived
        {
            get { return _is_archived; }
            set { _is_archived = value; }
        }

        public DataSet getAllCompanies()
        {
            DataSet companies = new DataSet();
            string queryString = "SELECT * FROM companies";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(companies);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return companies;
        }

        public DataSet getCompany(int Id)
        {
            DataSet companies = new DataSet();
            string queryString = "SELECT * FROM companies WHERE id=@Id";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Id", Id);
                        da.Fill(companies);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return companies;
        }

        public int addCompany(string pName, string pEmail, string pAddress, string pPaymentMethod, decimal pDeliveryCost, string pContact)
        {
            string queryString = "INSERT INTO companies VALUES(@name, @email, @address, @payment_method, @delivery_cost, @contact";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@name", pName);
                        cmd.Parameters.AddWithValue("@email", pEmail);
                        cmd.Parameters.AddWithValue("@address", pAddress);
                        cmd.Parameters.AddWithValue("@payment_method", pPaymentMethod);
                        cmd.Parameters.AddWithValue("@delivery_cost", pDeliveryCost);
                        cmd.Parameters.AddWithValue("@contact", pContact);
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

        public int updateCompany(int Id, string pName, string pEmail, string pAddress, string pPaymentMethod, decimal pDeliveryCost, string pContact)
        {
            string queryString = "UPDATE companies SET company_name=@name, company_email=@email, company_address=@address, payment_method=@payment_method, @delivery_cost=@delivery_cost company_contact=@contact WHERE copmany_id=@id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@name", pName);
                        cmd.Parameters.AddWithValue("@email", pEmail);
                        cmd.Parameters.AddWithValue("@address", pAddress);
                        cmd.Parameters.AddWithValue("@payment_method", pPaymentMethod);
                        cmd.Parameters.AddWithValue("@delivery_cost", pDeliveryCost);
                        cmd.Parameters.AddWithValue("@contact", pContact);
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

        public int archiveCompany(int Id)
        {
            string queryString = "UPDATE companies SET is_archived = 1 WHERE id=@Id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
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

        public int UnarchiveCompany(int Id)
        {
            string queryString = "UPDATE companies SET is_archived = 0 WHERE id=@Id";
            int output = 0;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
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

        public bool isArchived(int Id)
        {
            string queryString = "SELECT is_archived FROM companies WHERE company_id=@id";
            bool output = true;

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                output = Convert.ToBoolean(reader["is_archived"].ToString());
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