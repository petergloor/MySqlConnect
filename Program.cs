/*
    This is a simple console app to test connections to a 
    OpenSimulator Robust Database on a MySql or MariaDB Server.

    We connect to the database using the connString below and
    query PrincipalID, FirstName and Lastname from UserAccounts.
*/

using System;
using MySqlConnector;
using Nini.Config;

namespace MySqlConnect
{
    internal class Program
    {  
        static void Main(string[] args) 
        {
            IConfigSource source = new IniConfigSource("MySqlConnect.ini");
            string connectionString = source.Configs["DatabaseService"].Get("ConnectionString");
            Console.WriteLine("Connect to OpenSim MySQL Server, get user accounts and output id, first and last name.");
            try
            {
                // Connect to database
                var conn = new MySqlConnection(@connectionString);
                conn.Open();
                Console.WriteLine("Connected");
        
                // Declare command
                MySqlCommand cmd = new ()
                {
                    CommandText = @"SELECT * FROM UserAccounts;",
                    Connection = conn
                };

                // Execute the command and read the results.
                using var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        // Get and output the commands to the console.
                        var id = reader.GetString("PrincipalId");
                        var FirstName = reader.GetString("FirstName");
                        var LastName = reader.GetString("LastName");

                        Console.WriteLine("{0} {1} {2}", id, FirstName, LastName);
                    }
                }

                // Close the connection when we are done
                conn.Close();
            }
            catch (MySqlException ex)
            {
                // Oops... an error occured.
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Done :)");
        }
    }

}
