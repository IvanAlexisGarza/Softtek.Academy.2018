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
        public static void OpenSQLConnectionInCode()
        {
            string connectionString = GetConnectionStringFromCode();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                try
                {
                    connection.Open();
                    Console.WriteLine($"State: {connection.State}\n");
                    Console.WriteLine($"Connnection String:\n{connection.ConnectionString}\n");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private static string GetConnectionStringFromCode()
        {
            return @"Data Source=STKEND90186\SQLEXPRESS;Initial Catalog=Survey;Integrated Security=False;User" +
                    " ID=sa;Password=softtek.001;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;" +
                    "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static void OpenSQLConnection()
        {
            string connectionString = GetConnectionStringFromConfigFile();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                try
                {
                    connection.Open();
                    Console.WriteLine($"State: {connection.State}\n");
                    Console.WriteLine($"Connnection String:\n{connection.ConnectionString}\n");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static string GetConnectionStringFromConfigFile()
        {
            return ConfigurationManager.ConnectionStrings["SurveyAppConnectionString"].ConnectionString;
        }

    }
}
