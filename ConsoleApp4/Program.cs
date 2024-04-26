using MySql.Data.MySqlClient;
using System;

class Program
{
    static void Main()
    {
        string connectionString = "server=127.0.0.1;user=root;password=;database=test";

        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Connection successful!");

     
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }
}





