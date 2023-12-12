using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Doosan.models
{
    public class SQLConn
    {
        public static SqlConnection GetConnection()
        {
            String connString = ConfigurationManager.ConnectionStrings["DOOSAN_DB"].ConnectionString;
            SqlConnection dbConn = new SqlConnection(connString);
            return dbConn;
        }
    }
}