using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Doosan.models
{
    public class RolesClass
    {
        public static bool checkIsMaster(string pUsername)
        {
            if (pUsername == "MASTER")
                return true;
            else
                return false;
        }

        public static string getDepartment(string pUsername)
        {
            string queryString = "SELECT department FROM STAFF WHERE username=@username";
            string output = "";

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
                            if (reader.Read())
                            {
                                output = reader["department"].ToString();
                                System.Diagnostics.Debug.WriteLine(output);
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

        public static bool checkIsAuthorised(string pUsername, string pDepartment)
        {
            if (!checkIsMaster(pUsername))
            {
                if (getDepartment(pUsername) == pDepartment)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}