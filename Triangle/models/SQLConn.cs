using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Triangle.models
{
    public class SQLConnTriangle
    {
        public static SqlConnection GetConnection()
        {
            String connString = ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;
            SqlConnection dbConn = new SqlConnection(connString);
            return dbConn;
        }
    }
}