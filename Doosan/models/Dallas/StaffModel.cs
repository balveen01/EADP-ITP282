using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Doosan.models;

namespace Doosan.models
{
    public class StaffModel
    {
        SqlConnection CONNECTION = SQLConnDoosan.GetConnection();
        private string _username, _department, _email, _name;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public StaffModel() { }

        public StaffModel(string pUsername)
        {
            _username = pUsername;
        }

        public StaffModel(string pUsername, string pEmail, string pName, string pDepartment)
        {
            _username = pUsername;
            _email = pEmail;
            _name = pName;
            _department = pDepartment;
        }

        public int createStaff(string pUsername, string pEmail, string pName, string pDepartment)
        {
            int output = 0;
            string queryString = "INSERT INTO STAFF VALUES(@username, @email, @name, @department";

            try
            {
                CONNECTION.Open();
                using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                {
                    cmd.Parameters.AddWithValue("@username", pUsername);
                    cmd.Parameters.AddWithValue("@email", pEmail);
                    cmd.Parameters.AddWithValue("@name", pName);
                    cmd.Parameters.AddWithValue("@department", pDepartment);

                    output += cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                output = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }

            return output;
        }

        public StaffModel getStaff(string Id)
        {
            StaffModel staff = new StaffModel();
            string queryString = "SELECT * FROM staff WHERE id=@id";
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
                                Username = reader["username"].ToString();
                                Name = reader["name"].ToString();
                                Email = reader["email"].ToString();
                                Department = reader["department"].ToString();
                                staff = new StaffModel(Username, Name, Email, Department);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return staff;
        }

        public DataSet getAllStaff()
        {
            DataSet staff = new DataSet();
            string queryString = "SELECT * FROM staff WHERE is_archived = 0";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(staff);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return staff;
        }

        public DataSet getAllStaff(string Keyword)
        {
            DataSet staff = new DataSet();
            string queryString = "SELECT * FROM staff WHERE id LIKE '%' + @keyword + '%' OR username LIKE '%' + @keyword + '%' OR name LIKE '%' + @keyword + '%' OR email LIKE '%' + @keyword + '%' OR department LIKE '%' + @keyword + '%' AND is_archived = 0";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@keyword", Keyword);
                        da.Fill(staff);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return staff;
        }

        public DataSet getAllStaffByDepartment(string pDepartment)
        {
            DataSet staff = new DataSet();
            string queryString = "SELECT * FROM staff WHERE is_archived = 0 and department=@deparment";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@department", pDepartment);
                        da.Fill(staff);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return staff;
        }

        public DataSet getAllDeactivatedStaff()
        {
            DataSet staff = new DataSet();
            string queryString = "SELECT * FROM staff WHERE is_archived = 1";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.Fill(staff);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return staff;
        }

        public DataSet getAllDeactivatedStaff(string Keyword)
        {
            DataSet staff = new DataSet();
            string queryString = "SELECT * FROM staff WHERE id LIKE '%' + @keyword + '%' OR username LIKE '%' + @keyword + '%' OR name LIKE '%' + @keyword + '%' OR email LIKE '%' + @keyword + '%' OR department LIKE '%' + @keyword + '%' AND is_archived = 1";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@keyword", Keyword);
                        da.Fill(staff);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return staff;
        }

        public bool checkIsActivated(string Id)
        {
            string queryString = "SELECT is_archived FROM STAFF WHERE id = @id";
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
                                output = !Convert.ToBoolean(reader["is_archived"]);
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

        public static bool checkIsExist(string pUsername)
        {
            string queryString = "SELECT * FROM STAFF WHERE username = @username";
            bool output = false;

            try
            {
                using (SqlConnection CONNECTION = SQLConnDoosan.GetConnection())
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@username", pUsername);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader.HasRows)
                            {
                                output = true;
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

        public int updateStaff(string Id, string pName, string pDepartment)
        {
            string queryString = "UPDATE staff SET name=@name, department=@department WHERE id=@id";
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
                        cmd.Parameters.AddWithValue("@department", pDepartment);
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

        public int deactivateStaff(string Id)
        {
            string queryString = "UPDATE staff SET is_archived = 1 WHERE id=@id";
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

        public int reactivateStaff(string Id)
        {
            string queryString = "UPDATE staff SET is_archived = 0 WHERE id=@id";
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
    }
}