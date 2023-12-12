using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Triangle.models
{
    public class AccountModel
    {
        SqlConnection CONNECTION = SQLConnTriangle.GetConnection();
        private string _username, _password, _role, _email, _name;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
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
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public AccountModel() { }

        public AccountModel(string pUsername, string pPassword)
        {
            _username = pUsername;
            _password = pPassword;
        }

        public AccountModel(string pUsername, string pEmail, string pName, string pRole)
        {
            _username = pUsername;
            _email = pEmail;
            _name = pName;
            _role = pRole;
        }

        public AccountModel(string pUsername, string pPassword, string pEmail, string pName, string pRole)
        {
            _username = pUsername;
            _password = pPassword;
            _email = pEmail;
            _name = pName;
            _role = pRole;
        }

        public int CreateAccount(string pUsername, string pPassword, string pEmail, string pName, string pRole)
        {
            int output = 0;
            string queryString = "INSERT INTO USERS VALUES(@username, @password, @email, @name, @role";

            try
            {
                CONNECTION.Open();
                using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                {
                    cmd.Parameters.AddWithValue("@username", pUsername);
                    cmd.Parameters.AddWithValue("@password", pPassword);
                    cmd.Parameters.AddWithValue("@email", pEmail);
                    cmd.Parameters.AddWithValue("@name", pName);
                    cmd.Parameters.AddWithValue("@role", pRole);

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

        public DataSet GetAllUsers()
        {
            DataSet accounts = new DataSet();
            string queryString = "SELECT * FROM users where is_archived = 0";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION);
                da.Fill(accounts);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return accounts;
        }

        public DataSet GetAllUsers(string role)
        {
            DataSet accounts = new DataSet();
            string queryString = "SELECT * FROM users where is_archived = 0 and role = @role";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION);
                da.SelectCommand.Parameters.AddWithValue("@role", role);
                da.Fill(accounts);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return accounts;
        }

        public DataSet GetAllArchivedUsers()
        {
            DataSet accounts = new DataSet();
            string queryString = "SELECT * FROM users where is_archived = 1";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION);
                da.Fill(accounts);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return accounts;
        }

        public DataSet GetAllArchivedUsers(string role)
        {
            DataSet accounts = new DataSet();
            string queryString = "SELECT * FROM users where is_archived = 1 and role = @role";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION);
                da.SelectCommand.Parameters.AddWithValue("@role", role);
                da.Fill(accounts);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                CONNECTION.Close();
            }
            return accounts;
        }

        public AccountModel GetUser(string id)
        {
            AccountModel Account = new AccountModel();
            string queryString = "SELECT * FROM users WHERE id=@id";

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlCommand cmd = new SqlCommand(queryString, CONNECTION))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Username = reader["username"].ToString();
                                Name = reader["name"].ToString();
                                Email = reader["email"].ToString();
                                Role = reader["role"].ToString();
                                Account = new AccountModel(Username, Name, Email, Role);
                            }
                        }
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
            return Account;
        }

        public DataSet GetAllUsersBySearch(string Keyword, bool GetArchived)
        {
            DataSet accounts = new DataSet();
            string queryString;

            if (GetArchived)
            {
                queryString = "SELECT * FROM users WHERE username LIKE '%' + @keyword + '%' OR name LIKE '%' + @keyword + '%' OR email LIKE '%' + @keyword + '%' AND is_archived = 1";
            }
            else
            {
                queryString = "SELECT * FROM users WHERE username LIKE '%' + @keyword + '%' OR name LIKE '%' + @keyword + '%' OR email LIKE '%' + @keyword + '%' AND is_archived = 0";
            }

            try
            {
                using (CONNECTION)
                {
                    CONNECTION.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryString, CONNECTION))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@keyword", Keyword);
                        da.Fill(accounts);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return accounts;
        }

        public int updateAccount(string Id, string pName, string pEmail, string pRole)
        {
            string queryString = "UPDATE user SET name=@name, email=@email, role=@role WHERE id=@id";
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
                        cmd.Parameters.AddWithValue("@role", pRole);
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

        public int ArchiveAccount(string Id)
        {
            string queryString = "UPDATE users SET is_archived = 1 WHERE id=@id";
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

        public int UnarchiveAccount(string Id)
        {
            string queryString = "UPDATE users SET is_archived = 0 WHERE id=@id";
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

        public bool GetArchivedStatus(string Id)
        {
            string queryString = "SELECT is_archived FROM users WHERE Id = @id";
            bool output = false;
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
                            if (reader.Read() && reader.HasRows)
                            {
                                output = Convert.ToBoolean(reader["is_archived"]);
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