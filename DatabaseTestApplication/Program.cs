using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DatabaseTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Code for connecting to DB
            //Need to modify path for our project
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=database._Complete.accdb";
            OleDbConnection connection = new OleDbConnection(connectString);
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;
            cmd.Connection = connection;

            //Open DB
            //try { connection.Open(); }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            int counter = 0;
            //var results = cmd.ExecuteScalar();
            cmd.CommandText = "SELECT * FROM reviews";
            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {//www.csharp-console-example.com
                counter++;
                Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4] + " " + reader[5] + " " + reader[6]);
            }
            connection.Close();

            ////Close DB
            //try { connection.Close(); }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
