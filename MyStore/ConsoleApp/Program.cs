using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = @".\CUTRESON";
            string database = "MyStore";
            string username = "son";
            string password = "son@123";
            SQLConnector.SetConnectionInfo(server, database, username, password);
            if(SQLConnector.TestConnection())
            {
                Console.WriteLine("Connect");
            }
            else
            {
                Console.WriteLine("Not connect");
            }
            Console.ReadLine();
        }
    }
}
