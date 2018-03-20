using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation.Helpers
{
    public class ConnectionStringHelper
    {
        ////Demo 2
        //public static void OpenSqlConnectionInCode()
        //{
        //    string connectionString = GetConnStringFromConfigFile();

        //    using (SqlConnection connection = new SqlConnection())
        //    {
        //        connection.ConnectionString = connectionString;

        //        connection.Open();

        //        Console.WriteLine("State: {0}", connection.State);
        //        Console.WriteLine("ConnectionString From Code: {0}", connection.ConnectionString);
        //    }
        //}

        //public static string GetConnStringFromConfigFile()
        //{
        //    return ConfigurationManager.ConnectionStrings["SQLExpress"].ConnectionString;
        //}

    }
}
