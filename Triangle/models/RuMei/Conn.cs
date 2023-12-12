using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace Triangle.models
 
{
    public class Conn
    {
        public SqlConnection GetConnect()
        {
            SqlConnection dbConn;
            String connString = ConfigurationManager.ConnectionStrings["TRIANGLE_DB"].ConnectionString;

            dbConn = new SqlConnection(connString);

            return dbConn;
        }
    }
}