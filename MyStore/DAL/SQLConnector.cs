using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SQLConnector
    {
        private static string myServerAddress, myDataBase, myUsername, myPassword;
        private static string connectionString = string.Empty;
        public static void SetConnectionInfo(string server, string database, string username, string password)
        {
            myServerAddress = server;
            myDataBase = database;
            myUsername = username;  
            myPassword = password;
            SetConnectionString();
        }

        private static void SetConnectionString()
        {
            string connectionTemplate = @"Server={0};Database={1};User Id={2};Password={3};";
            connectionString = string.Format(connectionTemplate, myServerAddress, myDataBase, myUsername, myPassword);
        }
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
